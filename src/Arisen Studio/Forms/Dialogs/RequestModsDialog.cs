﻿using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using DevExpress.XtraEditors;
using Microsoft.Web.WebView2.Core;
using ArisenStudio.Constants;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using ArisenStudio.Forms.Windows;

namespace ArisenStudio.Forms.Dialogs
{
    public partial class RequestModsDialog : ToolbarForm
    {
        public RequestModsDialog()
        {
            InitializeComponent();
        }

        private string FormUrl { get; } = Urls.FormSubmitMods;

        private Timer WebPageTimer { get; } = new();

        private void RequestModsDialog_Load(object sender, EventArgs e)
        {
            Size = new System.Drawing.Size(Width, MainWindow.Window.Height - 40);
            CenterToParent();

            WebPageTimer.Tick += WebPageTimer_Tick;
            WebPageTimer.Interval = 15000;
            WebPageTimer.Enabled = true;
            WebPageTimer.Start();
        }

        private void WebPageTimer_Tick(object sender, EventArgs e)
        {
            WebPageTimer.Enabled = false;

            if (XtraMessageBox.Show(this,
                "It looks like the form is taking a while to load. Would you like to open it in your web browser?", 
                "Open Browser",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _ = Process.Start(FormUrl);
            }
        }

        private void ButtonRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            WebView.Source = new Uri(FormUrl);
        }

        private void ButtonOpenLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            _ = Process.Start(Urls.RequestForm);
        }

        private void WebView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            ProgressPanel.Visible = true;
        }

        private void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            ProgressPanel.Visible = false;

            if (e.IsSuccess)
            {
                WebPageTimer.Enabled = false;
            }
        }
    }
}