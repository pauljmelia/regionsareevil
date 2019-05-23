// -----------------------------------------------------------------------
// <copyright file="TextViewCreationListener.cs" company="Equilogic (Pty) Ltd">
//     Copyright © Equilogic (Pty) Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RegionsAreEvil
{
    using System.ComponentModel.Composition;

    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Outlining;
    using Microsoft.VisualStudio.Utilities;

    [TextViewRole(Constants.TextViewRole)]
    [ContentType(Constants.CSharpContentType)]
    [ContentType(Constants.BasicContentType)]
    [Export(typeof(IWpfTextViewCreationListener))]
    public class TextViewCreationListener : IWpfTextViewCreationListener
    {
        #region Public Properties

        [Import(typeof(IOutliningManagerService))]
        public IOutliningManagerService OutliningManagerService { get; set; }

        #endregion

        #region  IWpfTextViewCreationListener Members

        #region Interface Implementation: IWpfTextViewCreationListener

        public void TextViewCreated(IWpfTextView textView)
        {
            if (textView == null || OutliningManagerService == null)
            {
                return;
            }

            RegionTextViewHandler.CreateHandler(textView, OutliningManagerService);
        }

        #endregion

        #endregion
    }
}