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
    /// <summary>
    ///  Vertical color gradient bar. 
    ///  Set bot, mid and  top colors
    ///  Set/Get percent value
    /// </summary>
    public partial class ColorBar : System.Windows.Forms.Panel
    {
        public event EventHandler Changed;

        public ColorBar()
        {
            InitializeComponent();
        }

        public ColorBar(IContainer container)
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			DoubleBuffered = true;
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            BuildSelectorImage();
            SetRange(Color.Black, Color.White);
            this.percent = 0.5f;
            this.Color = Color.Red;
        }

        public void SetRange(Color inBotColor, Color inTopColor)
        {
            this.botColor = inBotColor;
            this.topColor = inTopColor;
        }

        public Color Color
        {
            get { return this.midColor; }
            set
            {
                this.midColor = value;
                BuildColorBarImage();
            }
        }

        public double Percent
        {
            get { return percent; }
            set { SetPercent(value, false); }
        }

        private void SetPercent(double value, bool fireChange)
        {
            if (this.percent != value)
            {
                this.percent = value;
                this.Refresh();         // move color selector
                if (fireChange && this.Changed != null)
                    this.Changed(this, EventArgs.Empty);
            }
        }

        protected void BuildSelectorImage()
        {
            int h = 10;
            selectorImage = new Bitmap(this.Width, h);
            Graphics g = Graphics.FromImage(selectorImage);
            Rectangle rect = new Rectangle(Point.Empty, selectorImage.Size);
            g.FillRectangle(Brushes.Transparent, rect);

            g.FillPie(Brushes.Gray, -rect.Width / 4, 0, rect.Width / 2, rect.Height, -90, 180);
            g.FillPie(Brushes.Gray, rect.Width* 3 / 4, 0, rect.Width / 2, rect.Height, 90, 180);

            rect.Inflate(-1, -1);
            g.DrawRectangle(Pens.Black, rect);
            rect.Inflate(-1, -1);
            g.DrawRectangle(Pens.White, rect);
        }

        protected void BuildColorBarImage()
		{
            Rectangle rect = this.ClientRectangle;
            int minDim = Math.Min(rect.Width, rect.Height);

            if (barImage == null || rect.Width != barImage.Width || rect.Height != barImage.Height)
                barImage = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(barImage);

            using (SolidBrush b = new SolidBrush(BackColor))
            {
                g.FillRectangle(b, ClientRectangle);
            }

#if true  
            // Draw white to black gradient with pure color in the middle 
            List<PointF> path = new List<PointF>();
		    List<Color> colors = new List<Color>();

            // Create 6 points to edge rectangle
            path.Add(new PointF(0, 0f));
            path.Add(new PointF(Width, 0f));
            path.Add(new PointF(Width, rect.Height / 2f));
            path.Add(new PointF(rect.Width, rect.Height));
            path.Add(new PointF(0, rect.Height));
            path.Add(new PointF(0, rect.Height / 2f));

            // 6 colors to mark gradient.
            colors.Add(this.topColor);
            colors.Add(this.topColor);
            colors.Add(this.midColor);
            colors.Add(this.botColor);
            colors.Add(this.botColor);
            colors.Add(midColor);

            g.SmoothingMode = SmoothingMode.HighSpeed;
            PathGradientBrush brush = new PathGradientBrush(path.ToArray(), WrapMode.Clamp);
            brush.CenterPoint = new PointF(rect.Width / 2f, rect.Height / 2f);
			brush.CenterColor = midColor;
			brush.SurroundColors = colors.ToArray();
#else
            float angle = 270;
            LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, angle, false);
#endif

            g.FillRectangle(brush, rect);
            g.DrawRectangle(Pens.Black, rect);
            rect.Inflate(-2, -2);
            g.DrawRectangle(Pens.White, rect);
            g.Flush();

            this.BackgroundImage = barImage;
            this.Refresh();
		}

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (barImage == null || barImage.Height < this.Height)
            {
                BuildColorBarImage();
                BuildSelectorImage();
            }
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

        protected void SetSelector(Point pos)
        {
            Rectangle rect = this.ClientRectangle;
            if (rect.Contains(pos))
            {
                // Vertical orientation.
                int p = rect.Height - pos.Y;
                SetPercent((float)p / rect.Height, true);
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            int step = 0;
            if ((keyData & Keys.Up) == Keys.Up)
                step = 1;
            if ((keyData & Keys.Down) == Keys.Down)
                step = -1;
            if ((keyData & Keys.Control) == Keys.Control)
                step *= 5;

            if (step != 0)
            {
                SetPercent(Math.Min(1f, Math.Max(0f, this.percent + step / 100f)), true);
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this != null && e != null)
            {
                base.OnPaint(e);

                if (this.selectorImage != null)
                {
                    // Draw selector
                    Rectangle rect = this.ClientRectangle;
                    rect.Y = (int)(rect.Height * (1.0 - percent));
                    rect.Height = 0;
                    rect.Inflate(0, this.selectorImage.Height/2);
                    e.Graphics.DrawImage(this.selectorImage, rect);
                }
            }
        }


        #region ==== Private data

        private Bitmap barImage;
        private Bitmap selectorImage;
        private Color botColor, midColor, topColor;
        private double percent;

        #endregion 

    }
}
