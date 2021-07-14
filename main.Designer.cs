
namespace AliyunAkTools
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AKID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AKSK = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.srv_lvw = new System.Windows.Forms.ListView();
            this.col_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_serverId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_region = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_serverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_OS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_privIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_pubIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_secGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_srvOp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_InstanceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_startTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_endTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_cloudHelper = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AKID
            // 
            this.AKID.Location = new System.Drawing.Point(141, 16);
            this.AKID.Name = "AKID";
            this.AKID.Size = new System.Drawing.Size(168, 21);
            this.AKID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "AccessKey ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(315, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "AccessKey Secret";
            // 
            // AKSK
            // 
            this.AKSK.Location = new System.Drawing.Point(450, 19);
            this.AKSK.Name = "AKSK";
            this.AKSK.Size = new System.Drawing.Size(211, 21);
            this.AKSK.TabIndex = 3;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(680, 16);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(97, 25);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_log.Location = new System.Drawing.Point(6, 20);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(991, 107);
            this.txt_log.TabIndex = 5;
            this.txt_log.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_log);
            this.groupBox1.Location = new System.Drawing.Point(12, 378);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(997, 131);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "状态信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.srv_lvw);
            this.groupBox2.Location = new System.Drawing.Point(12, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(997, 313);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器列表";
            // 
            // srv_lvw
            // 
            this.srv_lvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.srv_lvw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.srv_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_id,
            this.col_serverId,
            this.col_region,
            this.col_serverName,
            this.col_OS,
            this.col_status,
            this.col_privIP,
            this.col_pubIP,
            this.col_secGroup,
            this.col_srvOp,
            this.col_InstanceType,
            this.col_startTime,
            this.col_endTime,
            this.col_cloudHelper});
            this.srv_lvw.ContextMenuStrip = this.contextMenuStrip1;
            this.srv_lvw.Cursor = System.Windows.Forms.Cursors.Default;
            this.srv_lvw.FullRowSelect = true;
            this.srv_lvw.GridLines = true;
            this.srv_lvw.HideSelection = false;
            this.srv_lvw.Location = new System.Drawing.Point(14, 19);
            this.srv_lvw.Name = "srv_lvw";
            this.srv_lvw.Size = new System.Drawing.Size(977, 293);
            this.srv_lvw.TabIndex = 0;
            this.srv_lvw.UseCompatibleStateImageBehavior = false;
            this.srv_lvw.View = System.Windows.Forms.View.Details;
            // 
            // col_id
            // 
            this.col_id.Text = "ID";
            this.col_id.Width = 31;
            // 
            // col_serverId
            // 
            this.col_serverId.Text = "实例ID";
            // 
            // col_region
            // 
            this.col_region.Text = "实例地区";
            this.col_region.Width = 88;
            // 
            // col_serverName
            // 
            this.col_serverName.Text = "主机名称";
            this.col_serverName.Width = 74;
            // 
            // col_OS
            // 
            this.col_OS.Text = "主机系统";
            // 
            // col_status
            // 
            this.col_status.Text = "实例状态";
            this.col_status.Width = 70;
            // 
            // col_privIP
            // 
            this.col_privIP.Text = "私网IP";
            // 
            // col_pubIP
            // 
            this.col_pubIP.Text = "公网IP";
            this.col_pubIP.Width = 100;
            // 
            // col_secGroup
            // 
            this.col_secGroup.Text = "安全组";
            this.col_secGroup.Width = 93;
            // 
            // col_srvOp
            // 
            this.col_srvOp.Text = "主机配置";
            this.col_srvOp.Width = 86;
            // 
            // col_InstanceType
            // 
            this.col_InstanceType.Text = "实例规格";
            // 
            // col_startTime
            // 
            this.col_startTime.Text = "创建时间";
            // 
            // col_endTime
            // 
            this.col_endTime.Text = "到期时间";
            // 
            // col_cloudHelper
            // 
            this.col_cloudHelper.Text = "云助手";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExecToolStripMenuItem,
            this.CopyLineToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 48);
            // 
            // ExecToolStripMenuItem
            // 
            this.ExecToolStripMenuItem.Name = "ExecToolStripMenuItem";
            this.ExecToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ExecToolStripMenuItem.Text = "执行...";
            this.ExecToolStripMenuItem.Click += new System.EventHandler(this.ExecToolStripMenuItem_Click);
            // 
            // CopyLineToolStripMenuItem
            // 
            this.CopyLineToolStripMenuItem.Name = "CopyLineToolStripMenuItem";
            this.CopyLineToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.CopyLineToolStripMenuItem.Text = "复制";
            this.CopyLineToolStripMenuItem.Click += new System.EventHandler(this.CopyLineToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ConnectBtn);
            this.groupBox3.Controls.Add(this.AKSK);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.AKID);
            this.groupBox3.Location = new System.Drawing.Point(9, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(802, 56);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            // 
            // main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1018, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aliyun AK Tool 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox AKID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AKSK;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView srv_lvw;
        private System.Windows.Forms.ColumnHeader col_id;
        private System.Windows.Forms.ColumnHeader col_serverId;
        private System.Windows.Forms.ColumnHeader col_region;
        private System.Windows.Forms.ColumnHeader col_serverName;
        private System.Windows.Forms.ColumnHeader col_OS;
        private System.Windows.Forms.ColumnHeader col_status;
        private System.Windows.Forms.ColumnHeader col_privIP;
        private System.Windows.Forms.ColumnHeader col_pubIP;
        private System.Windows.Forms.ColumnHeader col_secGroup;
        private System.Windows.Forms.ColumnHeader col_srvOp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ColumnHeader col_startTime;
        private System.Windows.Forms.ColumnHeader col_endTime;
        private System.Windows.Forms.ColumnHeader col_InstanceType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExecToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader col_cloudHelper;
        private System.Windows.Forms.ToolStripMenuItem CopyLineToolStripMenuItem;
    }
}

