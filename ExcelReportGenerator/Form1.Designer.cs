namespace ExcelReportGenerator
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
            this.label1 = new System.Windows.Forms.Label();
            this.dbPicker = new OSIsoft.AF.UI.AFDatabasePicker();
            this.piSystemPicker1 = new OSIsoft.AF.UI.PISystemPicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.afTreeView = new OSIsoft.AF.UI.AFTreeView();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbReportOnChildren = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbParentAttributes = new System.Windows.Forms.CheckedListBox();
            this.cbChilrenAttributes = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblChildrenAttributes = new System.Windows.Forms.Label();
            this.btnPreviewData = new System.Windows.Forms.Button();
            this.btnExportData = new System.Windows.Forms.Button();
            this.lblExcelCompleted = new System.Windows.Forms.Label();
            this.saveExcelDialog = new System.Windows.Forms.SaveFileDialog();
            this.txtJsonData = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Excel Report Generator";
            // 
            // dbPicker
            // 
            this.dbPicker.AccessibleDescription = "Database Picker";
            this.dbPicker.AccessibleName = "Database Picker";
            this.dbPicker.Location = new System.Drawing.Point(96, 92);
            this.dbPicker.Name = "dbPicker";
            this.dbPicker.ShowBegin = false;
            this.dbPicker.ShowDelete = false;
            this.dbPicker.ShowEnd = false;
            this.dbPicker.ShowFind = false;
            this.dbPicker.ShowImages = false;
            this.dbPicker.ShowList = false;
            this.dbPicker.ShowNavigation = false;
            this.dbPicker.ShowNew = false;
            this.dbPicker.ShowNext = false;
            this.dbPicker.ShowNoEntries = false;
            this.dbPicker.ShowPrevious = false;
            this.dbPicker.ShowProperties = false;
            this.dbPicker.Size = new System.Drawing.Size(248, 21);
            this.dbPicker.TabIndex = 4;
            this.dbPicker.SelectionChange += new OSIsoft.AF.UI.SelectionChangeEventHandler(this.dbPicker_SelectionChange);
            // 
            // piSystemPicker1
            // 
            this.piSystemPicker1.AccessibleDescription = "PI System Picker";
            this.piSystemPicker1.AccessibleName = "PI System Picker";
            this.piSystemPicker1.ConnectAutomatically = true;
            this.piSystemPicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.piSystemPicker1.Location = new System.Drawing.Point(96, 51);
            this.piSystemPicker1.LoginPromptSetting = OSIsoft.AF.UI.PISystemPicker.LoginPromptSettingOptions.Default;
            this.piSystemPicker1.Name = "piSystemPicker1";
            this.piSystemPicker1.ShowBegin = false;
            this.piSystemPicker1.ShowConnect = false;
            this.piSystemPicker1.ShowDelete = false;
            this.piSystemPicker1.ShowEnd = false;
            this.piSystemPicker1.ShowFind = false;
            this.piSystemPicker1.ShowImages = false;
            this.piSystemPicker1.ShowList = false;
            this.piSystemPicker1.ShowNavigation = false;
            this.piSystemPicker1.ShowNew = false;
            this.piSystemPicker1.ShowNext = false;
            this.piSystemPicker1.ShowNoEntries = false;
            this.piSystemPicker1.ShowPrevious = false;
            this.piSystemPicker1.ShowProperties = false;
            this.piSystemPicker1.Size = new System.Drawing.Size(248, 21);
            this.piSystemPicker1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "PI Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "AF Database";
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(468, 51);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 20);
            this.dateStart.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Start Date";
            // 
            // afTreeView
            // 
            this.afTreeView.HideSelection = false;
            this.afTreeView.Location = new System.Drawing.Point(96, 134);
            this.afTreeView.Name = "afTreeView";
            this.afTreeView.ShowNodeToolTips = true;
            this.afTreeView.Size = new System.Drawing.Size(248, 308);
            this.afTreeView.TabIndex = 9;
            this.afTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.afTreeView_AfterSelect);
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(468, 92);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 20);
            this.dateEnd.TabIndex = 10;
            this.dateEnd.Value = new System.DateTime(2018, 11, 9, 15, 37, 3, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "End Date";
            // 
            // cbReportOnChildren
            // 
            this.cbReportOnChildren.AutoSize = true;
            this.cbReportOnChildren.Location = new System.Drawing.Point(96, 448);
            this.cbReportOnChildren.Name = "cbReportOnChildren";
            this.cbReportOnChildren.Size = new System.Drawing.Size(160, 17);
            this.cbReportOnChildren.TabIndex = 12;
            this.cbReportOnChildren.Text = "Report on Children Elements";
            this.cbReportOnChildren.UseVisualStyleBackColor = true;
            this.cbReportOnChildren.Click += new System.EventHandler(this.cbIncludeChildren_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Elements";
            // 
            // cbParentAttributes
            // 
            this.cbParentAttributes.FormattingEnabled = true;
            this.cbParentAttributes.Location = new System.Drawing.Point(399, 150);
            this.cbParentAttributes.Name = "cbParentAttributes";
            this.cbParentAttributes.Size = new System.Drawing.Size(269, 124);
            this.cbParentAttributes.TabIndex = 14;
            // 
            // cbChilrenAttributes
            // 
            this.cbChilrenAttributes.Enabled = false;
            this.cbChilrenAttributes.FormattingEnabled = true;
            this.cbChilrenAttributes.Location = new System.Drawing.Point(399, 326);
            this.cbChilrenAttributes.Name = "cbChilrenAttributes";
            this.cbChilrenAttributes.Size = new System.Drawing.Size(269, 139);
            this.cbChilrenAttributes.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Attribtues To Include in Report";
            // 
            // lblChildrenAttributes
            // 
            this.lblChildrenAttributes.AutoSize = true;
            this.lblChildrenAttributes.Location = new System.Drawing.Point(396, 310);
            this.lblChildrenAttributes.Name = "lblChildrenAttributes";
            this.lblChildrenAttributes.Size = new System.Drawing.Size(190, 13);
            this.lblChildrenAttributes.TabIndex = 17;
            this.lblChildrenAttributes.Text = "Chidren Attribtues To Include in Report";
            // 
            // btnPreviewData
            // 
            this.btnPreviewData.Location = new System.Drawing.Point(213, 513);
            this.btnPreviewData.Name = "btnPreviewData";
            this.btnPreviewData.Size = new System.Drawing.Size(131, 23);
            this.btnPreviewData.TabIndex = 18;
            this.btnPreviewData.Text = "Preview Data as JSON";
            this.btnPreviewData.UseVisualStyleBackColor = true;
            this.btnPreviewData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnPreviewData_MouseClick);
            // 
            // btnExportData
            // 
            this.btnExportData.Location = new System.Drawing.Point(396, 513);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(106, 23);
            this.btnExportData.TabIndex = 19;
            this.btnExportData.Text = "Export to Excel";
            this.btnExportData.UseVisualStyleBackColor = true;
            this.btnExportData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExportData_MouseClick);
            // 
            // lblExcelCompleted
            // 
            this.lblExcelCompleted.AutoSize = true;
            this.lblExcelCompleted.Location = new System.Drawing.Point(529, 518);
            this.lblExcelCompleted.Name = "lblExcelCompleted";
            this.lblExcelCompleted.Size = new System.Drawing.Size(119, 13);
            this.lblExcelCompleted.TabIndex = 20;
            this.lblExcelCompleted.Text = "Excel Export Completed";
            this.lblExcelCompleted.Visible = false;
            // 
            // saveExcelDialog
            // 
            this.saveExcelDialog.CheckPathExists = false;
            this.saveExcelDialog.DefaultExt = "xlsx";
            this.saveExcelDialog.Filter = "Excel Files (.xls, .xlsx .xlsx)|*.xls;*.xlsx;*.xlsm";
            this.saveExcelDialog.Title = "Export Excel to:";
            this.saveExcelDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveExcelDialog_FileOk);
            // 
            // txtJsonData
            // 
            this.txtJsonData.Location = new System.Drawing.Point(731, 67);
            this.txtJsonData.Name = "txtJsonData";
            this.txtJsonData.ReadOnly = true;
            this.txtJsonData.Size = new System.Drawing.Size(367, 398);
            this.txtJsonData.TabIndex = 21;
            this.txtJsonData.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(731, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "JSON Data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 548);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtJsonData);
            this.Controls.Add(this.lblExcelCompleted);
            this.Controls.Add(this.btnExportData);
            this.Controls.Add(this.btnPreviewData);
            this.Controls.Add(this.lblChildrenAttributes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbChilrenAttributes);
            this.Controls.Add(this.cbParentAttributes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbReportOnChildren);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.afTreeView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.piSystemPicker1);
            this.Controls.Add(this.dbPicker);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private OSIsoft.AF.UI.AFDatabasePicker dbPicker;
        private OSIsoft.AF.UI.PISystemPicker piSystemPicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label5;
        private OSIsoft.AF.UI.AFTreeView afTreeView;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbReportOnChildren;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox cbParentAttributes;
        private System.Windows.Forms.CheckedListBox cbChilrenAttributes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblChildrenAttributes;
        private System.Windows.Forms.Button btnPreviewData;
        private System.Windows.Forms.Button btnExportData;
        private System.Windows.Forms.Label lblExcelCompleted;
        private System.Windows.Forms.SaveFileDialog saveExcelDialog;
        private System.Windows.Forms.RichTextBox txtJsonData;
        private System.Windows.Forms.Label label8;
    }
}

