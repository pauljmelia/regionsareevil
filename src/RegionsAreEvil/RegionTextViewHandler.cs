﻿// -----------------------------------------------------------------------
// <copyright file="RegionTextViewHandler.cs" company="Equilogic (Pty) Ltd">
//     Copyright © Equilogic (Pty) Ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace RegionsAreEvil
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.Text.Editor;
    using Microsoft.VisualStudio.Text.Outlining;

    public class RegionTextViewHandler
    {
        #region Initialization

        private RegionTextViewHandler(IWpfTextView textView, IOutliningManagerService outliningManagerService)
        {
            _outliningManager = outliningManagerService.GetOutliningManager(textView);

            if (_outliningManager == null)
            {
                return;
            }

            _textView = textView;
            _outliningManager.RegionsCollapsed += OnRegionsCollapsed;
            _textView.Closed += OnClosed;
        }

        #endregion

        #region Public Methods

        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        public static void CreateHandler(IWpfTextView textView, IOutliningManagerService outliningManagerService)
        {
            new RegionTextViewHandler(textView, outliningManagerService);
        }

        #endregion

        #region Private Fields

        private IWpfTextView _textView;
        private IOutliningManager _outliningManager;

        #endregion

        #region Private Methods

        private void OnClosed(object sender, EventArgs e)
        {
            if (_outliningManager != null)
            {
                _outliningManager.RegionsCollapsed -= OnRegionsCollapsed;
            }

            if (_textView != null)
            {
                _textView.Closed -= OnClosed;
            }

            _textView = null;
            _outliningManager = null;
        }

        private void OnRegionsCollapsed(object sender, RegionsCollapsedEventArgs e)
        {
            foreach (var collapsed in e.CollapsedRegions)
            {
                try
                {
                    _outliningManager.Expand(collapsed);
                }
                catch (InvalidOperationException) { }
            }

            //_outliningManager.RegionsCollapsed -= OnRegionsCollapsed;
        }

        #endregion
    }
}