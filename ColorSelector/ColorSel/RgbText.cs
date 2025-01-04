using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSnamespace
{
    /// Author: Dennis Lang - 2009
    /// https://landenlabs.com/
    ///
    /// Three text boxes to update Red, Green and Blue color values.
    /// Includes a click bar under each box to quickly set/change the value.
    /// 
    public partial class RgbText : UserControl
    {
        public RgbText()
        {
            InitializeComponent();

            this.redText.Changed += new EventHandler(RgbChanged);
            this.greenText.Changed += new EventHandler(RgbChanged);
            this.blueText.Changed += new EventHandler(RgbChanged);

            this.redText.BarChanged += new EventHandler(BarChanged);
            this.greenText.BarChanged += new EventHandler(BarChanged);
            this.blueText.BarChanged += new EventHandler(BarChanged);
        }

        public event EventHandler Changed;

        public Color Color
        {
            get { return Color.FromArgb(255, this.redText.Value, this.greenText.Value, this.blueText.Value); }
            set
            {
                if (this.Color != value)
                {
                    this.redText.Value = value.R;
                    this.greenText.Value = value.G;
                    this.blueText.Value = value.B;
                }
            }
        }

        private void RgbChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        private void BarChanged(object sender, EventArgs e)
        {
            TextBar textBar = (TextBar)sender;
            TextBar.EventBar eventBar = (TextBar.EventBar)e;

            textBar.Value = (int)(255 * eventBar.percent);
            RgbChanged(this, EventArgs.Empty);
        }
    }
}
