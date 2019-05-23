// -----------------------------------------------------------------------
// <copyright file="RegionTag.cs" company="Equilogic (Pty) Ltd">
//     Copyright © Equilogic (Pty) Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RegionsAreEvil.Tags
{
    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Text.Tagging;

    public sealed class RegionTag : ClassificationTag
    {
        #region Initialization

        public RegionTag(IClassificationType type) : base(type) { }

        #endregion
    }
}