using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSnamespace
{
    /// <summary>
    /// Author: Dennis Lang - 2009
    /// https://landenlabs.com/
    /// 
    /// Demo HSL/Color selector dialog.
    /// 
    /// </summary>
    public partial class ColorSelectorDemo : Form
    {
        public ColorSelectorDemo()
        {
            InitializeComponent();
        }

        private void selColorBtn_Click(object sender, EventArgs e)
        {
            ColorSelDialog colorSel = new ColorSelDialog();
            colorSel.Color = selColorBtn.BackColor;
            if (colorSel.ShowDialog() == DialogResult.OK)
            {
                selColorBtn.BackColor = colorSel.Color;
            }
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(link.Text);
        }
    }
}
