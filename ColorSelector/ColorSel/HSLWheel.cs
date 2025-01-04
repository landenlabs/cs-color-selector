using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CSnamespace
{
    /// Author: Dennis Lang - 2009
    /// https://landenlabs.com/
    ///
    /// Draw a Hue/Saturation color wheel.
    /// 
    public partial class HSLWheel : System.Windows.Forms.Panel
    {
        public event EventHandler Changed;

        public HSLWheel()
        {
            InitializeComponent();
        }

        public HSLWheel(IContainer container)
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			DoubleBuffered = true;
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            BuildColorWheelImage(new Size(300, 300), 0.5);
            BuildSelectorImage();

            this.selectorPos = new Point(this.minDim, this.minDim);
        }

        public HslColor HSLColor
        {
            get { return this.hslColor; }
            set { SetHslColor(value, false); }
        }

        private void SetHslColor(HslColor value, bool fireChange)
        {
            if (this.hslColor != value)
            {
                this.hslColor = value;

                double angleR = hslColor.Hue * Math.PI / 180;
                double center = this.minDim / 2.0f;
                double radius = center * hslColor.Saturation;
                int x = (int)Math.Round(center + Math.Cos(angleR) * radius);
                int y = (int)Math.Round(center - Math.Sin(angleR) * radius);
                selectorPos = new Point(x, y);
                Refresh();

                if (Changed != null && fireChange)
                    Changed(this, EventArgs.Empty);
            }
        }

        protected void BuildSelectorImage()
        {
            int dim = 16;
            selectorImage = new Bitmap(dim, dim);
            Graphics g = Graphics.FromImage(selectorImage);

            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(Point.Empty, selectorImage.Size);

#if false
            GraphicsPath pth = new GraphicsPath();
            pth.AddEllipse(rect);

            PathGradientBrush brush = new PathGradientBrush(pth);
            brush.CenterColor = Color.Transparent;
            brush.SurroundColors = new Color[1] {Color.DarkGray};
            g.FillPie(brush, rect, 0, 360);
#else
            g.FillEllipse(Brushes.Transparent, rect);
            g.DrawEllipse(Pens.White, rect);
            rect.Inflate(-1, -1);
#endif
            g.DrawEllipse(Pens.Black, rect);
        }

        protected void BuildColorWheelImage(Size size, double lightness)
        {
            // Graphics g = this.CreateGraphics();
            int margin = 4;
            this.minDim = Math.Min(size.Width, size.Height);
            wheelImage = new Bitmap(minDim, minDim, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            this.minDim -= margin * 2;
            Rectangle rect = new Rectangle(new Point(margin, margin), new Size(this.minDim, this.minDim));

            {
                Graphics g = Graphics.FromImage(wheelImage);

                using (SolidBrush b = new SolidBrush(BackColor))
                {
                    g.FillRectangle(b, ClientRectangle);
                }

                float radius = minDim / 2.0f;
                PointF center = new PointF(radius+margin, radius+margin);

                List<PointF> path = new List<PointF>();
                List<Color> colors = new List<Color>();

                double angle = 0;
                double fullcircle = 360;
                double step = 5;
                while (angle < fullcircle)
                {
                    double angleR = angle * (Math.PI / 180);
                    double x = center.X + Math.Cos(angleR) * radius;
                    double y = center.Y - Math.Sin(angleR) * radius;
                    path.Add(new PointF((float)x, (float)y));
                    colors.Add(new HslColor(angle, 1, lightness).Color);
                    angle += step;
                }

                g.SmoothingMode = SmoothingMode.AntiAlias;
                PathGradientBrush brush = new PathGradientBrush(path.ToArray(), WrapMode.Clamp);
                brush.CenterPoint = center;
                brush.CenterColor = Color.White;
                brush.SurroundColors = colors.ToArray();

                g.FillPie(brush, rect, 0, 360);
                g.DrawEllipse(Pens.Black, rect);
                rect.Inflate(1, 1);
                g.DrawEllipse(Pens.Gray, rect);
            }

            this.BackgroundImageLayout = ImageLayout.Center;
            this.BackgroundImage = wheelImage;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            double hue = this.hslColor.Hue;
            int step = 1;
            if ((keyData & Keys.Control) == Keys.Control)
                step = 5;

            if ((keyData & Keys.Up) == Keys.Up)
                hue += step;

            if ((keyData & Keys.Down) == Keys.Down)
                hue -= step;

            if (hue >= 360)
                hue = 0;
            if (hue < 0)
                hue = 359;

            if (hue != this.hslColor.Hue)
            {
                SetHslColor(new HslColor(hue, hslColor.Saturation, hslColor.Lightness), true);
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        protected void SetSelector(Point mousePos)
        {
            Point pos = new Point(mousePos.X - ulPos.X, mousePos.Y - ulPos.Y);

            double radius = this.minDim / 2.0;
            double dx = Math.Abs(pos.X - radius);
            double dy = Math.Abs(pos.Y - radius);
            double dist = Math.Sqrt(dx * dx + dy * dy);
            if (dist <= radius && pos != this.selectorPos)
            {
                this.selectorPos = pos;

                double angleDeg = Math.Atan(dy / dx) * 180.0 / Math.PI;
                double saturation = dist / radius;

                if (pos.X < radius)
                    angleDeg = 180 - angleDeg;
                if (pos.Y > radius)
                    angleDeg = 360 - angleDeg;

                SetHslColor(new HslColor(angleDeg, saturation, this.hslColor.Lightness), true);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Size size = this.ClientRectangle.Size;
            this.minDim = Math.Min(size.Width, size.Height);
            this.ulPos = new Point((size.Width - this.minDim) / 2, (size.Height - this.minDim) / 2);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
                SetSelector(e.Location);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            if (e.Button == MouseButtons.Left)
                SetSelector(e.Location);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this != null && e != null)
            {
                base.OnPaint(e);

                if (this.selectorImage != null)
                {
                    int radius = this.selectorImage.Width / 2;
                    Point ulPt = new Point(this.selectorPos.X - radius, this.selectorPos.Y - radius);
                    ulPt.Offset(this.ulPos);
                    e.Graphics.DrawImageUnscaled(this.selectorImage, ulPt);
                }
            }
        }

        private Bitmap wheelImage;
        private Bitmap selectorImage;
        private int minDim;
        private Point ulPos;            // upper Left position of wheel box
        private HslColor hslColor;
        private Point selectorPos;
    }
}
