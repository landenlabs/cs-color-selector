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
    /// Three text boxes to update Hue, Saturation and Lightness color values.
    /// Includes a click bar under each box to quickly set/change the value.
    /// 
    public partial class HslText : UserControl
    {
        public HslText()
        {
            InitializeComponent();

            this.hueText.Changed += new EventHandler(HslChanged);
            this.saturationText.Changed += new EventHandler(HslChanged);
            this.lightnessText.Changed += new EventHandler(HslChanged);

            this.hueText.BarChanged += new EventHandler(BarChanged);
            this.saturationText.BarChanged += new EventHandler(BarChanged);
            this.lightnessText.BarChanged += new EventHandler(BarChanged);
        }

        public event EventHandler Changed;

        public HslColor HSLColor
        {
            get { return new HslColor(this.hueText.ValueD, this.saturationText.ValueD, this.lightnessText.ValueD); }
            set
            {
                if (this.HSLColor != value)
                {
                    this.hueText.ValueD = value.Hue;
                    this.saturationText.ValueD = value.Saturation;
                    this.lightnessText.ValueD = value.Lightness;
                }
            }
        }

        private void HslChanged(object sender, EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }

        private void BarChanged(object sender, EventArgs e)
        {
            TextBar textBar = (TextBar)sender;
            TextBar.EventBar eventBar = (TextBar.EventBar)e;

            textBar.ValueD = ((textBar.Name == this.hueText.Name) ? 
                360 : 1 ) * eventBar.percent;
            HslChanged(this, EventArgs.Empty);
        }
    }
}
