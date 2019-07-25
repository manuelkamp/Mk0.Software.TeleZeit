namespace Mk0.Software.TeleZeit
{
    partial class TeleZeit
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tätigkeitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auswertungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonEnde = new System.Windows.Forms.Button();
            this.listViewZeiten = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonTatigkeit = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.checkBox8H = new System.Windows.Forms.CheckBox();
            this.contextMenuStripView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tätigkeitErfassenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.löschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.contextMenuStripView.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "TeleZeit";
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            this.notifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.endeToolStripMenuItem,
            this.tätigkeitToolStripMenuItem,
            this.auswertungToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(139, 92);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.Start_Click);
            // 
            // endeToolStripMenuItem
            // 
            this.endeToolStripMenuItem.Enabled = false;
            this.endeToolStripMenuItem.Name = "endeToolStripMenuItem";
            this.endeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.endeToolStripMenuItem.Text = "Ende";
            this.endeToolStripMenuItem.Click += new System.EventHandler(this.Ende_Click);
            // 
            // tätigkeitToolStripMenuItem
            // 
            this.tätigkeitToolStripMenuItem.Enabled = false;
            this.tätigkeitToolStripMenuItem.Name = "tätigkeitToolStripMenuItem";
            this.tätigkeitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.tätigkeitToolStripMenuItem.Text = "Tätigkeit";
            this.tätigkeitToolStripMenuItem.Click += new System.EventHandler(this.Tätigkeit_Click);
            // 
            // auswertungToolStripMenuItem
            // 
            this.auswertungToolStripMenuItem.Name = "auswertungToolStripMenuItem";
            this.auswertungToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.auswertungToolStripMenuItem.Text = "Auswertung";
            this.auswertungToolStripMenuItem.Click += new System.EventHandler(this.Auswertung_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(141, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Zeiterfassung starten";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.Start_Click);
            // 
            // buttonEnde
            // 
            this.buttonEnde.Enabled = false;
            this.buttonEnde.Location = new System.Drawing.Point(159, 12);
            this.buttonEnde.Name = "buttonEnde";
            this.buttonEnde.Size = new System.Drawing.Size(141, 23);
            this.buttonEnde.TabIndex = 2;
            this.buttonEnde.Text = "Zeiterfassung beenden";
            this.buttonEnde.UseVisualStyleBackColor = true;
            this.buttonEnde.Click += new System.EventHandler(this.Ende_Click);
            // 
            // listViewZeiten
            // 
            this.listViewZeiten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewZeiten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewZeiten.FullRowSelect = true;
            this.listViewZeiten.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewZeiten.HideSelection = false;
            this.listViewZeiten.Location = new System.Drawing.Point(12, 41);
            this.listViewZeiten.MultiSelect = false;
            this.listViewZeiten.Name = "listViewZeiten";
            this.listViewZeiten.ShowGroups = false;
            this.listViewZeiten.Size = new System.Drawing.Size(591, 278);
            this.listViewZeiten.TabIndex = 3;
            this.listViewZeiten.UseCompatibleStateImageBehavior = false;
            this.listViewZeiten.View = System.Windows.Forms.View.Details;
            this.listViewZeiten.SelectedIndexChanged += new System.EventHandler(this.ListViewZeiten_SelectedIndexChanged);
            this.listViewZeiten.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewZeiten_MouseClick);
            this.listViewZeiten.Resize += new System.EventHandler(this.ListViewZeiten_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Startzeit";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Endzeit";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tätigkeit";
            // 
            // buttonTatigkeit
            // 
            this.buttonTatigkeit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTatigkeit.Enabled = false;
            this.buttonTatigkeit.Location = new System.Drawing.Point(462, 12);
            this.buttonTatigkeit.Name = "buttonTatigkeit";
            this.buttonTatigkeit.Size = new System.Drawing.Size(141, 23);
            this.buttonTatigkeit.TabIndex = 4;
            this.buttonTatigkeit.Text = "Tätigkeit erfassen";
            this.buttonTatigkeit.UseVisualStyleBackColor = true;
            this.buttonTatigkeit.Click += new System.EventHandler(this.Tätigkeit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 322);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(614, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(142, 17);
            this.toolStripStatusLabel.Text = "Zeiterfassung ist beendet.";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.TimerRefresh_Tick);
            // 
            // checkBox8H
            // 
            this.checkBox8H.AutoSize = true;
            this.checkBox8H.Checked = true;
            this.checkBox8H.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox8H.Location = new System.Drawing.Point(320, 16);
            this.checkBox8H.Name = "checkBox8H";
            this.checkBox8H.Size = new System.Drawing.Size(122, 17);
            this.checkBox8H.TabIndex = 6;
            this.checkBox8H.Text = "8-Stunden Warnung";
            this.checkBox8H.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripView
            // 
            this.contextMenuStripView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tätigkeitErfassenToolStripMenuItem,
            this.löschenToolStripMenuItem});
            this.contextMenuStripView.Name = "contextMenuStripView";
            this.contextMenuStripView.Size = new System.Drawing.Size(165, 48);
            // 
            // tätigkeitErfassenToolStripMenuItem
            // 
            this.tätigkeitErfassenToolStripMenuItem.Name = "tätigkeitErfassenToolStripMenuItem";
            this.tätigkeitErfassenToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.tätigkeitErfassenToolStripMenuItem.Text = "Tätigkeit erfassen";
            this.tätigkeitErfassenToolStripMenuItem.Click += new System.EventHandler(this.Tätigkeit_Click);
            // 
            // löschenToolStripMenuItem
            // 
            this.löschenToolStripMenuItem.Name = "löschenToolStripMenuItem";
            this.löschenToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.löschenToolStripMenuItem.Text = "Löschen";
            this.löschenToolStripMenuItem.Click += new System.EventHandler(this.LöschenToolStripMenuItem_Click);
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip.ToolTipTitle = "TeleZeit";
            // 
            // TeleZeit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 344);
            this.Controls.Add(this.checkBox8H);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonTatigkeit);
            this.Controls.Add(this.listViewZeiten);
            this.Controls.Add(this.buttonEnde);
            this.Controls.Add(this.buttonStart);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(630, 383);
            this.Name = "TeleZeit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TeleZeit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeleZeit_FormClosing);
            this.Resize += new System.EventHandler(this.TeleZeit_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStripView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tätigkeitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auswertungToolStripMenuItem;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonEnde;
        private System.Windows.Forms.ListView listViewZeiten;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonTatigkeit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.CheckBox checkBox8H;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripView;
        private System.Windows.Forms.ToolStripMenuItem tätigkeitErfassenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem löschenToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

