// -----------------------------------------------------------------------
// <copyright file="ActiveRegionClassification.cs" company="Equilogic (Pty) Ltd">
//     Copyright © Equilogic (Pty) Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RegionsAreEvil.Classifications
{
    using System.ComponentModel.Composition;
    using System.Windows.Media;

    using Microsoft.VisualStudio.Text.Classification;
    using Microsoft.VisualStudio.Utilities;

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = Constants.ActiveRegionClassificationTypeNames)]
    [Name(Constants.ActiveRegionName)]
    [DisplayName(Constants.ActiveRegionName)]
    [UserVisible(true)]
    [Order(After = Constants.OrderAfterPriority, Before = Constants.OrderBeforePriority)]
    internal sealed class ActiveRegionClassification : ClassificationFormatDefinition
    {
        #region Initialization

        // Methods
        public ActiveRegionClassification()
        {
            ForegroundColor = Colors.DarkGray;
        }

        #endregion
    }
}