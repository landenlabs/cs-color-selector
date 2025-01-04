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
    /// Text box with a quick click bar.  
    /// 
    public partial class TextBar : UserControl
    {
        public TextBar()
        {
            InitializeComponent();
            this.fireChangeEvent = true;
        }

        public class EventBar : EventArgs
        {
            public EventBar(double p) { percent = p; }
            public double percent;
        }

        public event EventHandler Changed;
        public event EventHandler BarChanged;
        private bool fireChangeEvent;
        public double minValue, maxValue; 

        public int Value
        {
            get
            {
                if (this.textBox.Text.Length == 0)
                    return 0;

                try
                {
                    return int.Parse(this.textBox.Text);
                }
                catch
                {
                    return 0;
                }
            }

            set
            {
                string s = value.ToString();
                if (this.textBox.Text != s)
                {
                    this.fireChangeEvent = false;
                    this.textBox.Text = s;
                }
            }
        }

        public double ValueD
        {
            get
            {
                if (this.textBox.Text.Length == 0)
                    return 0;

                try
                {
                    return double.Parse(this.textBox.Text);
                }
                catch
                {
                    return 0;
                }
            }

            set
            {
                string s = value.ToString("G");
                if (this.textBox.Text != s)
                {
                    this.textBox.Text = s;
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Changed != null && this.fireChangeEvent)
                Changed(this, e);
            this.fireChangeEvent = true;
        }

        private void bar_MouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
            this.bar.BackColor = Color.Red;
            bar_MouseMove(sender, e);
        }

        private void bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                this.bar.ClientRectangle.Contains(e.Location))
            {
                double percent = (double)(e.X - this.bar.ClientRectangle.Left) /
                    this.bar.ClientRectangle.Width;

                if (this.BarChanged != null)
                    this.BarChanged(this, new EventBar(percent));
            }

        }

        private void bar_MouseLeave(object sender, EventArgs e)
        {
            this.bar.BackColor = Color.Black;
        }
    }
}
