namespace OverlayPOC
{
    partial class MainForm
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
            this.StatusLog = new System.Windows.Forms.RichTextBox();
            this.FormTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.StartButton = new System.Windows.Forms.Button();
            this.StatusText = new System.Windows.Forms.Label();
            this.FormTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusLog
            // 
            this.StatusLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FormTableLayout.SetColumnSpan(this.StatusLog, 2);
            this.StatusLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusLog.Location = new System.Drawing.Point(3, 3);
            this.StatusLog.Name = "StatusLog";
            this.StatusLog.ReadOnly = true;
            this.StatusLog.ShortcutsEnabled = false;
            this.StatusLog.Size = new System.Drawing.Size(794, 414);
            this.StatusLog.TabIndex = 0;
            this.StatusLog.Text = "Click Start to begin";
            // 
            // FormTableLayout
            // 
            this.FormTableLayout.ColumnCount = 2;
            this.FormTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FormTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.FormTableLayout.Controls.Add(this.StatusLog, 0, 0);
            this.FormTableLayout.Controls.Add(this.StartButton, 0, 1);
            this.FormTableLayout.Controls.Add(this.StatusText, 1, 1);
            this.FormTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormTableLayout.Location = new System.Drawing.Point(0, 0);
            this.FormTableLayout.Name = "FormTableLayout";
            this.FormTableLayout.RowCount = 2;
            this.FormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FormTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.FormTableLayout.Size = new System.Drawing.Size(800, 450);
            this.FormTableLayout.TabIndex = 1;
            // 
            // StartButton
            // 
            this.StartButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartButton.Location = new System.Drawing.Point(3, 423);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 24);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = true;
            this.StatusText.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusText.Location = new System.Drawing.Point(692, 420);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(105, 30);
            this.StatusText.TabIndex = 2;
            this.StatusText.Text = "Waiting to Start";
            this.StatusText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FormTableLayout);
            this.Name = "MainForm";
            this.Text = "OverlayPOC";
            this.FormTableLayout.ResumeLayout(false);
            this.FormTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox StatusLog;
        private System.Windows.Forms.TableLayoutPanel FormTableLayout;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label StatusText;
    }
}

