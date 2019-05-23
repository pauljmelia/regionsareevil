// -----------------------------------------------------------------------
// <copyright file="ClassifierProvider.cs" company="Equilogic (Pty) Ltd">
//     Copyright © Equilogic (Pty) Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RegionsAreEvil.Classifications
{
    using System.ComponentModel.Composition;

    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;

    internal sealed class ClassifierProvider
    {
        #region Internal Fields

        [Export]
        [Name(Constants.ActiveRegionClassificationTypeNames)]
        internal static ClassificationTypeDefinition ActiveRegionDefinition;

        [Export]
        [Name(Constants.InactiveRegionClassificationTypeNames)]
        internal static ClassificationTypeDefinition InactiveRegionDefinition;

        #endregion
    }
}