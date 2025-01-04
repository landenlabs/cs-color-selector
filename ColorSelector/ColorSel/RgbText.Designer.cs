namespace CSnamespace
{
    partial class RgbText
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
            this.redText = new CSnamespace.TextBar();
            this.greenText = new CSnamespace.TextBar();
            this.blueText = new CSnamespace.TextBar();
            this.table3Row.SuspendLayout();
            this.SuspendLayout();
            // 
            // table3Row
            // 
            this.table3Row.ColumnCount = 1;
            this.table3Row.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table3Row.Controls.Add(this.redText, 0, 0);
            this.table3Row.Controls.Add(this.greenText, 0, 1);
            this.table3Row.Controls.Add(this.blueText, 0, 2);
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
            // redText
            // 
            this.redText.Location = new System.Drawing.Point(0, 0);
            this.redText.Margin = new System.Windows.Forms.Padding(0);
            this.redText.Name = "redText";
            this.redText.label.Text = "Red:";
            this.redText.Size = new System.Drawing.Size(150, 30);
            this.redText.TabIndex = 0;
            // 
            // greenText
            // 
            this.greenText.Location = new System.Drawing.Point(0, 30);
            this.greenText.Margin = new System.Windows.Forms.Padding(0);
            this.greenText.Name = "greenText";
            this.greenText.label.Text = "Green:";
            this.greenText.Size = new System.Drawing.Size(150, 30);
            this.greenText.TabIndex = 1;
            // 
            // blueText
            // 
            this.blueText.Location = new System.Drawing.Point(0, 60);
            this.blueText.Margin = new System.Windows.Forms.Padding(0);
            this.blueText.Name = "blueText";
            this.blueText.label.Text = "Blue:";
            this.blueText.Size = new System.Drawing.Size(150, 30);
            this.blueText.TabIndex = 2;
            // 
            // RgbText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.table3Row);
            this.Name = "RgbText";
            this.Size = new System.Drawing.Size(150, 90);
            this.table3Row.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table3Row;
        private TextBar redText;
        private TextBar greenText;
        private TextBar blueText;
    }
}
