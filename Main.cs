using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BannerLib.Input;

using TaleWorlds.MountAndBlade;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.InputSystem;
using TaleWorlds.Localization;
using TaleWorlds.Engine.Screens;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;

namespace SimpleTroopSpawner
{
    public class Main : MBSubModuleBase
    {

        protected override void OnSubModuleLoad()
        {
            AddKeys();         
        }

        private void AddKeys()
        {
            BannerLib.Input.HotKeyManager hkm = BannerLib.Input.HotKeyManager.Create("TestMod");
            hkm.Add<SpawnTroops>();
            hkm.Build();
        }
    }

    internal class SpawnTroops : HotKeyBase
    {
        private List<CharacterObject> allTroops = new List<CharacterObject>();

        public SpawnTroops() : base(nameof(SpawnTroops))
        {
            DisplayName = new TextObject("Spawn Troops").ToString();
            Description = new TextObject().ToString();
            DefaultKey = InputKey.NumpadMinus;
            Category = BannerLib.Input.HotKeyManager.Categories[HotKeyCategory.CampaignMap];
            Predicate = IsKeyActive;
        }

        private bool IsKeyActive()
        {
            return Mission.Current == null && Campaign.Current != null && CharacterObject.PlayerCharacter != null && ScreenManager.TopScreen is MapScreen;
        }

        protected override void OnPressed()
        {
            List<InquiryElement> factionElements = new List<InquiryElement>();
            List<InquiryElement> troopElements = new List<InquiryElement>();

            List<Kingdom> majorFactions = Kingdom.All.Where(kingdoms => kingdoms.IsKingdomFaction && !kingdoms.IsMinorFaction).ToList();

            foreach(Kingdom kingdom in majorFactions)
            {
                factionElements.Add(new InquiryElement(kingdom, kingdom.Name.ToString(), new ImageIdentifier(kingdom.Banner)));
            }

            InformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(
                new TextObject("Select Faction").ToString(),
                new TextObject("Select The Faction Type").ToString(),
                factionElements,
                true,
                1,
                new TextObject("Next").ToString(),
                new TextObject("Cancle").ToString(),
                (kingdom) =>
                {
                    getTroopRoster((Kingdom)kingdom.First().Identifier);
                    selectTroops();
                },
                null
                ), true);                    
        }

        private void selectTroops()
        {
            List<InquiryElement> troopElements = new List<InquiryElement>();

            foreach (CharacterObject troop in allTroops)
            {
                CharacterCode charCode = CharacterCode.CreateFrom(troop);
                troopElements.Add(new InquiryElement(troop, troop.Name.ToString(), new ImageIdentifier(charCode)));
            }

            InformationManager.ShowMultiSelectionInquiry(new MultiSelectionInquiryData(
                new TextObject("Select Faction").ToString(),
                new TextObject("Select The Faction Type").ToString(),
                troopElements,
                true,
                1,
                new TextObject("Next").ToString(),
                new TextObject("Cancle").ToString(),
                (troop) =>
                {
                    getCount((CharacterObject)troop.First().Identifier);
                },
                null
                ), true);
        }

        private void getCount(CharacterObject troop) {
            InformationManager.ShowTextInquiry(new TextInquiryData(
                new TextObject("Spawn Count").ToString()
              , new TextObject("Enter Amount to Spawn.").ToString()
              , true
              , true
              , new TextObject("Spawn").ToString()
              , new TextObject("Cancel").ToString()
              , (response) =>
              {
                  if (int.TryParse(response, out int troopCount))
                  {
                      MobileParty.MainParty.MemberRoster.AddToCounts(troop, troopCount);
                      return;
                  }
              }
              , null), true);
        }

        private void getTroopRoster(Kingdom faction) 
        {
            allTroops.Clear();

            var troops = CharacterObject.All.Where(t => t.Culture == faction.Culture && t.IsBasicTroop && !t.IsNotTransferableInPartyScreen && !t.IsHero).ToList();

            foreach(CharacterObject troop in troops)
            {
                allTroops.Add(troop);
                getTroopTrees(troop);
            }
            return;
        }

        public void getTroopTrees(CharacterObject troop)
        {
            var troopUpgrades = troop.UpgradeTargets?.ToList() ?? new List<CharacterObject> { };

            if (troopUpgrades.IsEmpty())
            {
                return;
            }
            else
            {
                allTroops.AddRange(troopUpgrades);
                foreach (var upgrade in troopUpgrades)
                {
                    getTroopTrees(upgrade);
                }
            }
        }
    }
}

