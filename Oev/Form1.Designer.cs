namespace Oev
{
    partial class Form1
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
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.fahrplan = new System.Windows.Forms.TabPage();
            this.dTPDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dTPTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNach = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVon = new System.Windows.Forms.TextBox();
            this.lblVon = new System.Windows.Forms.Label();
            this.lkfahrplan = new System.Windows.Forms.TabPage();
            this.LBverbindungen = new System.Windows.Forms.ListView();
            this.tbStation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.abfahrtsTafel = new System.Windows.Forms.ListView();
            this.searchVerbindungen = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.fahrplan.SuspendLayout();
            this.lkfahrplan.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.fahrplan);
            this.tabControl1.Controls.Add(this.lkfahrplan);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1902, 1156);
            this.tabControl1.TabIndex = 1;
            // 
            // fahrplan
            // 
            this.fahrplan.Controls.Add(this.LBverbindungen);
            this.fahrplan.Controls.Add(this.dTPDate);
            this.fahrplan.Controls.Add(this.btnSearch);
            this.fahrplan.Controls.Add(this.dTPTime);
            this.fahrplan.Controls.Add(this.label3);
            this.fahrplan.Controls.Add(this.textBox1);
            this.fahrplan.Controls.Add(this.label2);
            this.fahrplan.Controls.Add(this.tbNach);
            this.fahrplan.Controls.Add(this.label1);
            this.fahrplan.Controls.Add(this.tbVon);
            this.fahrplan.Controls.Add(this.lblVon);
            this.fahrplan.Location = new System.Drawing.Point(8, 39);
            this.fahrplan.Name = "fahrplan";
            this.fahrplan.Padding = new System.Windows.Forms.Padding(3);
            this.fahrplan.Size = new System.Drawing.Size(1886, 1109);
            this.fahrplan.TabIndex = 0;
            this.fahrplan.Text = "Fahrplan";
            this.fahrplan.UseVisualStyleBackColor = true;
            // 
            // dTPDate
            // 
            this.dTPDate.Location = new System.Drawing.Point(31, 384);
            this.dTPDate.Name = "dTPDate";
            this.dTPDate.Size = new System.Drawing.Size(244, 31);
            this.dTPDate.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(31, 541);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(244, 48);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Suchen";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dTPTime
            // 
            this.dTPTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dTPTime.Location = new System.Drawing.Point(31, 447);
            this.dTPTime.Name = "dTPTime";
            this.dTPTime.Size = new System.Drawing.Size(244, 31);
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
            this.textBox1.Size = new System.Drawing.Size(244, 31);
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
            this.tbNach.Size = new System.Drawing.Size(244, 31);
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
            // tbVon
            // 
            this.tbVon.Location = new System.Drawing.Point(31, 115);
            this.tbVon.Name = "tbVon";
            this.tbVon.Size = new System.Drawing.Size(244, 31);
            this.tbVon.TabIndex = 1;
            // 
            // lblVon
            // 
            this.lblVon.AutoSize = true;
            this.lblVon.Location = new System.Drawing.Point(26, 87);
            this.lblVon.Name = "lblVon";
            this.lblVon.Size = new System.Drawing.Size(50, 25);
            this.lblVon.TabIndex = 0;
            this.lblVon.Text = "Von";
            // 
            // lkfahrplan
            // 
            this.lkfahrplan.Controls.Add(this.searchVerbindungen);
            this.lkfahrplan.Controls.Add(this.abfahrtsTafel);
            this.lkfahrplan.Controls.Add(this.tbStation);
            this.lkfahrplan.Controls.Add(this.label4);
            this.lkfahrplan.Location = new System.Drawing.Point(8, 39);
            this.lkfahrplan.Name = "lkfahrplan";
            this.lkfahrplan.Padding = new System.Windows.Forms.Padding(3);
            this.lkfahrplan.Size = new System.Drawing.Size(1886, 1109);
            this.lkfahrplan.TabIndex = 1;
            this.lkfahrplan.Text = "Abfahrsfahrplan";
            this.lkfahrplan.UseVisualStyleBackColor = true;
            // 
            // LBverbindungen
            // 
            this.LBverbindungen.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.LBverbindungen.BackColor = System.Drawing.SystemColors.HighlightText;
            listViewGroup4.Header = "ListViewGroup";
            listViewGroup4.Name = "listViewGroup1";
            this.LBverbindungen.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup4});
            this.LBverbindungen.Location = new System.Drawing.Point(376, 115);
            this.LBverbindungen.Name = "LBverbindungen";
            this.LBverbindungen.Size = new System.Drawing.Size(1472, 502);
            this.LBverbindungen.TabIndex = 10;
            this.LBverbindungen.UseCompatibleStateImageBehavior = false;
            // 
            // tbStation
            // 
            this.tbStation.Location = new System.Drawing.Point(11, 77);
            this.tbStation.Name = "tbStation";
            this.tbStation.Size = new System.Drawing.Size(244, 31);
            this.tbStation.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Station";
            // 
            // abfahrtsTafel
            // 
            this.abfahrtsTafel.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.abfahrtsTafel.BackColor = System.Drawing.SystemColors.HighlightText;
            listViewGroup3.Header = "ListViewGroup";
            listViewGroup3.Name = "listViewGroup1";
            this.abfahrtsTafel.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.abfahrtsTafel.Location = new System.Drawing.Point(363, 77);
            this.abfahrtsTafel.Name = "abfahrtsTafel";
            this.abfahrtsTafel.Size = new System.Drawing.Size(1472, 502);
            this.abfahrtsTafel.TabIndex = 11;
            this.abfahrtsTafel.UseCompatibleStateImageBehavior = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1886, 1163);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            
            this.tabControl1.ResumeLayout(false);
            this.fahrplan.ResumeLayout(false);
            this.fahrplan.PerformLayout();
            this.lkfahrplan.ResumeLayout(false);
            this.lkfahrplan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage fahrplan;
        private System.Windows.Forms.DateTimePicker dTPDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dTPTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVon;
        private System.Windows.Forms.Label lblVon;
        private System.Windows.Forms.TabPage lkfahrplan;
        private System.Windows.Forms.ListView LBverbindungen;
        private System.Windows.Forms.Button searchVerbindungen;
        private System.Windows.Forms.ListView abfahrtsTafel;
        private System.Windows.Forms.TextBox tbStation;
        private System.Windows.Forms.Label label4;
    }
}

