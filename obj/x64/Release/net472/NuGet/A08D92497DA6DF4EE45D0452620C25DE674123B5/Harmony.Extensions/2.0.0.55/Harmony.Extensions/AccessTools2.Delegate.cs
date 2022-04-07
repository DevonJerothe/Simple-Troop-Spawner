// <auto-generated>
//   This code file has automatically been added by the "Harmony.Extensions" NuGet package (https://www.nuget.org/packages/Harmony.Extensions).
//   Please see https://github.com/BUTR/Harmony.Extensions for more information.
//
//   IMPORTANT:
//   DO NOT DELETE THIS FILE if you are using a "packages.config" file to manage your NuGet references.
//   Consider migrating to PackageReferences instead:
//   https://docs.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference
//   Migrating brings the following benefits:
//   * The "Harmony.Extensions" folder and the "AccessTools2.Delegate.cs" file don't appear in your project.
//   * The added file is immutable and can therefore not be modified by coincidence.
//   * Updating/Uninstalling the package will work flawlessly.
// </auto-generated>

#region License
// MIT License
//
// Copyright (c) Bannerlord's Unofficial Tools & Resources
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

#if !HARMONYEXTENSIONS_DISABLE
#nullable enable
#if !HARMONYEXTENSIONS_ENABLEWARNINGS
#pragma warning disable
#endif

namespace HarmonyLib.BUTR.Extensions
{
    using global::System;
    using global::System.Reflection;

    /// <summary>An extension of Harmony's helper class for reflection related functions</summary>
#if !HARMONYEXTENSIONS_PUBLIC
    internal
#else
    public
#endif
        static partial class AccessTools2
    {
        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, declared by <paramref name="type"/> or any of its base types,
        /// and then bind it to an instance type of <see cref="object"/>.
        /// </summary>
        /// <param name="type">The type where the method is declared.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDelegateObjectInstance<TDelegate>(Type type, string method) where TDelegate : Delegate
            => Method(type, method) is { } methodInfo ? GetDelegateObjectInstance<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, declared by <paramref name="type"/> or any of its base types,
        /// and then bind it to an instance type of <see cref="object"/>.
        /// Choose the overload with the given <paramref name="parameters"/> if not <see langword="null"/>
        /// and/or the generic arguments <paramref name="generics"/> if not <see langword="null"/>.
        /// </summary>
        /// <param name="type">The type from which to start searching for the method's definition.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <param name="parameters">The method's parameter types (when not <see langword="null"/>).</param>
        /// <param name="generics">The generic arguments of the method (when not <see langword="null"/>).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDelegateObjectInstance<TDelegate>(Type type, string method, Type[]? parameters = null, Type[]? generics = null) where TDelegate : Delegate
            => Method(type, method, parameters, generics) is { } methodInfo ? GetDelegateObjectInstance<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, directly declared by <paramref name="type"/>,
        /// and then bind it to an instance type of <see cref="object"/>.
        /// </summary>
        /// <param name="type">The type where the method is declared.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDeclaredDelegateObjectInstance<TDelegate>(Type type, string method) where TDelegate : Delegate
            => DeclaredMethod(type, method) is { } methodInfo ? GetDelegateObjectInstance<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, directly declared by <paramref name="type"/>,
        /// and then bind it to an instance type of <see cref="object"/>.
        /// Choose the overload with the given <paramref name="parameters"/> if not <see langword="null"/>
        /// and/or the generic arguments <paramref name="generics"/> if not <see langword="null"/>.
        /// </summary>
        /// <param name="type">The type from which to start searching for the method's definition.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <param name="parameters">The method's parameter types (when not <see langword="null"/>).</param>
        /// <param name="generics">The generic arguments of the method (when not <see langword="null"/>).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDeclaredDelegateObjectInstance<TDelegate>(Type type, string method, Type[]? parameters = null, Type[]? generics = null) where TDelegate : Delegate
            => DeclaredMethod(type, method, parameters, generics) is { } methodInfo ? GetDelegateObjectInstance<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, declared by <paramref name="type"/> or any of its base types.
        /// </summary>
        /// <param name="type">The type from which to start searching for the method's definition.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDelegate<TDelegate>(Type type, string method) where TDelegate : Delegate
            => Method(type, method) is { } methodInfo ? GetDelegate<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, declared by <paramref name="type"/>
        /// or any of its base types.
        /// Choose the overload with the given <paramref name="parameters"/> if not <see langword="null"/>
        /// and/or the generic arguments <paramref name="generics"/> if not <see langword="null"/>.
        /// </summary>
        /// <param name="type">The type from which to start searching for the method's definition.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <param name="parameters">The method's parameter types (when not <see langword="null"/>).</param>
        /// <param name="generics">The generic arguments of the method (when not <see langword="null"/>).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDelegate<TDelegate>(Type type, string method, Type[]? parameters = null, Type[]? generics = null) where TDelegate : Delegate
            => Method(type, method, parameters, generics) is { } methodInfo ? GetDelegate<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, directly declared by <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type where the method is declared.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDeclaredDelegate<TDelegate>(Type type, string method) where TDelegate : Delegate
            => DeclaredMethod(type, method) is { } methodInfo ? GetDelegate<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, directly declared by <paramref name="type"/>.
        /// Choose the overload with the given <paramref name="parameters"/> if not <see langword="null"/>
        /// and/or the generic arguments <paramref name="generics"/> if not <see langword="null"/>.
        /// </summary>
        /// <param name="type">The type where the method is declared.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <param name="parameters">The method's parameter types (when not <see langword="null"/>).</param>
        /// <param name="generics">The generic arguments of the method (when not <see langword="null"/>).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="type"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDeclaredDelegate<TDelegate>(Type type, string method, Type[]? parameters = null, Type[]? generics = null) where TDelegate : Delegate
            => DeclaredMethod(type, method, parameters, generics) is { } methodInfo ? GetDelegate<TDelegate>(methodInfo) : null;

