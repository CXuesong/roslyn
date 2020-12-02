﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis.Options;

namespace Microsoft.CodeAnalysis.Completion
{
    // NOTE: All options added to this class should have serializable values, as they are used in LSP.
    internal static class CompletionServiceOptions
    {
        /// <summary>
        /// Indicates if the completion is trigger by toggle the expander.
        /// </summary>
        public static readonly Option2<bool> IsExpandedCompletion
            = new(nameof(CompletionServiceOptions), nameof(IsExpandedCompletion), defaultValue: false);

        /// <summary>
        /// Indicates if the completion should be disallowed to add imports.
        /// </summary>
        public static readonly Option2<bool> DisallowAddingImports
            = new(nameof(CompletionServiceOptions), nameof(DisallowAddingImports), defaultValue: false);

        /// <summary>
        /// Timeout value used for time-boxing completion of unimported extension methods.
        /// Value less than 0 means no timebox; value == 0 means immediate timeout (for testing purpose)
        /// </summary>
        public static readonly Option2<int> TimeoutInMillisecondsForExtensionMethodImportCompletion
            = new(nameof(CompletionServiceOptions), nameof(TimeoutInMillisecondsForExtensionMethodImportCompletion), defaultValue: 500);

        /// <summary>
        /// Returns all completion service options.
        /// </summary>
        public static ImmutableArray<IOption> AllOptions { get; } = ImmutableArray.Create<IOption>(
            IsExpandedCompletion,
            DisallowAddingImports,
            TimeoutInMillisecondsForExtensionMethodImportCompletion);
    }
}
