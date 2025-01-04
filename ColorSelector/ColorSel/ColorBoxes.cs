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
    /// Draw a list of color boxes to manage historical color choices.
    /// 
    /// Save/Load to/from registry.
    /// 
    public partial class ColorBoxes : UserControl
    {
        public ColorBoxes()
        {
            InitializeComponent();

            int nColors = 20;
            this.colors = new Color[nColors];
            for (int n = 0; n < nColors; n++)
                this.colors[n] = Color.Transparent;

            BuildBgImage(this.ClientRectangle.Size);
        }

        public event EventHandler Changed;

        public class EventColorBoxes : EventArgs
        {
            public EventColorBoxes(int index)
            {
                this.colorIndex = index;
            }

            public int colorIndex;
        }

        public void Add(Color color)
        {
            if (boxes == null || colors == null || viewNcolors == 0)
                return;

            // Don't add if we already have it.
            foreach (Color c in this.colors)
                if (c == color)
                    return;

            nextIndex %= viewNcolors;
            colors[nextIndex] = color;
            nextIndex = (nextIndex + 1) % viewNcolors;
        }

        public Color GetColor(int index)
        {
            return this.colors[index];
        }
       
        public void SaveToRegistry(Microsoft.Win32.RegistryKey key,  string tag)
        {
            string s = "";
            foreach (Color c in this.colors)
                if (c != Color.Transparent)
                    s += ((s.Length != 0) ? "," : "") + c.ToArgb().ToString();

            key.SetValue(tag, s);
        }

        public void LoadFromRegistry(Microsoft.Win32.RegistryKey key,  string tag)
        {
            string[] colorStr = ((string)key.GetValue(tag, "")).Split(',');
            this.nextIndex = 0;

            for (int i = 0; i != colorStr.Length; i++)
            {
                try
                {
                    this.colors[nextIndex] = Color.FromArgb(int.Parse(colorStr[i]));
                }
                catch
                {
                    this.colors[nextIndex] = Color.Transparent;
                }

                nextIndex = (nextIndex + 1) % this.colors.Length;
            }

            BuildBgImage(this.ClientRectangle.Size);
        }

        protected void BuildBgImage(Size size)
        {
            Bitmap image = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(image);
            Rectangle rect = new Rectangle(Point.Empty, size);

            using (SolidBrush b = new SolidBrush(BackColor))
            {
                g.FillRectangle(b, ClientRectangle);
            }

            dim = size.Height - (2 * margin);
            this.viewNcolors = (size.Width - margin) / (dim + margin);

            boxes = new Rectangle[this.viewNcolors];

            // Build boxes
            for (int n = 0; n < this.viewNcolors; n++)
            {
                Rectangle bRect = new Rectangle(2 + n * (dim + margin), 2, dim, dim);
                Rectangle wRect = new Rectangle(0, 0, bRect.Width - 1, bRect.Height - 1);

                g.DrawRectangle(Pens.LightGray, wRect);
                g.DrawRectangle(Pens.Black, bRect);

                bRect.Inflate(-1, -1);
                boxes[n] = bRect;
            }

            // Draw boxes
            SolidBrush brush = new SolidBrush(Color.Blue);
            for (int n = 0; n < this.viewNcolors; n++)
            {
                if (colors != null && n < colors.Length)
                    brush.Color = colors[n];
                g.FillRectangle(brush, boxes[n]);
            }

            this.BackgroundImage = image;
            this.BackgroundImageLayout = ImageLayout.None;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.BuildBgImage(this.ClientRectangle.Size);
            this.Refresh();
        }

        private void ColorBoxes_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ClientRectangle.Contains(e.Location))
            {
                int selectedBox = (e.X - this.margin) / (this.dim + this.margin);
                if (selectedBox >= 0 && selectedBox < this.viewNcolors)
                {
                    if (this.Changed != null)
                        this.Changed(this, new EventColorBoxes(selectedBox));
                }
            }
        }

        private Rectangle[] boxes;
        private Color[] colors;
        private int viewNcolors;
        private int nextIndex;
        private int dim;
        private int margin = 4;
    }
}
