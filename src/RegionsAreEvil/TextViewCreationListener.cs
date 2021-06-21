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
        private readonly IOutliningManagerService _outliningManagerService;

        #endregion

        [ImportingConstructor]
        public TextViewCreationListener(IOutliningManagerService outliningManagerService)
        {
            _outliningManagerService = outliningManagerService;
        }

        #region  IWpfTextViewCreationListener Members

        #region Interface Implementation: IWpfTextViewCreationListener

        public void TextViewCreated(IWpfTextView textView)
        {
            if (textView == null || _outliningManagerService == null)
            {
                return;
            }

            RegionTextViewHandler.CreateHandler(textView, _outliningManagerService);
        }

        #endregion

        #endregion
    }
}