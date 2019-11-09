namespace FileAttributeChanger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.modifiedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.accessedDatePicker = new System.Windows.Forms.DateTimePicker();
            this.createdDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label_ChangeFileExtTo = new System.Windows.Forms.Label();
            this.textBox_FileExtChange = new System.Windows.Forms.TextBox();
            this.checkBox_readOnly = new System.Windows.Forms.CheckBox();
            this.checkBox_hidden = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_archive = new System.Windows.Forms.CheckBox();
            this.checkBox_compressed = new System.Windows.Forms.CheckBox();
            this.checkBox_integrityStream = new System.Windows.Forms.CheckBox();
            this.checkBox_encrypted = new System.Windows.Forms.CheckBox();
            this.checkBox_temporary = new System.Windows.Forms.CheckBox();
            this.checkBox_system = new System.Windows.Forms.CheckBox();
            this.checkBox_offline = new System.Windows.Forms.CheckBox();
            this.checkBox_notContentIndexed = new System.Windows.Forms.CheckBox();
            this.checkBox_sparseFile = new System.Windows.Forms.CheckBox();
            this.checkBox_reparsePoint = new System.Windows.Forms.CheckBox();
            this.checkBox_noScrubData = new System.Windows.Forms.CheckBox();
            this.CheckBox_AdvancedAttributes = new System.Windows.Forms.CheckBox();
            this.checkBox_directory = new System.Windows.Forms.CheckBox();
            this.checkBox_device = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_RenameRandom = new System.Windows.Forms.CheckBox();
            this.checkBox_GUID = new System.Windows.Forms.CheckBox();
            this.label_RenamePattern = new System.Windows.Forms.Label();
            this.checkBox_dateTimes = new System.Windows.Forms.CheckBox();
            this.checkBox_rename = new System.Windows.Forms.CheckBox();
            this.checkBox_fileExtension = new System.Windows.Forms.CheckBox();
            this.groupBox_attributes = new System.Windows.Forms.GroupBox();
            this.textBox_RenamePattern = new System.Windows.Forms.TextBox();
            this.groupBox_rename = new System.Windows.Forms.GroupBox();
            this.groupBox_fileExtension = new System.Windows.Forms.GroupBox();
            this.groupBox_dateTimes = new System.Windows.Forms.GroupBox();
            this.groupBox_attributes.SuspendLayout();
            this.groupBox_rename.SuspendLayout();
            this.groupBox_fileExtension.SuspendLayout();
            this.groupBox_dateTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Created:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modified:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Accessed:";
            // 
            // modifiedDatePicker
            // 
            this.modifiedDatePicker.CustomFormat = "MM/dd/yyyy   hh:mm tt";
            this.modifiedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.modifiedDatePicker.Location = new System.Drawing.Point(90, 46);
            this.modifiedDatePicker.Name = "modifiedDatePicker";
            this.modifiedDatePicker.ShowUpDown = true;
            this.modifiedDatePicker.Size = new System.Drawing.Size(146, 20);
            this.modifiedDatePicker.TabIndex = 2;
            this.modifiedDatePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // accessedDatePicker
            // 
            this.accessedDatePicker.CustomFormat = "MM/dd/yyyy   hh:mm tt";
            this.accessedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.accessedDatePicker.Location = new System.Drawing.Point(90, 72);
            this.accessedDatePicker.Name = "accessedDatePicker";
            this.accessedDatePicker.ShowUpDown = true;
            this.accessedDatePicker.Size = new System.Drawing.Size(146, 20);
            this.accessedDatePicker.TabIndex = 3;
            this.accessedDatePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // createdDatePicker
            // 
            this.createdDatePicker.CustomFormat = "MM/dd/yyyy   hh:mm tt";
            this.createdDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.createdDatePicker.Location = new System.Drawing.Point(90, 20);
            this.createdDatePicker.Name = "createdDatePicker";
            this.createdDatePicker.ShowUpDown = true;
            this.createdDatePicker.Size = new System.Drawing.Size(146, 20);
            this.createdDatePicker.TabIndex = 1;
            this.createdDatePicker.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label_ChangeFileExtTo
            // 
            this.label_ChangeFileExtTo.AutoSize = true;
            this.label_ChangeFileExtTo.Location = new System.Drawing.Point(52, 19);
            this.label_ChangeFileExtTo.Name = "label_ChangeFileExtTo";
            this.label_ChangeFileExtTo.Size = new System.Drawing.Size(59, 13);
            this.label_ChangeFileExtTo.TabIndex = 6;
            this.label_ChangeFileExtTo.Text = "Change to:";
            this.toolTip1.SetToolTip(this.label_ChangeFileExtTo, "Change file extension.");
            // 
            // textBox_FileExtChange
            // 
            this.textBox_FileExtChange.Location = new System.Drawing.Point(117, 16);
            this.textBox_FileExtChange.Name = "textBox_FileExtChange";
            this.textBox_FileExtChange.Size = new System.Drawing.Size(161, 20);
            this.textBox_FileExtChange.TabIndex = 20;
            // 
            // checkBox_readOnly
            // 
            this.checkBox_readOnly.AutoSize = true;
            this.checkBox_readOnly.Location = new System.Drawing.Point(302, 69);
            this.checkBox_readOnly.Name = "checkBox_readOnly";
            this.checkBox_readOnly.Size = new System.Drawing.Size(74, 17);
            this.checkBox_readOnly.TabIndex = 15;
            this.checkBox_readOnly.Text = "Read-only";
            this.toolTip1.SetToolTip(this.checkBox_readOnly, "The file is read-only.");
            this.checkBox_readOnly.UseVisualStyleBackColor = true;
            // 
            // checkBox_hidden
            // 
            this.checkBox_hidden.AutoSize = true;
            this.checkBox_hidden.Location = new System.Drawing.Point(182, 46);
            this.checkBox_hidden.Name = "checkBox_hidden";
            this.checkBox_hidden.Size = new System.Drawing.Size(60, 17);
            this.checkBox_hidden.TabIndex = 10;
            this.checkBox_hidden.Text = "Hidden";
            this.toolTip1.SetToolTip(this.checkBox_hidden, "The file is hidden, and thus is not included in an ordinary directory listing.");
            this.checkBox_hidden.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(32, 202);
            this.label4.MaximumSize = new System.Drawing.Size(0, 2);
            this.label4.MinimumSize = new System.Drawing.Size(0, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 2);
            this.label4.TabIndex = 7;
            // 
            // checkBox_archive
            // 
            this.checkBox_archive.AutoSize = true;
            this.checkBox_archive.Location = new System.Drawing.Point(47, 23);
            this.checkBox_archive.Name = "checkBox_archive";
            this.checkBox_archive.Size = new System.Drawing.Size(62, 17);
            this.checkBox_archive.TabIndex = 5;
            this.checkBox_archive.Text = "Archive";
            this.toolTip1.SetToolTip(this.checkBox_archive, "The file is a candidate for backup or removal.");
            this.checkBox_archive.UseVisualStyleBackColor = true;
            // 
            // checkBox_compressed
            // 
            this.checkBox_compressed.AutoSize = true;
            this.checkBox_compressed.Location = new System.Drawing.Point(182, 23);
            this.checkBox_compressed.Name = "checkBox_compressed";
            this.checkBox_compressed.Size = new System.Drawing.Size(84, 17);
            this.checkBox_compressed.TabIndex = 6;
            this.checkBox_compressed.Text = "Compressed";
            this.toolTip1.SetToolTip(this.checkBox_compressed, "The file is compressed.");
            this.checkBox_compressed.UseVisualStyleBackColor = true;
            // 
            // checkBox_integrityStream
            // 
            this.checkBox_integrityStream.AutoSize = true;
            this.checkBox_integrityStream.Location = new System.Drawing.Point(302, 46);
            this.checkBox_integrityStream.Name = "checkBox_integrityStream";
            this.checkBox_integrityStream.Size = new System.Drawing.Size(96, 17);
            this.checkBox_integrityStream.TabIndex = 11;
            this.checkBox_integrityStream.Text = "IntegrityStream";
            this.toolTip1.SetToolTip(this.checkBox_integrityStream, resources.GetString("checkBox_integrityStream.ToolTip"));
            this.checkBox_integrityStream.UseVisualStyleBackColor = true;
            // 
            // checkBox_encrypted
            // 
            this.checkBox_encrypted.AutoSize = true;
            this.checkBox_encrypted.Location = new System.Drawing.Point(47, 46);
            this.checkBox_encrypted.Name = "checkBox_encrypted";
            this.checkBox_encrypted.Size = new System.Drawing.Size(74, 17);
            this.checkBox_encrypted.TabIndex = 9;
            this.checkBox_encrypted.Text = "Encrypted";
            this.toolTip1.SetToolTip(this.checkBox_encrypted, resources.GetString("checkBox_encrypted.ToolTip"));
            this.checkBox_encrypted.UseVisualStyleBackColor = true;
            // 
            // checkBox_temporary
            // 
            this.checkBox_temporary.AutoSize = true;
            this.checkBox_temporary.Location = new System.Drawing.Point(302, 92);
            this.checkBox_temporary.Name = "checkBox_temporary";
            this.checkBox_temporary.Size = new System.Drawing.Size(76, 17);
            this.checkBox_temporary.TabIndex = 19;
            this.checkBox_temporary.Text = "Temporary";
            this.toolTip1.SetToolTip(this.checkBox_temporary, resources.GetString("checkBox_temporary.ToolTip"));
            this.checkBox_temporary.UseVisualStyleBackColor = true;
            // 
            // checkBox_system
            // 
            this.checkBox_system.AutoSize = true;
            this.checkBox_system.Location = new System.Drawing.Point(182, 92);
            this.checkBox_system.Name = "checkBox_system";
            this.checkBox_system.Size = new System.Drawing.Size(60, 17);
            this.checkBox_system.TabIndex = 18;
            this.checkBox_system.Text = "System";
            this.toolTip1.SetToolTip(this.checkBox_system, "The file is a system file. That is, the file is part of the operating system or i" +
        "s used exclusively by the operating system.");
            this.checkBox_system.UseVisualStyleBackColor = true;
            // 
            // checkBox_offline
            // 
            this.checkBox_offline.AutoSize = true;
            this.checkBox_offline.Location = new System.Drawing.Point(182, 69);
            this.checkBox_offline.Name = "checkBox_offline";
            this.checkBox_offline.Size = new System.Drawing.Size(56, 17);
            this.checkBox_offline.TabIndex = 14;
            this.checkBox_offline.Text = "Offline";
            this.toolTip1.SetToolTip(this.checkBox_offline, "The file is offline. The data of the file is not immediately available.");
            this.checkBox_offline.UseVisualStyleBackColor = true;
            // 
            // checkBox_notContentIndexed
            // 
            this.checkBox_notContentIndexed.AutoSize = true;
            this.checkBox_notContentIndexed.Location = new System.Drawing.Point(47, 69);
            this.checkBox_notContentIndexed.Name = "checkBox_notContentIndexed";
            this.checkBox_notContentIndexed.Size = new System.Drawing.Size(124, 17);
            this.checkBox_notContentIndexed.TabIndex = 13;
            this.checkBox_notContentIndexed.Text = "Not Content Indexed";
            this.toolTip1.SetToolTip(this.checkBox_notContentIndexed, "The file will not be indexed by the operating system\'s content indexing service.");
            this.checkBox_notContentIndexed.UseVisualStyleBackColor = true;
            // 
            // checkBox_sparseFile
            // 
            this.checkBox_sparseFile.AutoSize = true;
            this.checkBox_sparseFile.Location = new System.Drawing.Point(47, 92);
            this.checkBox_sparseFile.Name = "checkBox_sparseFile";
            this.checkBox_sparseFile.Size = new System.Drawing.Size(78, 17);
            this.checkBox_sparseFile.TabIndex = 17;
            this.checkBox_sparseFile.Text = "Sparse File";
            this.toolTip1.SetToolTip(this.checkBox_sparseFile, "The file is a sparse file. Sparse files are typically large files whose data cons" +
        "ists of mostly zeros.");
            this.checkBox_sparseFile.UseVisualStyleBackColor = true;
            // 
            // checkBox_reparsePoint
            // 
            this.checkBox_reparsePoint.AutoSize = true;
            this.checkBox_reparsePoint.Location = new System.Drawing.Point(408, 69);
            this.checkBox_reparsePoint.Name = "checkBox_reparsePoint";
            this.checkBox_reparsePoint.Size = new System.Drawing.Size(93, 17);
            this.checkBox_reparsePoint.TabIndex = 16;
            this.checkBox_reparsePoint.Text = "Reparse Point";
            this.toolTip1.SetToolTip(this.checkBox_reparsePoint, "The file contains a reparse point, which is a block of user-defined data associat" +
        "ed with a file or a directory.");
            this.checkBox_reparsePoint.UseVisualStyleBackColor = true;
            // 
            // checkBox_noScrubData
            // 
            this.checkBox_noScrubData.AutoSize = true;
            this.checkBox_noScrubData.Location = new System.Drawing.Point(408, 46);
            this.checkBox_noScrubData.Name = "checkBox_noScrubData";
            this.checkBox_noScrubData.Size = new System.Drawing.Size(91, 17);
            this.checkBox_noScrubData.TabIndex = 12;
            this.checkBox_noScrubData.Text = "NoScrubData";
            this.toolTip1.SetToolTip(this.checkBox_noScrubData, resources.GetString("checkBox_noScrubData.ToolTip"));
            this.checkBox_noScrubData.UseVisualStyleBackColor = true;
            // 
            // CheckBox_AdvancedAttributes
            // 
            this.CheckBox_AdvancedAttributes.AutoSize = true;
            this.CheckBox_AdvancedAttributes.Location = new System.Drawing.Point(16, 35);
            this.CheckBox_AdvancedAttributes.Name = "CheckBox_AdvancedAttributes";
            this.CheckBox_AdvancedAttributes.Size = new System.Drawing.Size(116, 17);
            this.CheckBox_AdvancedAttributes.TabIndex = 4;
            this.CheckBox_AdvancedAttributes.Text = "Advance Attributes";
            this.toolTip1.SetToolTip(this.CheckBox_AdvancedAttributes, "Toggle Advanced Attributes. If \'unchecked\' this indicates the file is \'Normal\'. \r" +
        "\nNormal = The file is a standard file that has no special attributes. This attri" +
        "bute is valid only if it is used alone.");
            this.CheckBox_AdvancedAttributes.UseVisualStyleBackColor = true;
            this.CheckBox_AdvancedAttributes.CheckedChanged += new System.EventHandler(this.CheckBox_AdvancedAttributes_CheckedChanged);
            // 
            // checkBox_directory
            // 
            this.checkBox_directory.AutoSize = true;
            this.checkBox_directory.Location = new System.Drawing.Point(408, 23);
            this.checkBox_directory.Name = "checkBox_directory";
            this.checkBox_directory.Size = new System.Drawing.Size(68, 17);
            this.checkBox_directory.TabIndex = 8;
            this.checkBox_directory.Text = "Directory";
            this.toolTip1.SetToolTip(this.checkBox_directory, "The file is a directory.");
            this.checkBox_directory.UseVisualStyleBackColor = true;
            // 
            // checkBox_device
            // 
            this.checkBox_device.AutoCheck = false;
            this.checkBox_device.AutoSize = true;
            this.checkBox_device.Checked = true;
            this.checkBox_device.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBox_device.Location = new System.Drawing.Point(302, 23);
            this.checkBox_device.Name = "checkBox_device";
            this.checkBox_device.Size = new System.Drawing.Size(60, 17);
            this.checkBox_device.TabIndex = 7;
            this.checkBox_device.Text = "Device";
            this.toolTip1.SetToolTip(this.checkBox_device, "Reserved for future use.");
            this.checkBox_device.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 400;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // checkBox_RenameRandom
            // 
            this.checkBox_RenameRandom.AutoSize = true;
            this.checkBox_RenameRandom.Location = new System.Drawing.Point(115, 45);
            this.checkBox_RenameRandom.Name = "checkBox_RenameRandom";
            this.checkBox_RenameRandom.Size = new System.Drawing.Size(66, 17);
            this.checkBox_RenameRandom.TabIndex = 24;
            this.checkBox_RenameRandom.Text = "Random";
            this.toolTip1.SetToolTip(this.checkBox_RenameRandom, "Rename file(s) with a Random file name.");
            this.checkBox_RenameRandom.UseVisualStyleBackColor = true;
            this.checkBox_RenameRandom.CheckedChanged += new System.EventHandler(this.CheckBox_Random_CheckedChanged);
            // 
            // checkBox_GUID
            // 
            this.checkBox_GUID.AutoSize = true;
            this.checkBox_GUID.Location = new System.Drawing.Point(200, 45);
            this.checkBox_GUID.Name = "checkBox_GUID";
            this.checkBox_GUID.Size = new System.Drawing.Size(53, 17);
            this.checkBox_GUID.TabIndex = 25;
            this.checkBox_GUID.Text = "GUID";
            this.toolTip1.SetToolTip(this.checkBox_GUID, "Rename file(s) with a GUID file name.");
            this.checkBox_GUID.UseVisualStyleBackColor = true;
            this.checkBox_GUID.CheckedChanged += new System.EventHandler(this.CheckBox_GUID_CheckedChanged);
            // 
            // label_RenamePattern
            // 
            this.label_RenamePattern.AutoSize = true;
            this.label_RenamePattern.Location = new System.Drawing.Point(1, 19);
            this.label_RenamePattern.Name = "label_RenamePattern";
            this.label_RenamePattern.Size = new System.Drawing.Size(108, 13);
            this.label_RenamePattern.TabIndex = 22;
            this.label_RenamePattern.Text = "Filename (startsWith):";
            this.toolTip1.SetToolTip(this.label_RenamePattern, "Enter the primary name of the file, additional/duplicates will be appended a (2)," +
        "(3),(4) as so on. For example, \"test\" would produce renamed files like: test(1)," +
        " test(2), etc...");
            // 
            // checkBox_dateTimes
            // 
            this.checkBox_dateTimes.AutoSize = true;
            this.checkBox_dateTimes.Location = new System.Drawing.Point(16, 12);
            this.checkBox_dateTimes.Name = "checkBox_dateTimes";
            this.checkBox_dateTimes.Size = new System.Drawing.Size(77, 17);
            this.checkBox_dateTimes.TabIndex = 29;
            this.checkBox_dateTimes.Text = "Date/Time";
            this.toolTip1.SetToolTip(this.checkBox_dateTimes, "Toggle Date/Time attributes");
            this.checkBox_dateTimes.UseVisualStyleBackColor = true;
            this.checkBox_dateTimes.CheckedChanged += new System.EventHandler(this.CheckBox_dateTimes_CheckedChanged);
            // 
            // checkBox_rename
            // 
            this.checkBox_rename.AutoSize = true;
            this.checkBox_rename.Location = new System.Drawing.Point(16, 58);
            this.checkBox_rename.Name = "checkBox_rename";
            this.checkBox_rename.Size = new System.Drawing.Size(66, 17);
            this.checkBox_rename.TabIndex = 30;
            this.checkBox_rename.Text = "Rename";
            this.toolTip1.SetToolTip(this.checkBox_rename, "Toggle rename functions.");
            this.checkBox_rename.UseVisualStyleBackColor = true;
            this.checkBox_rename.CheckedChanged += new System.EventHandler(this.checkBox_rename_CheckedChanged);
            // 
            // checkBox_fileExtension
            // 
            this.checkBox_fileExtension.AutoSize = true;
            this.checkBox_fileExtension.Location = new System.Drawing.Point(16, 81);
            this.checkBox_fileExtension.Name = "checkBox_fileExtension";
            this.checkBox_fileExtension.Size = new System.Drawing.Size(91, 17);
            this.checkBox_fileExtension.TabIndex = 31;
            this.checkBox_fileExtension.Text = "File Extension";
            this.toolTip1.SetToolTip(this.checkBox_fileExtension, "Toggle File Extension functions.");
            this.checkBox_fileExtension.UseVisualStyleBackColor = true;
            this.checkBox_fileExtension.CheckedChanged += new System.EventHandler(this.checkBox_fileExtension_CheckedChanged);
            // 
            // groupBox_attributes
            // 
            this.groupBox_attributes.Controls.Add(this.checkBox_sparseFile);
            this.groupBox_attributes.Controls.Add(this.checkBox_reparsePoint);
            this.groupBox_attributes.Controls.Add(this.checkBox_hidden);
            this.groupBox_attributes.Controls.Add(this.checkBox_noScrubData);
            this.groupBox_attributes.Controls.Add(this.checkBox_readOnly);
            this.groupBox_attributes.Controls.Add(this.checkBox_directory);
            this.groupBox_attributes.Controls.Add(this.checkBox_device);
            this.groupBox_attributes.Controls.Add(this.checkBox_temporary);
            this.groupBox_attributes.Controls.Add(this.checkBox_system);
            this.groupBox_attributes.Controls.Add(this.checkBox_offline);
            this.groupBox_attributes.Controls.Add(this.checkBox_notContentIndexed);
            this.groupBox_attributes.Controls.Add(this.checkBox_integrityStream);
            this.groupBox_attributes.Controls.Add(this.checkBox_encrypted);
            this.groupBox_attributes.Controls.Add(this.checkBox_compressed);
            this.groupBox_attributes.Controls.Add(this.checkBox_archive);
            this.groupBox_attributes.Enabled = false;
            this.groupBox_attributes.Location = new System.Drawing.Point(12, 169);
            this.groupBox_attributes.Name = "groupBox_attributes";
            this.groupBox_attributes.Size = new System.Drawing.Size(562, 145);
            this.groupBox_attributes.TabIndex = 21;
            this.groupBox_attributes.TabStop = false;
            this.groupBox_attributes.Text = "Advanced Attributes";
            // 
            // textBox_RenamePattern
            // 
            this.textBox_RenamePattern.Location = new System.Drawing.Point(115, 16);
            this.textBox_RenamePattern.Name = "textBox_RenamePattern";
            this.textBox_RenamePattern.Size = new System.Drawing.Size(138, 20);
            this.textBox_RenamePattern.TabIndex = 23;
            // 
            // groupBox_rename
            // 
            this.groupBox_rename.Controls.Add(this.textBox_RenamePattern);
            this.groupBox_rename.Controls.Add(this.label_RenamePattern);
            this.groupBox_rename.Controls.Add(this.checkBox_GUID);
            this.groupBox_rename.Controls.Add(this.checkBox_RenameRandom);
            this.groupBox_rename.Enabled = false;
            this.groupBox_rename.Location = new System.Drawing.Point(12, 320);
            this.groupBox_rename.Name = "groupBox_rename";
            this.groupBox_rename.Size = new System.Drawing.Size(266, 100);
            this.groupBox_rename.TabIndex = 26;
            this.groupBox_rename.TabStop = false;
            this.groupBox_rename.Text = "Rename";
            // 
            // groupBox_fileExtension
            // 
            this.groupBox_fileExtension.Controls.Add(this.textBox_FileExtChange);
            this.groupBox_fileExtension.Controls.Add(this.label_ChangeFileExtTo);
            this.groupBox_fileExtension.Enabled = false;
            this.groupBox_fileExtension.Location = new System.Drawing.Point(290, 320);
            this.groupBox_fileExtension.Name = "groupBox_fileExtension";
            this.groupBox_fileExtension.Size = new System.Drawing.Size(284, 100);
            this.groupBox_fileExtension.TabIndex = 27;
            this.groupBox_fileExtension.TabStop = false;
            this.groupBox_fileExtension.Text = "File Extension";
            // 
            // groupBox_dateTimes
            // 
            this.groupBox_dateTimes.Controls.Add(this.label1);
            this.groupBox_dateTimes.Controls.Add(this.label2);
            this.groupBox_dateTimes.Controls.Add(this.label3);
            this.groupBox_dateTimes.Controls.Add(this.modifiedDatePicker);
            this.groupBox_dateTimes.Controls.Add(this.accessedDatePicker);
            this.groupBox_dateTimes.Controls.Add(this.createdDatePicker);
            this.groupBox_dateTimes.Enabled = false;
            this.groupBox_dateTimes.Location = new System.Drawing.Point(320, 40);
            this.groupBox_dateTimes.Name = "groupBox_dateTimes";
            this.groupBox_dateTimes.Size = new System.Drawing.Size(254, 123);
            this.groupBox_dateTimes.TabIndex = 28;
            this.groupBox_dateTimes.TabStop = false;
            this.groupBox_dateTimes.Text = "Date/Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 532);
            this.Controls.Add(this.checkBox_fileExtension);
            this.Controls.Add(this.checkBox_rename);
            this.Controls.Add(this.checkBox_dateTimes);
            this.Controls.Add(this.groupBox_dateTimes);
            this.Controls.Add(this.groupBox_fileExtension);
            this.Controls.Add(this.groupBox_rename);
            this.Controls.Add(this.groupBox_attributes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CheckBox_AdvancedAttributes);
            this.Name = "Form1";
            this.Text = "File Attributes";
            this.groupBox_attributes.ResumeLayout(false);
            this.groupBox_attributes.PerformLayout();
            this.groupBox_rename.ResumeLayout(false);
            this.groupBox_rename.PerformLayout();
            this.groupBox_fileExtension.ResumeLayout(false);
            this.groupBox_fileExtension.PerformLayout();
            this.groupBox_dateTimes.ResumeLayout(false);
            this.groupBox_dateTimes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker modifiedDatePicker;
        private System.Windows.Forms.DateTimePicker accessedDatePicker;
        private System.Windows.Forms.DateTimePicker createdDatePicker;
        private System.Windows.Forms.Label label_ChangeFileExtTo;
        private System.Windows.Forms.TextBox textBox_FileExtChange;
        private System.Windows.Forms.CheckBox checkBox_readOnly;
        private System.Windows.Forms.CheckBox checkBox_hidden;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_archive;
        private System.Windows.Forms.CheckBox checkBox_compressed;
        private System.Windows.Forms.CheckBox checkBox_integrityStream;
        private System.Windows.Forms.CheckBox checkBox_encrypted;
        private System.Windows.Forms.CheckBox checkBox_temporary;
        private System.Windows.Forms.CheckBox checkBox_system;
        private System.Windows.Forms.CheckBox checkBox_offline;
        private System.Windows.Forms.CheckBox checkBox_notContentIndexed;
        private System.Windows.Forms.CheckBox checkBox_sparseFile;
        private System.Windows.Forms.CheckBox checkBox_reparsePoint;
        private System.Windows.Forms.CheckBox checkBox_noScrubData;
        private System.Windows.Forms.CheckBox CheckBox_AdvancedAttributes;
        private System.Windows.Forms.CheckBox checkBox_directory;
        private System.Windows.Forms.CheckBox checkBox_device;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox_attributes;
        private System.Windows.Forms.TextBox textBox_RenamePattern;
        private System.Windows.Forms.Label label_RenamePattern;
        private System.Windows.Forms.CheckBox checkBox_RenameRandom;
        private System.Windows.Forms.CheckBox checkBox_GUID;
        private System.Windows.Forms.GroupBox groupBox_rename;
        private System.Windows.Forms.GroupBox groupBox_fileExtension;
        private System.Windows.Forms.GroupBox groupBox_dateTimes;
        private System.Windows.Forms.CheckBox checkBox_dateTimes;
        private System.Windows.Forms.CheckBox checkBox_rename;
        private System.Windows.Forms.CheckBox checkBox_fileExtension;
    }
}

