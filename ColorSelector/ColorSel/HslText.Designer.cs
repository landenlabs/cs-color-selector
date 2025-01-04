namespace CSnamespace
{
    partial class HslText
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.table3Row = new System.Windows.Forms.TableLayoutPanel();
            this.hueText = new CSnamespace.TextBar();
            this.saturationText = new CSnamespace.TextBar();
            this.lightnessText = new CSnamespace.TextBar();
            this.table3Row.SuspendLayout();
            this.SuspendLayout();
            // 
            // table3Row
            // 
            this.table3Row.ColumnCount = 1;
            this.table3Row.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table3Row.Controls.Add(this.hueText, 0, 0);
            this.table3Row.Controls.Add(this.saturationText, 0, 1);
            this.table3Row.Controls.Add(this.lightnessText, 0, 2);
            this.table3Row.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table3Row.Location = new System.Drawing.Point(0, 0);
            this.table3Row.Name = "table3Row";
            this.table3Row.RowCount = 3;
            this.table3Row.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table3Row.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table3Row.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table3Row.Size = new System.Drawing.Size(150, 90);
            this.table3Row.TabIndex = 0;
            // 
            // hueText
            // 
            this.hueText.Location = new System.Drawing.Point(0, 0);
            this.hueText.Margin = new System.Windows.Forms.Padding(0);
            this.hueText.Name = "hueText";
            this.hueText.label.Text = "Hue:";
            this.hueText.Size = new System.Drawing.Size(150, 30);
            this.hueText.TabIndex = 0;
            // 
            // saturationText
            // 
            this.saturationText.Location = new System.Drawing.Point(0, 30);
            this.saturationText.Margin = new System.Windows.Forms.Padding(0);
            this.saturationText.Name = "saturationText";
            this.saturationText.label.Text = "Sat:";
            this.saturationText.Size = new System.Drawing.Size(150, 30);
            this.saturationText.TabIndex = 1;
            // 
            // lightnessText
            // 
            this.lightnessText.Location = new System.Drawing.Point(0, 60);
            this.lightnessText.Margin = new System.Windows.Forms.Padding(0);
            this.lightnessText.Name = "lightnessText";
            this.lightnessText.label.Text = "Light:";
            this.lightnessText.Size = new System.Drawing.Size(150, 30);
            this.lightnessText.TabIndex = 2;
            // 
            // HslText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.table3Row);
            this.Name = "HslText";
            this.Size = new System.Drawing.Size(150, 90);
            this.table3Row.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table3Row;
        private TextBar hueText;
        private TextBar saturationText;
        private TextBar lightnessText;
    }
}
