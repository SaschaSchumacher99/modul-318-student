namespace Oev
{
    partial class OevVerbindungen
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fahrplan = new System.Windows.Forms.TabPage();
            this.openKarte = new System.Windows.Forms.LinkLabel();
            this.searchStation = new System.Windows.Forms.Button();
            this.tbVon = new System.Windows.Forms.ComboBox();
            this.LBverbindungen = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dTPTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVon = new System.Windows.Forms.Label();
            this.lkfahrplan = new System.Windows.Forms.TabPage();
            this.searchStationAF = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.searchVerbindungen = new System.Windows.Forms.Button();
            this.abfahrtsTafel = new System.Windows.Forms.ListView();
            this.autocomplete = new System.Windows.Forms.CheckBox();
            this.emailhint = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.fahrplan.SuspendLayout();
            this.lkfahrplan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailhint)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.fahrplan);
            this.tabControl1.Controls.Add(this.lkfahrplan);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1906, 1156);
            this.tabControl1.TabIndex = 1;
            // 
            // fahrplan
            // 
            this.fahrplan.Controls.Add(this.emailhint);
            this.fahrplan.Controls.Add(this.autocomplete);
            this.fahrplan.Controls.Add(this.openKarte);
            this.fahrplan.Controls.Add(this.searchStation);
            this.fahrplan.Controls.Add(this.tbVon);
            this.fahrplan.Controls.Add(this.LBverbindungen);
            this.fahrplan.Controls.Add(this.btnSearch);
            this.fahrplan.Controls.Add(this.dTPTime);
            this.fahrplan.Controls.Add(this.label3);
            this.fahrplan.Controls.Add(this.textBox1);
            this.fahrplan.Controls.Add(this.label2);
            this.fahrplan.Controls.Add(this.tbNach);
            this.fahrplan.Controls.Add(this.label1);
            this.fahrplan.Controls.Add(this.lblVon);
            this.fahrplan.Location = new System.Drawing.Point(8, 39);
            this.fahrplan.Name = "fahrplan";
            this.fahrplan.Padding = new System.Windows.Forms.Padding(3);
            this.fahrplan.Size = new System.Drawing.Size(1890, 1109);
            this.fahrplan.TabIndex = 0;
            this.fahrplan.Text = "Fahrplan";
            this.fahrplan.UseVisualStyleBackColor = true;
            // 
            // openKarte
            // 
            this.openKarte.AutoSize = true;
            this.openKarte.Location = new System.Drawing.Point(25, 103);
            this.openKarte.Name = "openKarte";
            this.openKarte.Size = new System.Drawing.Size(63, 25);
            this.openKarte.TabIndex = 13;
            this.openKarte.TabStop = true;
            this.openKarte.Text = "Karte";
            this.openKarte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openKarte_LinkClicked);
            // 
            // searchStation
            // 
            this.searchStation.Location = new System.Drawing.Point(408, 57);
            this.searchStation.Name = "searchStation";
            this.searchStation.Size = new System.Drawing.Size(187, 61);
            this.searchStation.TabIndex = 12;
            this.searchStation.Text = "Station suchen";
            this.searchStation.UseVisualStyleBackColor = true;
            this.searchStation.Click += new System.EventHandler(this.searchStation_Click);
            // 
            // tbVon
            // 
            this.tbVon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbVon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tbVon.FormattingEnabled = true;
            this.tbVon.Location = new System.Drawing.Point(31, 57);
            this.tbVon.Name = "tbVon";
            this.tbVon.Size = new System.Drawing.Size(293, 33);
            this.tbVon.TabIndex = 11;
            this.tbVon.TextChanged += new System.EventHandler(this.tbVon_TextChanged);
            // 
            // LBverbindungen
            // 
            this.LBverbindungen.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.LBverbindungen.BackColor = System.Drawing.SystemColors.HighlightText;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.LBverbindungen.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.LBverbindungen.Location = new System.Drawing.Point(408, 221);
            this.LBverbindungen.Name = "LBverbindungen";
            this.LBverbindungen.Size = new System.Drawing.Size(1416, 665);
            this.LBverbindungen.TabIndex = 10;
            this.LBverbindungen.UseCompatibleStateImageBehavior = false;
            this.LBverbindungen.DoubleClick += new System.EventHandler(this.LBverbindungen_DoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(31, 838);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(244, 48);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dTPTime
            // 
            this.dTPTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPTime.Location = new System.Drawing.Point(31, 395);
            this.dTPTime.Name = "dTPTime";
            this.dTPTime.Size = new System.Drawing.Size(293, 31);
            this.dTPTime.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Abfahrt";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(31, 286);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(293, 31);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Via";
            // 
            // tbNach
            // 
            this.tbNach.Location = new System.Drawing.Point(31, 198);
            this.tbNach.Name = "tbNach";
            this.tbNach.Size = new System.Drawing.Size(293, 31);
            this.tbNach.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nach";
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(26, 29);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(50, 25);
            this.lblVon.TabIndex = 0;
            this.lblVon.Text = "Von";
            // 
            // lkfahrplan
            // 
            this.lkfahrplan.Controls.Add(this.searchStationAF);
            this.lkfahrplan.Controls.Add(this.comboBox2);
            this.lkfahrplan.Controls.Add(this.label4);
            this.lkfahrplan.Controls.Add(this.searchVerbindungen);
            this.lkfahrplan.Controls.Add(this.abfahrtsTafel);
            this.lkfahrplan.Location = new System.Drawing.Point(8, 39);
            this.lkfahrplan.Name = "lkfahrplan";
            this.lkfahrplan.Padding = new System.Windows.Forms.Padding(3);
            this.lkfahrplan.Size = new System.Drawing.Size(1890, 1109);
            this.lkfahrplan.TabIndex = 1;
            this.lkfahrplan.Text = "Abfahrsfahrplan";
            this.lkfahrplan.UseVisualStyleBackColor = true;
            // 
            // searchStationAF
            // 
            this.searchStationAF.Location = new System.Drawing.Point(276, 53);
            this.searchStationAF.Name = "searchStationAF";
            this.searchStationAF.Size = new System.Drawing.Size(223, 57);
            this.searchStationAF.TabIndex = 15;
            this.searchStationAF.Text = "Station suchen";
            this.searchStationAF.UseVisualStyleBackColor = true;
            this.searchStationAF.Click += new System.EventHandler(this.searchStationAF_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(11, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(244, 33);
            this.comboBox2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Von";
            // 
            // searchVerbindungen
            // 
            this.searchVerbindungen.Location = new System.Drawing.Point(11, 531);
            this.searchVerbindungen.Name = "searchVerbindungen";
            this.searchVerbindungen.Size = new System.Drawing.Size(244, 48);
            this.searchVerbindungen.TabIndex = 12;
            this.searchVerbindungen.Text = "Suchen";
            this.searchVerbindungen.UseVisualStyleBackColor = true;
            this.searchVerbindungen.Click += new System.EventHandler(this.searchVerbindungen_Click);
            // 
            // abfahrtsTafel
            // 
            this.abfahrtsTafel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.abfahrtsTafel.BackColor = System.Drawing.SystemColors.HighlightText;
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup1";
            this.abfahrtsTafel.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.abfahrtsTafel.Location = new System.Drawing.Point(276, 211);
            this.abfahrtsTafel.Name = "abfahrtsTafel";
            this.abfahrtsTafel.Size = new System.Drawing.Size(1414, 502);
            this.abfahrtsTafel.TabIndex = 11;
            this.abfahrtsTafel.UseCompatibleStateImageBehavior = false;
            // 
            // autocomplete
            // 
            this.autocomplete.AutoSize = true;
            this.autocomplete.Location = new System.Drawing.Point(100, 103);
            this.autocomplete.Name = "autocomplete";
            this.autocomplete.Size = new System.Drawing.Size(175, 29);
            this.autocomplete.TabIndex = 14;
            this.autocomplete.Text = "Autocomplete";
            this.autocomplete.UseVisualStyleBackColor = true;
            // 
            // emailhint
            // 
            this.emailhint.Image = global::Oev.Properties.Resources.email;
            this.emailhint.Location = new System.Drawing.Point(1744, 892);
            this.emailhint.Name = "emailhint";
            this.emailhint.Size = new System.Drawing.Size(80, 64);
            this.emailhint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.emailhint.TabIndex = 15;
            this.emailhint.TabStop = false;
            // 
            // OevVerbindungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 1163);
            this.Controls.Add(this.tabControl1);
            this.Name = "OevVerbindungen";
            this.Text = "Öv Verbindungen ";
            this.tabControl1.ResumeLayout(false);
            this.fahrplan.ResumeLayout(false);
            this.fahrplan.PerformLayout();
            this.lkfahrplan.ResumeLayout(false);
            this.lkfahrplan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailhint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage fahrplan;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dTPTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVon;
        private System.Windows.Forms.TabPage lkfahrplan;
        private System.Windows.Forms.ListView LBverbindungen;
        private System.Windows.Forms.Button searchVerbindungen;
        private System.Windows.Forms.ListView abfahrtsTafel;
        private System.Windows.Forms.ComboBox tbVon;
        private System.Windows.Forms.Button searchStation;
        private System.Windows.Forms.Button searchStationAF;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel openKarte;
        private System.Windows.Forms.CheckBox autocomplete;
        private System.Windows.Forms.PictureBox emailhint;
    }
}