        /// <summary>
        /// Get a delegate for an instance method declared by <paramref name="instance"/>'s type or any of its base types.
        /// </summary>
        /// <param name="instance">The instance for which the method is defined.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="instance"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDelegate<TDelegate, TInstance>(TInstance instance, string method) where TDelegate : Delegate
            => instance is not null && Method(instance.GetType(), method) is { } methodInfo ? GetDelegate<TDelegate, TInstance>(instance, methodInfo) : null;

        /// <summary>
        /// Get a delegate for a method named <paramref name="method"/>, declared by <paramref name="instance"/>'s type or any of its base types.
        /// Choose the overload with the given <paramref name="parameters"/> if not <see langword="null"/>
        /// and/or the generic arguments <paramref name="generics"/> if not <see langword="null"/>.
        /// </summary>
        /// <param name="instance">The instance for which the method is defined.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <param name="parameters">The method's parameter types (when not <see langword="null"/>).</param>
        /// <param name="generics">The generic arguments of the method (when not <see langword="null"/>).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="instance"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDelegate<TDelegate, TInstance>(TInstance instance, string method, Type[]? parameters = null, Type[]? generics = null) where TDelegate : Delegate
            => instance is not null && Method(instance.GetType(), method, parameters, generics) is { } methodInfo ? GetDelegate<TDelegate, TInstance>(instance, methodInfo) : null;

        /// <summary>
        /// Get a delegate for an instance method directly declared by <paramref name="instance"/>'s type.
        /// </summary>
        /// <param name="instance">The instance for which the method is defined.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="instance"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDeclaredDelegate<TDelegate, TInstance>(TInstance instance, string method) where TDelegate : Delegate
            => instance is not null && DeclaredMethod(instance.GetType(), method) is { } methodInfo ? GetDelegate<TDelegate, TInstance>(instance, methodInfo) : null;

        /// <summary>
        /// Get a delegate for an instance method named <paramref name="method"/>, directly declared by <paramref name="instance"/>'s type.
        /// Choose the overload with the given <paramref name="parameters"/> if not <see langword="null"/>
        /// and/or the generic arguments <paramref name="generics"/> if not <see langword="null"/>.
        /// </summary>
        /// <param name="instance">The instance for which the method is defined.</param>
        /// <param name="method">The name of the method (case sensitive).</param>
        /// <param name="parameters">The method's parameter types (when not <see langword="null"/>).</param>
        /// <param name="generics">The generic arguments of the method (when not <see langword="null"/>).</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="instance"/> or <paramref name="method"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDeclaredDelegate<TDelegate, TInstance>(TInstance instance, string method, Type[]? parameters = null, Type[]? generics = null) where TDelegate : Delegate
            => instance is not null && DeclaredMethod(instance.GetType(), method, parameters, generics) is { } methodInfo ? GetDelegate<TDelegate, TInstance>(instance, methodInfo) : null ;

        /// <summary>
        /// Get a delegate for an instance method described by <paramref name="methodInfo"/> and bound to <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">The instance for which the method is defined.</param>
        /// <param name="methodInfo">The method's <see cref="MethodInfo"/>.</param>
        /// <returns>
        /// A delegate or <see langword="null"/> when <paramref name="instance"/> or <paramref name="methodInfo"/>
        /// is <see langword="null"/> or when the method cannot be found.
        /// </returns>
        public static TDelegate? GetDelegate<TDelegate, TInstance>(TInstance instance, MethodInfo methodInfo) where TDelegate : Delegate
            => GetDelegate<TDelegate>(instance, methodInfo);


        public static TDelegate? GetDelegate<TDelegate>(object? instance, Type type, string method, Type[]? parameters = null, Type[]? generics = null) where TDelegate : Delegate
            => Method(type, method, parameters, generics) is { } methodInfo ? GetDelegate<TDelegate>(instance, methodInfo) : null;
    }
}

#pragma warning restore
#nullable restore
#endif // HARMONYEXTENSIONS_DISABLE