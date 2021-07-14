
namespace AliyunAkTools
{
    partial class functions
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
        private void InitializeComponent( )
        {
            this.Info_Label = new System.Windows.Forms.Label();
            this.CmdBox = new System.Windows.Forms.TextBox();
            this.ExecBtn = new System.Windows.Forms.Button();
            this.TipLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Info_Label
            // 
            this.Info_Label.AutoSize = true;
            this.Info_Label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info_Label.Location = new System.Drawing.Point(10, 9);
            this.Info_Label.Name = "Info_Label";
            this.Info_Label.Size = new System.Drawing.Size(33, 14);
            this.Info_Label.TabIndex = 0;
            this.Info_Label.Text = "Info:";
            // 
            // CmdBox
            // 
            this.CmdBox.Location = new System.Drawing.Point(12, 175);
            this.CmdBox.Name = "CmdBox";
            this.CmdBox.Size = new System.Drawing.Size(320, 21);
            this.CmdBox.TabIndex = 1;
            // 
            // ExecBtn
            // 
            this.ExecBtn.Location = new System.Drawing.Point(103, 202);
            this.ExecBtn.Name = "ExecBtn";
            this.ExecBtn.Size = new System.Drawing.Size(125, 29);
            this.ExecBtn.TabIndex = 2;
            this.ExecBtn.Text = "Execute";
            this.ExecBtn.UseVisualStyleBackColor = true;
            this.ExecBtn.Click += new System.EventHandler(this.ExecBtn_Click);
            // 
            // TipLabel
            // 
            this.TipLabel.AutoSize = true;
            this.TipLabel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TipLabel.ForeColor = System.Drawing.Color.Red;
            this.TipLabel.Location = new System.Drawing.Point(60, 149);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(0, 23);
            this.TipLabel.TabIndex = 3;
            this.TipLabel.Visible = false;
            // 
            // functions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 241);
            this.Controls.Add(this.TipLabel);
            this.Controls.Add(this.ExecBtn);
            this.Controls.Add(this.CmdBox);
            this.Controls.Add(this.Info_Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "functions";
            this.ShowInTaskbar = false;
            this.Text = "执行命令";
            this.Load += new System.EventHandler(this.functions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Info_Label;
        private System.Windows.Forms.TextBox CmdBox;
        private System.Windows.Forms.Button ExecBtn;
        private System.Windows.Forms.Label TipLabel;
    }
}