namespace CSnamespace
{
    partial class ColorSelDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSelDialog));
            this.okayBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.colorBoxes = new CSnamespace.ColorBoxes();
            this.colorBar = new CSnamespace.ColorBar(this.components);
            this.rgbText = new CSnamespace.RgbText();
            this.hslText = new CSnamespace.HslText();
            this.wheel = new CSnamespace.HSLWheel(this.components);
            this.SuspendLayout();
            // 
            // okayBtn
            // 
            this.okayBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okayBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okayBtn.Location = new System.Drawing.Point(365, 267);
            this.okayBtn.Name = "okayBtn";
            this.okayBtn.Size = new System.Drawing.Size(75, 23);
            this.okayBtn.TabIndex = 1;
            this.okayBtn.Text = "Okay";
            this.okayBtn.UseVisualStyleBackColor = true;
            this.okayBtn.Click += new System.EventHandler(this.okayBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(446, 267);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // colorBoxes
            // 
            this.colorBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colorBoxes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("colorBoxes.BackgroundImage")));
            this.colorBoxes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.colorBoxes.Location = new System.Drawing.Point(12, 260);
            this.colorBoxes.Name = "colorBoxes";
            this.colorBoxes.Size = new System.Drawing.Size(240, 30);
            this.colorBoxes.TabIndex = 0;
            // 
            // colorBar
            // 
            this.colorBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colorBar.BackColor = System.Drawing.Color.White;
            this.colorBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.colorBar.Color = System.Drawing.Color.Empty;
            this.colorBar.Location = new System.Drawing.Point(465, 12);
            this.colorBar.Name = "colorBar";
            this.colorBar.Percent = 0;
            this.colorBar.Size = new System.Drawing.Size(55, 240);
            this.colorBar.TabIndex = 4;
            // 
            // rgbText
            // 
            this.rgbText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rgbText.AutoSize = true;
            this.rgbText.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.rgbText.Location = new System.Drawing.Point(306, 12);
            this.rgbText.Name = "rgbText";
            this.rgbText.Size = new System.Drawing.Size(150, 90);
            this.rgbText.TabIndex = 0;
            // 
            // hslText
            // 
            this.hslText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hslText.AutoSize = true;
            this.hslText.Location = new System.Drawing.Point(306, 120);
            this.hslText.Name = "hslText";
            this.hslText.Size = new System.Drawing.Size(150, 90);
            this.hslText.TabIndex = 1;
            // 
            // wheel
            // 
            this.wheel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wheel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.wheel.BackColor = System.Drawing.Color.Transparent;
            this.wheel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.wheel.Location = new System.Drawing.Point(12, 12);
            this.wheel.Name = "wheel";
            this.wheel.Size = new System.Drawing.Size(240, 240);
            this.wheel.TabIndex = 3;
            // 
            // ColorSelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 302);
            this.Controls.Add(this.colorBoxes);
            this.Controls.Add(this.colorBar);
            this.Controls.Add(this.rgbText);
            this.Controls.Add(this.hslText);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okayBtn);
            this.Controls.Add(this.wheel);
            this.Name = "ColorSelDialog";
            this.Text = "Color Selector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HSLWheel wheel;
        private System.Windows.Forms.Button okayBtn;
        private System.Windows.Forms.Button cancelBtn;
        private RgbText rgbText;
        private HslText hslText;
        private ColorBar colorBar;
        private ColorBoxes colorBoxes;
    }
}