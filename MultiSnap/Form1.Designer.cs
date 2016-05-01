namespace MultiSnap
{
    partial class Form1
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
            this.OpacitySlider = new System.Windows.Forms.TrackBar();
            this.SnapPreviewPicBox = new System.Windows.Forms.PictureBox();
            this.SnapCreateBtn = new System.Windows.Forms.Button();
            this.Overlaylbl = new System.Windows.Forms.Label();
            this.ShowHalfChk = new System.Windows.Forms.CheckBox();
            this.ShowThirdChk = new System.Windows.Forms.CheckBox();
            this.ClearSnapsBtn = new System.Windows.Forms.Button();
            this.RuleSelectionCombo = new System.Windows.Forms.ComboBox();
            this.RulesIndividChk = new System.Windows.Forms.CheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnapPreviewPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // OpacitySlider
            // 
            this.OpacitySlider.Location = new System.Drawing.Point(12, 352);
            this.OpacitySlider.Maximum = 100;
            this.OpacitySlider.Minimum = 30;
            this.OpacitySlider.Name = "OpacitySlider";
            this.OpacitySlider.Size = new System.Drawing.Size(235, 45);
            this.OpacitySlider.TabIndex = 0;
            this.OpacitySlider.Value = 40;
            // 
            // SnapPreviewPicBox
            // 
            this.SnapPreviewPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SnapPreviewPicBox.Location = new System.Drawing.Point(12, 12);
            this.SnapPreviewPicBox.Name = "SnapPreviewPicBox";
            this.SnapPreviewPicBox.Size = new System.Drawing.Size(579, 324);
            this.SnapPreviewPicBox.TabIndex = 1;
            this.SnapPreviewPicBox.TabStop = false;
            this.SnapPreviewPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.SnapPreviewPicBox_Paint);
            // 
            // SnapCreateBtn
            // 
            this.SnapCreateBtn.Location = new System.Drawing.Point(253, 342);
            this.SnapCreateBtn.Name = "SnapCreateBtn";
            this.SnapCreateBtn.Size = new System.Drawing.Size(103, 23);
            this.SnapCreateBtn.TabIndex = 2;
            this.SnapCreateBtn.Text = "Create New Snap";
            this.SnapCreateBtn.UseVisualStyleBackColor = true;
            this.SnapCreateBtn.Click += new System.EventHandler(this.SnapCreateBtn_Click);
            // 
            // Overlaylbl
            // 
            this.Overlaylbl.AutoSize = true;
            this.Overlaylbl.Location = new System.Drawing.Point(71, 342);
            this.Overlaylbl.Name = "Overlaylbl";
            this.Overlaylbl.Size = new System.Drawing.Size(111, 13);
            this.Overlaylbl.TabIndex = 3;
            this.Overlaylbl.Text = "Overlay Transparency";
            // 
            // ShowHalfChk
            // 
            this.ShowHalfChk.AutoSize = true;
            this.ShowHalfChk.Location = new System.Drawing.Point(518, 347);
            this.ShowHalfChk.Name = "ShowHalfChk";
            this.ShowHalfChk.Size = new System.Drawing.Size(68, 17);
            this.ShowHalfChk.TabIndex = 4;
            this.ShowHalfChk.Text = "Split Half";
            this.ShowHalfChk.UseVisualStyleBackColor = true;
            this.ShowHalfChk.CheckedChanged += new System.EventHandler(this.ShowHalfChk_CheckedChanged);
            // 
            // ShowThirdChk
            // 
            this.ShowThirdChk.AutoSize = true;
            this.ShowThirdChk.Location = new System.Drawing.Point(518, 370);
            this.ShowThirdChk.Name = "ShowThirdChk";
            this.ShowThirdChk.Size = new System.Drawing.Size(73, 17);
            this.ShowThirdChk.TabIndex = 5;
            this.ShowThirdChk.Text = "Split Third";
            this.ShowThirdChk.UseVisualStyleBackColor = true;
            this.ShowThirdChk.CheckedChanged += new System.EventHandler(this.ShowThirdChk_CheckedChanged);
            // 
            // ClearSnapsBtn
            // 
            this.ClearSnapsBtn.Location = new System.Drawing.Point(253, 370);
            this.ClearSnapsBtn.Name = "ClearSnapsBtn";
            this.ClearSnapsBtn.Size = new System.Drawing.Size(103, 23);
            this.ClearSnapsBtn.TabIndex = 6;
            this.ClearSnapsBtn.Text = "Clear All Snaps";
            this.ClearSnapsBtn.UseVisualStyleBackColor = true;
            this.ClearSnapsBtn.Click += new System.EventHandler(this.ClearSnapsBtn_Click);
            // 
            // RuleSelectionCombo
            // 
            this.RuleSelectionCombo.FormattingEnabled = true;
            this.RuleSelectionCombo.Location = new System.Drawing.Point(377, 345);
            this.RuleSelectionCombo.Name = "RuleSelectionCombo";
            this.RuleSelectionCombo.Size = new System.Drawing.Size(121, 21);
            this.RuleSelectionCombo.TabIndex = 7;
            this.RuleSelectionCombo.SelectedValueChanged += new System.EventHandler(this.RuleSelectionCombo_SelectedValueChanged);
            // 
            // RulesIndividChk
            // 
            this.RulesIndividChk.AutoSize = true;
            this.RulesIndividChk.Location = new System.Drawing.Point(377, 373);
            this.RulesIndividChk.Name = "RulesIndividChk";
            this.RulesIndividChk.Size = new System.Drawing.Size(138, 17);
            this.RulesIndividChk.TabIndex = 8;
            this.RulesIndividChk.Text = "Show Rules Individually";
            this.RulesIndividChk.UseVisualStyleBackColor = true;
            this.RulesIndividChk.CheckedChanged += new System.EventHandler(this.RulesIndividChk_CheckedChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "MultiSnap Is In Tray";
            this.notifyIcon1.BalloonTipTitle = "Info";
            this.notifyIcon1.Text = "MultiSnap";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 399);
            this.Controls.Add(this.RulesIndividChk);
            this.Controls.Add(this.RuleSelectionCombo);
            this.Controls.Add(this.ClearSnapsBtn);
            this.Controls.Add(this.ShowThirdChk);
            this.Controls.Add(this.ShowHalfChk);
            this.Controls.Add(this.Overlaylbl);
            this.Controls.Add(this.SnapCreateBtn);
            this.Controls.Add(this.SnapPreviewPicBox);
            this.Controls.Add(this.OpacitySlider);
            this.Name = "Form1";
            this.Text = "MultiSnap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnapPreviewPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar OpacitySlider;
        private System.Windows.Forms.PictureBox SnapPreviewPicBox;
        private System.Windows.Forms.Button SnapCreateBtn;
        private System.Windows.Forms.Label Overlaylbl;
        private System.Windows.Forms.CheckBox ShowHalfChk;
        private System.Windows.Forms.CheckBox ShowThirdChk;
        private System.Windows.Forms.Button ClearSnapsBtn;
        private System.Windows.Forms.ComboBox RuleSelectionCombo;
        private System.Windows.Forms.CheckBox RulesIndividChk;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

