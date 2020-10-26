﻿using System;
using System.IO;
using DarkUI.Forms;

namespace ModioX.Forms
{
    public partial class InputDialog : DarkForm
    {
        public InputDialog()
        {
            InitializeComponent();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            try
            {
                if (Path.HasExtension(TextBoxName.Text))
                {
                    TextBoxName.Select(0, TextBoxName.Text.IndexOf(Path.GetExtension(TextBoxName.Text)));
                }
            }
            catch { }
        }

        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            ButtonOK.Enabled = !string.IsNullOrWhiteSpace(TextBoxName.Text);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}