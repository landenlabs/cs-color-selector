using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CSnamespace;

namespace CSnamespace
{
    /// Author: Dennis Lang - 2009
    /// https://landenlabs.com/
    ///
    /// <summary>
    /// Color Selector Dialog
    ///   Provides HSL wheel, RGB and HSL text boxes, and Lightness slider
    ///   Plus history of last few picks.
    ///   History save/load to/from Registry
    /// </summary>
    public partial class ColorSelDialog : Form
    {
        public event EventHandler Changed;

        public ColorSelDialog()
        {
            InitializeComponent();

            this.wheel.Changed += new EventHandler(WheelChanged);
            this.rgbText.Changed += new EventHandler(RgbTextChanged);
            this.hslText.Changed += new EventHandler(HslTextChanged);
            this.colorBar.Changed += new EventHandler(ColorBarChanged);
            this.colorBoxes.Changed += new EventHandler(ColorBoxesChanged);

            string appName = Application.ProductName;
            this.regKey =
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\" + appName + @"\ColorSelDialog");
            this.LoadFromRegistry();
        }

        private string colorTag = "color";
        private string historyTag = "history";

        private void LoadFromRegistry()
        {
            string colorStr = (string)this.regKey.GetValue(colorTag, Color.Transparent.ToArgb().ToString());
            Color c = Color.FromArgb(int.Parse(colorStr));
            this.SetHslColor(new HslColor(c), true);

            this.colorBoxes.LoadFromRegistry(this.regKey, historyTag);
        }

        private void SaveToRegistry()
        {
            this.regKey.SetValue(colorTag, this.hslColor.Color.ToArgb().ToString());
            this.colorBoxes.SaveToRegistry(this.regKey, historyTag);
        }

        /// <summary>
        /// Get/Set HSL color
        /// </summary>
        public HslColor HSLColor
        {
            get { return this.hslColor; }
            set { SetHslColor(value, false); }
        }

        /// <summary>
        /// Get/Set Color
        /// </summary>
        public Color Color
        {
            get { return this.hslColor.Color; }
            set { SetHslColor(new HslColor(value), false); }
        }

        private void SetHslColor(HslColor value, bool fireChange)
        {
            if (orgHslColor == HslColor.Empty)
                orgHslColor = value;

            if (value != this.hslColor)
            {
                this.hslColor = value;

                if (this.Changed != null && fireChange)
                    this.Changed(this, EventArgs.Empty);

                this.wheel.HSLColor = value;
                this.hslText.HSLColor = value;
                this.rgbText.Color = value.Color;
                
                // Lightness colorBar requires mid lightness color value.
                this.colorBar.Percent = value.Lightness;
                value.Lightness = 0.5;
                this.colorBar.Color = value.Color;
            }
        }

        private void WheelChanged(object o, EventArgs e)
        {
            SetHslColor(wheel.HSLColor, true);
        }

        private void RgbTextChanged(object o, EventArgs e)
        {
            SetHslColor(new HslColor(this.rgbText.Color), true);
        }

        private void HslTextChanged(object o, EventArgs e)
        {
            SetHslColor(this.hslText.HSLColor, true);
        }

        private void ColorBarChanged(object o, EventArgs e)
        {
            if (this.hslColor.Lightness != this.colorBar.Percent)
            {
                SetHslColor(new HslColor(
                    this.hslColor.Hue, this.hslColor.Saturation, this.colorBar.Percent), true);
            }
        }

        private void ColorBoxesChanged(object o, EventArgs e)
        {
            ColorBoxes.EventColorBoxes ec = (ColorBoxes.EventColorBoxes)e;
            SetHslColor(new HslColor(this.colorBoxes.GetColor(ec.colorIndex)), true);
        }

        private void okayBtn_Click(object sender, EventArgs e)
        {
            this.colorBoxes.Add(this.hslColor.Color);

            this.SaveToRegistry();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.SetHslColor(this.orgHslColor, true);
            this.Close();
        }

        private HslColor hslColor;
        private HslColor orgHslColor;
        private Microsoft.Win32.RegistryKey regKey;

    }
}
