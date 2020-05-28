namespace NickScotney.SeratoNowPlaying.UI
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.GrpBxParseTime = new System.Windows.Forms.GroupBox();
            this.TxtBxParseTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpBxLocation = new System.Windows.Forms.GroupBox();
            this.TxtBxFeedLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GrpBxCurrentTrack = new System.Windows.Forms.GroupBox();
            this.BtnBrowseCurrent = new System.Windows.Forms.Button();
            this.TxtBxCurrentTrack = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GrpBxPreviousTrack = new System.Windows.Forms.GroupBox();
            this.BtnBrowsePrevious = new System.Windows.Forms.Button();
            this.ChkBxPreviousTrack = new System.Windows.Forms.CheckBox();
            this.TxtBxPreviousTrack = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.ChkBxCurrentPrefix = new System.Windows.Forms.CheckBox();
            this.TxtBxCurrentPrefix = new System.Windows.Forms.TextBox();
            this.TxtBxCurrentSuffix = new System.Windows.Forms.TextBox();
            this.ChkBxCurrentSuffix = new System.Windows.Forms.CheckBox();
            this.TxtBxPreviousSuffix = new System.Windows.Forms.TextBox();
            this.ChkBxPreviousSuffix = new System.Windows.Forms.CheckBox();
            this.TxtBxPreviousPrefix = new System.Windows.Forms.TextBox();
            this.ChkBxPreviousPrefix = new System.Windows.Forms.CheckBox();
            this.GrpBxParseTime.SuspendLayout();
            this.GrpBxLocation.SuspendLayout();
            this.GrpBxCurrentTrack.SuspendLayout();
            this.GrpBxPreviousTrack.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBxParseTime
            // 
            this.GrpBxParseTime.Controls.Add(this.TxtBxParseTime);
            this.GrpBxParseTime.Controls.Add(this.label1);
            this.GrpBxParseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBxParseTime.Location = new System.Drawing.Point(13, 13);
            this.GrpBxParseTime.Name = "GrpBxParseTime";
            this.GrpBxParseTime.Size = new System.Drawing.Size(299, 89);
            this.GrpBxParseTime.TabIndex = 0;
            this.GrpBxParseTime.TabStop = false;
            this.GrpBxParseTime.Text = "Feed Parse Time";
            // 
            // TxtBxParseTime
            // 
            this.TxtBxParseTime.Location = new System.Drawing.Point(14, 55);
            this.TxtBxParseTime.Name = "TxtBxParseTime";
            this.TxtBxParseTime.Size = new System.Drawing.Size(279, 20);
            this.TxtBxParseTime.TabIndex = 1;
            this.TxtBxParseTime.Text = "10";
            this.TxtBxParseTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBxParseTime_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the time (in seconds) you\'d like to reload the feed \r\n(Default: 10 seconds)" +
    "";
            // 
            // GrpBxLocation
            // 
            this.GrpBxLocation.Controls.Add(this.TxtBxFeedLocation);
            this.GrpBxLocation.Controls.Add(this.label2);
            this.GrpBxLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBxLocation.Location = new System.Drawing.Point(13, 108);
            this.GrpBxLocation.Name = "GrpBxLocation";
            this.GrpBxLocation.Size = new System.Drawing.Size(299, 83);
            this.GrpBxLocation.TabIndex = 1;
            this.GrpBxLocation.TabStop = false;
            this.GrpBxLocation.Text = "Live Feed Location";
            // 
            // TxtBxFeedLocation
            // 
            this.TxtBxFeedLocation.Location = new System.Drawing.Point(14, 56);
            this.TxtBxFeedLocation.Name = "TxtBxFeedLocation";
            this.TxtBxFeedLocation.Size = new System.Drawing.Size(279, 20);
            this.TxtBxFeedLocation.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter the location of the Serato Live Feed \r\n(Default: https://serato.com/playlis" +
    "ts/<<profilename>>/live)";
            // 
            // GrpBxCurrentTrack
            // 
            this.GrpBxCurrentTrack.Controls.Add(this.TxtBxCurrentSuffix);
            this.GrpBxCurrentTrack.Controls.Add(this.ChkBxCurrentSuffix);
            this.GrpBxCurrentTrack.Controls.Add(this.TxtBxCurrentPrefix);
            this.GrpBxCurrentTrack.Controls.Add(this.ChkBxCurrentPrefix);
            this.GrpBxCurrentTrack.Controls.Add(this.BtnBrowseCurrent);
            this.GrpBxCurrentTrack.Controls.Add(this.TxtBxCurrentTrack);
            this.GrpBxCurrentTrack.Controls.Add(this.label3);
            this.GrpBxCurrentTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBxCurrentTrack.Location = new System.Drawing.Point(13, 197);
            this.GrpBxCurrentTrack.Name = "GrpBxCurrentTrack";
            this.GrpBxCurrentTrack.Size = new System.Drawing.Size(299, 133);
            this.GrpBxCurrentTrack.TabIndex = 2;
            this.GrpBxCurrentTrack.TabStop = false;
            this.GrpBxCurrentTrack.Text = "Current Track Label";
            // 
            // BtnBrowseCurrent
            // 
            this.BtnBrowseCurrent.Location = new System.Drawing.Point(243, 50);
            this.BtnBrowseCurrent.Name = "BtnBrowseCurrent";
            this.BtnBrowseCurrent.Size = new System.Drawing.Size(50, 20);
            this.BtnBrowseCurrent.TabIndex = 5;
            this.BtnBrowseCurrent.Text = "...";
            this.BtnBrowseCurrent.UseVisualStyleBackColor = true;
            // 
            // TxtBxCurrentTrack
            // 
            this.TxtBxCurrentTrack.Location = new System.Drawing.Point(14, 50);
            this.TxtBxCurrentTrack.Name = "TxtBxCurrentTrack";
            this.TxtBxCurrentTrack.ReadOnly = true;
            this.TxtBxCurrentTrack.Size = new System.Drawing.Size(223, 20);
            this.TxtBxCurrentTrack.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter the local file path where current track should be \r\nwritten";
            // 
            // GrpBxPreviousTrack
            // 
            this.GrpBxPreviousTrack.Controls.Add(this.TxtBxPreviousSuffix);
            this.GrpBxPreviousTrack.Controls.Add(this.ChkBxPreviousSuffix);
            this.GrpBxPreviousTrack.Controls.Add(this.TxtBxPreviousPrefix);
            this.GrpBxPreviousTrack.Controls.Add(this.ChkBxPreviousPrefix);
            this.GrpBxPreviousTrack.Controls.Add(this.BtnBrowsePrevious);
            this.GrpBxPreviousTrack.Controls.Add(this.ChkBxPreviousTrack);
            this.GrpBxPreviousTrack.Controls.Add(this.TxtBxPreviousTrack);
            this.GrpBxPreviousTrack.Controls.Add(this.label4);
            this.GrpBxPreviousTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBxPreviousTrack.Location = new System.Drawing.Point(13, 336);
            this.GrpBxPreviousTrack.Name = "GrpBxPreviousTrack";
            this.GrpBxPreviousTrack.Size = new System.Drawing.Size(299, 157);
            this.GrpBxPreviousTrack.TabIndex = 3;
            this.GrpBxPreviousTrack.TabStop = false;
            this.GrpBxPreviousTrack.Text = "Previous Track Label";
            // 
            // BtnBrowsePrevious
            // 
            this.BtnBrowsePrevious.Location = new System.Drawing.Point(243, 78);
            this.BtnBrowsePrevious.Name = "BtnBrowsePrevious";
            this.BtnBrowsePrevious.Size = new System.Drawing.Size(50, 20);
            this.BtnBrowsePrevious.TabIndex = 6;
            this.BtnBrowsePrevious.Text = "...";
            this.BtnBrowsePrevious.UseVisualStyleBackColor = true;
            // 
            // ChkBxPreviousTrack
            // 
            this.ChkBxPreviousTrack.AutoSize = true;
            this.ChkBxPreviousTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxPreviousTrack.Location = new System.Drawing.Point(14, 55);
            this.ChkBxPreviousTrack.Name = "ChkBxPreviousTrack";
            this.ChkBxPreviousTrack.Size = new System.Drawing.Size(163, 17);
            this.ChkBxPreviousTrack.TabIndex = 4;
            this.ChkBxPreviousTrack.Text = "Enable Previous Track Label";
            this.ChkBxPreviousTrack.UseVisualStyleBackColor = true;
            this.ChkBxPreviousTrack.CheckedChanged += new System.EventHandler(this.ChkBxPreviousTrack_CheckedChanged);
            // 
            // TxtBxPreviousTrack
            // 
            this.TxtBxPreviousTrack.Location = new System.Drawing.Point(14, 78);
            this.TxtBxPreviousTrack.Name = "TxtBxPreviousTrack";
            this.TxtBxPreviousTrack.ReadOnly = true;
            this.TxtBxPreviousTrack.Size = new System.Drawing.Size(223, 20);
            this.TxtBxPreviousTrack.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(269, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "If enabled, enter the local file path where previous track\r\nshould be written";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(256, 499);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(56, 23);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(194, 499);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(56, 23);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(132, 499);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(56, 23);
            this.BtnStart.TabIndex = 4;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // ChkBxCurrentPrefix
            // 
            this.ChkBxCurrentPrefix.AutoSize = true;
            this.ChkBxCurrentPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxCurrentPrefix.Location = new System.Drawing.Point(14, 78);
            this.ChkBxCurrentPrefix.Name = "ChkBxCurrentPrefix";
            this.ChkBxCurrentPrefix.Size = new System.Drawing.Size(81, 17);
            this.ChkBxCurrentPrefix.TabIndex = 6;
            this.ChkBxCurrentPrefix.Text = "Label Prefix";
            this.ChkBxCurrentPrefix.UseVisualStyleBackColor = true;
            this.ChkBxCurrentPrefix.CheckedChanged += new System.EventHandler(this.ChkBxCurrentPrefix_CheckedChanged);
            // 
            // TxtBxCurrentPrefix
            // 
            this.TxtBxCurrentPrefix.Enabled = false;
            this.TxtBxCurrentPrefix.Location = new System.Drawing.Point(101, 76);
            this.TxtBxCurrentPrefix.Name = "TxtBxCurrentPrefix";
            this.TxtBxCurrentPrefix.Size = new System.Drawing.Size(192, 20);
            this.TxtBxCurrentPrefix.TabIndex = 7;
            // 
            // TxtBxCurrentSuffix
            // 
            this.TxtBxCurrentSuffix.Enabled = false;
            this.TxtBxCurrentSuffix.Location = new System.Drawing.Point(101, 102);
            this.TxtBxCurrentSuffix.Name = "TxtBxCurrentSuffix";
            this.TxtBxCurrentSuffix.Size = new System.Drawing.Size(192, 20);
            this.TxtBxCurrentSuffix.TabIndex = 9;
            // 
            // ChkBxCurrentSuffix
            // 
            this.ChkBxCurrentSuffix.AutoSize = true;
            this.ChkBxCurrentSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxCurrentSuffix.Location = new System.Drawing.Point(14, 104);
            this.ChkBxCurrentSuffix.Name = "ChkBxCurrentSuffix";
            this.ChkBxCurrentSuffix.Size = new System.Drawing.Size(81, 17);
            this.ChkBxCurrentSuffix.TabIndex = 8;
            this.ChkBxCurrentSuffix.Text = "Label Suffix";
            this.ChkBxCurrentSuffix.UseVisualStyleBackColor = true;
            this.ChkBxCurrentSuffix.CheckedChanged += new System.EventHandler(this.ChkBxCurrentSuffix_CheckedChanged);
            // 
            // TxtBxPreviousSuffix
            // 
            this.TxtBxPreviousSuffix.Enabled = false;
            this.TxtBxPreviousSuffix.Location = new System.Drawing.Point(101, 128);
            this.TxtBxPreviousSuffix.Name = "TxtBxPreviousSuffix";
            this.TxtBxPreviousSuffix.Size = new System.Drawing.Size(192, 20);
            this.TxtBxPreviousSuffix.TabIndex = 13;
            // 
            // ChkBxPreviousSuffix
            // 
            this.ChkBxPreviousSuffix.AutoSize = true;
            this.ChkBxPreviousSuffix.Enabled = false;
            this.ChkBxPreviousSuffix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxPreviousSuffix.Location = new System.Drawing.Point(14, 130);
            this.ChkBxPreviousSuffix.Name = "ChkBxPreviousSuffix";
            this.ChkBxPreviousSuffix.Size = new System.Drawing.Size(81, 17);
            this.ChkBxPreviousSuffix.TabIndex = 12;
            this.ChkBxPreviousSuffix.Text = "Label Suffix";
            this.ChkBxPreviousSuffix.UseVisualStyleBackColor = true;
            this.ChkBxPreviousSuffix.CheckedChanged += new System.EventHandler(this.ChkBxPreviousSuffix_CheckedChanged);
            // 
            // TxtBxPreviousPrefix
            // 
            this.TxtBxPreviousPrefix.Enabled = false;
            this.TxtBxPreviousPrefix.Location = new System.Drawing.Point(101, 102);
            this.TxtBxPreviousPrefix.Name = "TxtBxPreviousPrefix";
            this.TxtBxPreviousPrefix.Size = new System.Drawing.Size(192, 20);
            this.TxtBxPreviousPrefix.TabIndex = 11;
            // 
            // ChkBxPreviousPrefix
            // 
            this.ChkBxPreviousPrefix.AutoSize = true;
            this.ChkBxPreviousPrefix.Enabled = false;
            this.ChkBxPreviousPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkBxPreviousPrefix.Location = new System.Drawing.Point(14, 104);
            this.ChkBxPreviousPrefix.Name = "ChkBxPreviousPrefix";
            this.ChkBxPreviousPrefix.Size = new System.Drawing.Size(81, 17);
            this.ChkBxPreviousPrefix.TabIndex = 10;
            this.ChkBxPreviousPrefix.Text = "Label Prefix";
            this.ChkBxPreviousPrefix.UseVisualStyleBackColor = true;
            this.ChkBxPreviousPrefix.CheckedChanged += new System.EventHandler(this.ChkBxPreviousPrefix_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 531);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.GrpBxPreviousTrack);
            this.Controls.Add(this.GrpBxCurrentTrack);
            this.Controls.Add(this.GrpBxLocation);
            this.Controls.Add(this.GrpBxParseTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(344, 570);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(344, 570);
            this.Name = "FrmMain";
            this.Text = "Serato Now Playing Tool";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.GrpBxParseTime.ResumeLayout(false);
            this.GrpBxParseTime.PerformLayout();
            this.GrpBxLocation.ResumeLayout(false);
            this.GrpBxLocation.PerformLayout();
            this.GrpBxCurrentTrack.ResumeLayout(false);
            this.GrpBxCurrentTrack.PerformLayout();
            this.GrpBxPreviousTrack.ResumeLayout(false);
            this.GrpBxPreviousTrack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBxParseTime;
        private System.Windows.Forms.TextBox TxtBxParseTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrpBxLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtBxFeedLocation;
        private System.Windows.Forms.GroupBox GrpBxCurrentTrack;
        private System.Windows.Forms.TextBox TxtBxCurrentTrack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox GrpBxPreviousTrack;
        private System.Windows.Forms.CheckBox ChkBxPreviousTrack;
        private System.Windows.Forms.TextBox TxtBxPreviousTrack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnBrowseCurrent;
        private System.Windows.Forms.Button BtnBrowsePrevious;
        private System.Windows.Forms.TextBox TxtBxCurrentSuffix;
        private System.Windows.Forms.CheckBox ChkBxCurrentSuffix;
        private System.Windows.Forms.TextBox TxtBxCurrentPrefix;
        private System.Windows.Forms.CheckBox ChkBxCurrentPrefix;
        private System.Windows.Forms.TextBox TxtBxPreviousSuffix;
        private System.Windows.Forms.CheckBox ChkBxPreviousSuffix;
        private System.Windows.Forms.TextBox TxtBxPreviousPrefix;
        private System.Windows.Forms.CheckBox ChkBxPreviousPrefix;
    }
}

