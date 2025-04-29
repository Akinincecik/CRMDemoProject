namespace CRMDemoProject
{
    partial class Frm_Personal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Personal));
            this.gb_PersonalInformations = new System.Windows.Forms.GroupBox();
            this.tb_IdNumber = new System.Windows.Forms.TextBox();
            this.lbl_IdentificationNumber = new System.Windows.Forms.Label();
            this.tb_Name = new System.Windows.Forms.TextBox();
            this.cmbb_MainLanguage = new System.Windows.Forms.ComboBox();
            this.lbl_Level = new System.Windows.Forms.Label();
            this.trb_Level = new System.Windows.Forms.TrackBar();
            this.lb_ForeignLanguage = new System.Windows.Forms.ListBox();
            this.lbl_ForeignLanguage = new System.Windows.Forms.Label();
            this.rb_Gender_NotGiven = new System.Windows.Forms.RadioButton();
            this.rb_Gender_Female = new System.Windows.Forms.RadioButton();
            this.rb_Gender_Male = new System.Windows.Forms.RadioButton();
            this.pb_PictureBox = new System.Windows.Forms.PictureBox();
            this.dtp_DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.rtb_Description = new System.Windows.Forms.RichTextBox();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.lbl_Gender = new System.Windows.Forms.Label();
            this.tb_Surname = new System.Windows.Forms.TextBox();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Surname = new System.Windows.Forms.Label();
            this.lbl_MainLanguage = new System.Windows.Forms.Label();
            this.lbl_DateOfBirth = new System.Windows.Forms.Label();
            this.gb_ContactInformations = new System.Windows.Forms.GroupBox();
            this.cb_AdressIsActive = new System.Windows.Forms.CheckBox();
            this.cb_EmailIsActive = new System.Windows.Forms.CheckBox();
            this.cmbb_AdressTypes = new System.Windows.Forms.ComboBox();
            this.cmbb_MailTypes = new System.Windows.Forms.ComboBox();
            this.cmbb_PhoneTypes = new System.Windows.Forms.ComboBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lv_ContactInformation = new System.Windows.Forms.ListView();
            this.clm_Contact = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clm_Value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rtb_Adress = new System.Windows.Forms.RichTextBox();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.tb_Phone = new System.Windows.Forms.TextBox();
            this.lbl_Adress = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.cb_SendMail = new System.Windows.Forms.CheckBox();
            this.pb_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ni_NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tb_InfoMail = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.gb_PersonalInformations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_PictureBox)).BeginInit();
            this.gb_ContactInformations.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_PersonalInformations
            // 
            this.gb_PersonalInformations.Controls.Add(this.tb_IdNumber);
            this.gb_PersonalInformations.Controls.Add(this.lbl_IdentificationNumber);
            this.gb_PersonalInformations.Controls.Add(this.tb_Name);
            this.gb_PersonalInformations.Controls.Add(this.cmbb_MainLanguage);
            this.gb_PersonalInformations.Controls.Add(this.lbl_Level);
            this.gb_PersonalInformations.Controls.Add(this.trb_Level);
            this.gb_PersonalInformations.Controls.Add(this.lb_ForeignLanguage);
            this.gb_PersonalInformations.Controls.Add(this.lbl_ForeignLanguage);
            this.gb_PersonalInformations.Controls.Add(this.rb_Gender_NotGiven);
            this.gb_PersonalInformations.Controls.Add(this.rb_Gender_Female);
            this.gb_PersonalInformations.Controls.Add(this.rb_Gender_Male);
            this.gb_PersonalInformations.Controls.Add(this.pb_PictureBox);
            this.gb_PersonalInformations.Controls.Add(this.dtp_DateOfBirth);
            this.gb_PersonalInformations.Controls.Add(this.rtb_Description);
            this.gb_PersonalInformations.Controls.Add(this.lbl_Description);
            this.gb_PersonalInformations.Controls.Add(this.lbl_Gender);
            this.gb_PersonalInformations.Controls.Add(this.tb_Surname);
            this.gb_PersonalInformations.Controls.Add(this.lbl_Name);
            this.gb_PersonalInformations.Controls.Add(this.lbl_Surname);
            this.gb_PersonalInformations.Controls.Add(this.lbl_MainLanguage);
            this.gb_PersonalInformations.Controls.Add(this.lbl_DateOfBirth);
            this.gb_PersonalInformations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_PersonalInformations.Location = new System.Drawing.Point(12, 12);
            this.gb_PersonalInformations.Name = "gb_PersonalInformations";
            this.gb_PersonalInformations.Size = new System.Drawing.Size(321, 358);
            this.gb_PersonalInformations.TabIndex = 0;
            this.gb_PersonalInformations.TabStop = false;
            this.gb_PersonalInformations.Text = "Personal Informations";
            // 
            // tb_IdNumber
            // 
            this.tb_IdNumber.Location = new System.Drawing.Point(98, 32);
            this.tb_IdNumber.Name = "tb_IdNumber";
            this.tb_IdNumber.Size = new System.Drawing.Size(121, 20);
            this.tb_IdNumber.TabIndex = 1;
            this.tb_IdNumber.TabStop = false;
            this.tb_IdNumber.Tag = "ID Number";
            this.tb_IdNumber.Text = "11111111111";
            // 
            // lbl_IdentificationNumber
            // 
            this.lbl_IdentificationNumber.AutoSize = true;
            this.lbl_IdentificationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IdentificationNumber.Location = new System.Drawing.Point(35, 37);
            this.lbl_IdentificationNumber.Name = "lbl_IdentificationNumber";
            this.lbl_IdentificationNumber.Size = new System.Drawing.Size(58, 13);
            this.lbl_IdentificationNumber.TabIndex = 22;
            this.lbl_IdentificationNumber.Text = "ID Number";
            // 
            // tb_Name
            // 
            this.tb_Name.Location = new System.Drawing.Point(98, 60);
            this.tb_Name.Name = "tb_Name";
            this.tb_Name.Size = new System.Drawing.Size(121, 20);
            this.tb_Name.TabIndex = 2;
            this.tb_Name.Tag = "Name";
            this.tb_Name.Text = "aaaa";
            // 
            // cmbb_MainLanguage
            // 
            this.cmbb_MainLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbb_MainLanguage.FormattingEnabled = true;
            this.cmbb_MainLanguage.Location = new System.Drawing.Point(101, 177);
            this.cmbb_MainLanguage.Name = "cmbb_MainLanguage";
            this.cmbb_MainLanguage.Size = new System.Drawing.Size(118, 21);
            this.cmbb_MainLanguage.TabIndex = 21;
            this.cmbb_MainLanguage.Tag = "Main Language";
            // 
            // lbl_Level
            // 
            this.lbl_Level.AutoSize = true;
            this.lbl_Level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Level.Location = new System.Drawing.Point(261, 209);
            this.lbl_Level.Name = "lbl_Level";
            this.lbl_Level.Size = new System.Drawing.Size(14, 15);
            this.lbl_Level.TabIndex = 19;
            this.lbl_Level.Text = "1";
            // 
            // trb_Level
            // 
            this.trb_Level.Location = new System.Drawing.Point(228, 226);
            this.trb_Level.Name = "trb_Level";
            this.trb_Level.Size = new System.Drawing.Size(86, 45);
            this.trb_Level.TabIndex = 5;
            this.trb_Level.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trb_Level.Scroll += new System.EventHandler(this.tb_Level_Scroll);
            // 
            // lb_ForeignLanguage
            // 
            this.lb_ForeignLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ForeignLanguage.FormattingEnabled = true;
            this.lb_ForeignLanguage.ItemHeight = 15;
            this.lb_ForeignLanguage.Location = new System.Drawing.Point(98, 208);
            this.lb_ForeignLanguage.Name = "lb_ForeignLanguage";
            this.lb_ForeignLanguage.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_ForeignLanguage.Size = new System.Drawing.Size(121, 49);
            this.lb_ForeignLanguage.TabIndex = 18;
            this.lb_ForeignLanguage.Tag = "Foreign Language";
            // 
            // lbl_ForeignLanguage
            // 
            this.lbl_ForeignLanguage.AutoSize = true;
            this.lbl_ForeignLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ForeignLanguage.Location = new System.Drawing.Point(4, 208);
            this.lbl_ForeignLanguage.Name = "lbl_ForeignLanguage";
            this.lbl_ForeignLanguage.Size = new System.Drawing.Size(93, 13);
            this.lbl_ForeignLanguage.TabIndex = 17;
            this.lbl_ForeignLanguage.Text = "Foreign Language";
            // 
            // rb_Gender_NotGiven
            // 
            this.rb_Gender_NotGiven.AutoSize = true;
            this.rb_Gender_NotGiven.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Gender_NotGiven.Location = new System.Drawing.Point(98, 150);
            this.rb_Gender_NotGiven.Name = "rb_Gender_NotGiven";
            this.rb_Gender_NotGiven.Size = new System.Drawing.Size(73, 17);
            this.rb_Gender_NotGiven.TabIndex = 6;
            this.rb_Gender_NotGiven.Tag = "Not Given";
            this.rb_Gender_NotGiven.Text = "Not Given";
            this.rb_Gender_NotGiven.UseVisualStyleBackColor = true;
            // 
            // rb_Gender_Female
            // 
            this.rb_Gender_Female.AutoSize = true;
            this.rb_Gender_Female.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Gender_Female.Location = new System.Drawing.Point(230, 150);
            this.rb_Gender_Female.Name = "rb_Gender_Female";
            this.rb_Gender_Female.Size = new System.Drawing.Size(59, 17);
            this.rb_Gender_Female.TabIndex = 16;
            this.rb_Gender_Female.Tag = "Female";
            this.rb_Gender_Female.Text = "Female";
            this.rb_Gender_Female.UseVisualStyleBackColor = true;
            // 
            // rb_Gender_Male
            // 
            this.rb_Gender_Male.AutoSize = true;
            this.rb_Gender_Male.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Gender_Male.Location = new System.Drawing.Point(174, 150);
            this.rb_Gender_Male.Name = "rb_Gender_Male";
            this.rb_Gender_Male.Size = new System.Drawing.Size(48, 17);
            this.rb_Gender_Male.TabIndex = 5;
            this.rb_Gender_Male.Tag = "Male";
            this.rb_Gender_Male.Text = "Male";
            this.rb_Gender_Male.UseVisualStyleBackColor = true;
            // 
            // pb_PictureBox
            // 
            this.pb_PictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pb_PictureBox.Location = new System.Drawing.Point(225, 32);
            this.pb_PictureBox.Name = "pb_PictureBox";
            this.pb_PictureBox.Size = new System.Drawing.Size(80, 80);
            this.pb_PictureBox.TabIndex = 14;
            this.pb_PictureBox.TabStop = false;
            this.pb_PictureBox.Click += new System.EventHandler(this.ButtonClick);
            // 
            // dtp_DateOfBirth
            // 
            this.dtp_DateOfBirth.CustomFormat = "dd-MM-yyyy";
            this.dtp_DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(98, 118);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(121, 20);
            this.dtp_DateOfBirth.TabIndex = 13;
            this.dtp_DateOfBirth.Tag = "Date of Birth";
            this.dtp_DateOfBirth.Value = new System.DateTime(2024, 2, 29, 0, 0, 0, 0);
            // 
            // rtb_Description
            // 
            this.rtb_Description.Location = new System.Drawing.Point(98, 272);
            this.rtb_Description.Name = "rtb_Description";
            this.rtb_Description.Size = new System.Drawing.Size(216, 70);
            this.rtb_Description.TabIndex = 12;
            this.rtb_Description.Tag = "Description";
            this.rtb_Description.Text = "cccccccc";
            // 
            // lbl_Description
            // 
            this.lbl_Description.AutoSize = true;
            this.lbl_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Description.Location = new System.Drawing.Point(33, 272);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(60, 13);
            this.lbl_Description.TabIndex = 6;
            this.lbl_Description.Text = "Description";
            // 
            // lbl_Gender
            // 
            this.lbl_Gender.AutoSize = true;
            this.lbl_Gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Gender.Location = new System.Drawing.Point(51, 150);
            this.lbl_Gender.Name = "lbl_Gender";
            this.lbl_Gender.Size = new System.Drawing.Size(42, 13);
            this.lbl_Gender.TabIndex = 5;
            this.lbl_Gender.Text = "Gender";
            // 
            // tb_Surname
            // 
            this.tb_Surname.Location = new System.Drawing.Point(98, 88);
            this.tb_Surname.Name = "tb_Surname";
            this.tb_Surname.Size = new System.Drawing.Size(121, 20);
            this.tb_Surname.TabIndex = 3;
            this.tb_Surname.Tag = "Surname";
            this.tb_Surname.Text = "bbbb";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.Location = new System.Drawing.Point(57, 65);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(35, 13);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name";
            // 
            // lbl_Surname
            // 
            this.lbl_Surname.AutoSize = true;
            this.lbl_Surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Surname.Location = new System.Drawing.Point(43, 93);
            this.lbl_Surname.Name = "lbl_Surname";
            this.lbl_Surname.Size = new System.Drawing.Size(49, 13);
            this.lbl_Surname.TabIndex = 1;
            this.lbl_Surname.Text = "Surname";
            // 
            // lbl_MainLanguage
            // 
            this.lbl_MainLanguage.AutoSize = true;
            this.lbl_MainLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MainLanguage.Location = new System.Drawing.Point(16, 181);
            this.lbl_MainLanguage.Name = "lbl_MainLanguage";
            this.lbl_MainLanguage.Size = new System.Drawing.Size(81, 13);
            this.lbl_MainLanguage.TabIndex = 4;
            this.lbl_MainLanguage.Text = "Main Language";
            // 
            // lbl_DateOfBirth
            // 
            this.lbl_DateOfBirth.AutoSize = true;
            this.lbl_DateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DateOfBirth.Location = new System.Drawing.Point(26, 120);
            this.lbl_DateOfBirth.Name = "lbl_DateOfBirth";
            this.lbl_DateOfBirth.Size = new System.Drawing.Size(66, 13);
            this.lbl_DateOfBirth.TabIndex = 3;
            this.lbl_DateOfBirth.Text = "Date of Birth";
            // 
            // gb_ContactInformations
            // 
            this.gb_ContactInformations.Controls.Add(this.cb_AdressIsActive);
            this.gb_ContactInformations.Controls.Add(this.cb_EmailIsActive);
            this.gb_ContactInformations.Controls.Add(this.cmbb_AdressTypes);
            this.gb_ContactInformations.Controls.Add(this.cmbb_MailTypes);
            this.gb_ContactInformations.Controls.Add(this.cmbb_PhoneTypes);
            this.gb_ContactInformations.Controls.Add(this.btn_Add);
            this.gb_ContactInformations.Controls.Add(this.lv_ContactInformation);
            this.gb_ContactInformations.Controls.Add(this.rtb_Adress);
            this.gb_ContactInformations.Controls.Add(this.tb_Email);
            this.gb_ContactInformations.Controls.Add(this.tb_Phone);
            this.gb_ContactInformations.Controls.Add(this.lbl_Adress);
            this.gb_ContactInformations.Controls.Add(this.lbl_Email);
            this.gb_ContactInformations.Controls.Add(this.lbl_Phone);
            this.gb_ContactInformations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ContactInformations.Location = new System.Drawing.Point(339, 12);
            this.gb_ContactInformations.Name = "gb_ContactInformations";
            this.gb_ContactInformations.Size = new System.Drawing.Size(302, 316);
            this.gb_ContactInformations.TabIndex = 2;
            this.gb_ContactInformations.TabStop = false;
            this.gb_ContactInformations.Text = "Contact Informations";
            // 
            // cb_AdressIsActive
            // 
            this.cb_AdressIsActive.AutoSize = true;
            this.cb_AdressIsActive.Location = new System.Drawing.Point(285, 90);
            this.cb_AdressIsActive.Name = "cb_AdressIsActive";
            this.cb_AdressIsActive.Size = new System.Drawing.Size(15, 14);
            this.cb_AdressIsActive.TabIndex = 22;
            this.cb_AdressIsActive.UseVisualStyleBackColor = true;
            this.cb_AdressIsActive.CheckedChanged += new System.EventHandler(this.cb_AdressIsActive_CheckedChanged);
            // 
            // cb_EmailIsActive
            // 
            this.cb_EmailIsActive.AutoSize = true;
            this.cb_EmailIsActive.Location = new System.Drawing.Point(285, 60);
            this.cb_EmailIsActive.Name = "cb_EmailIsActive";
            this.cb_EmailIsActive.Size = new System.Drawing.Size(15, 14);
            this.cb_EmailIsActive.TabIndex = 21;
            this.cb_EmailIsActive.UseVisualStyleBackColor = true;
            this.cb_EmailIsActive.CheckedChanged += new System.EventHandler(this.cb_EmailIsActive_CheckedChanged);
            // 
            // cmbb_AdressTypes
            // 
            this.cmbb_AdressTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbb_AdressTypes.Enabled = false;
            this.cmbb_AdressTypes.FormattingEnabled = true;
            this.cmbb_AdressTypes.Location = new System.Drawing.Point(195, 85);
            this.cmbb_AdressTypes.Name = "cmbb_AdressTypes";
            this.cmbb_AdressTypes.Size = new System.Drawing.Size(86, 21);
            this.cmbb_AdressTypes.TabIndex = 20;
            this.cmbb_AdressTypes.Tag = "Adress";
            // 
            // cmbb_MailTypes
            // 
            this.cmbb_MailTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbb_MailTypes.Enabled = false;
            this.cmbb_MailTypes.FormattingEnabled = true;
            this.cmbb_MailTypes.Location = new System.Drawing.Point(195, 55);
            this.cmbb_MailTypes.Name = "cmbb_MailTypes";
            this.cmbb_MailTypes.Size = new System.Drawing.Size(86, 21);
            this.cmbb_MailTypes.TabIndex = 19;
            this.cmbb_MailTypes.Tag = "E-mail";
            // 
            // cmbb_PhoneTypes
            // 
            this.cmbb_PhoneTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbb_PhoneTypes.FormattingEnabled = true;
            this.cmbb_PhoneTypes.Location = new System.Drawing.Point(195, 25);
            this.cmbb_PhoneTypes.Name = "cmbb_PhoneTypes";
            this.cmbb_PhoneTypes.Size = new System.Drawing.Size(86, 21);
            this.cmbb_PhoneTypes.TabIndex = 14;
            this.cmbb_PhoneTypes.Tag = "Phone";
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(216, 158);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 18;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.ButtonClick);
            // 
            // lv_ContactInformation
            // 
            this.lv_ContactInformation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_ContactInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clm_Contact,
            this.clm_Type,
            this.clm_Value});
            this.lv_ContactInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_ContactInformation.FullRowSelect = true;
            this.lv_ContactInformation.GridLines = true;
            this.lv_ContactInformation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lv_ContactInformation.HideSelection = false;
            this.lv_ContactInformation.Location = new System.Drawing.Point(7, 189);
            this.lv_ContactInformation.Name = "lv_ContactInformation";
            this.lv_ContactInformation.Size = new System.Drawing.Size(289, 116);
            this.lv_ContactInformation.TabIndex = 17;
            this.lv_ContactInformation.Tag = "Contact Information";
            this.lv_ContactInformation.UseCompatibleStateImageBehavior = false;
            this.lv_ContactInformation.View = System.Windows.Forms.View.Details;
            // 
            // clm_Contact
            // 
            this.clm_Contact.Text = "Contact";
            this.clm_Contact.Width = 50;
            // 
            // clm_Type
            // 
            this.clm_Type.Text = "Type";
            // 
            // clm_Value
            // 
            this.clm_Value.Text = "Value";
            this.clm_Value.Width = 189;
            // 
            // rtb_Adress
            // 
            this.rtb_Adress.Enabled = false;
            this.rtb_Adress.Location = new System.Drawing.Point(68, 83);
            this.rtb_Adress.Name = "rtb_Adress";
            this.rtb_Adress.Size = new System.Drawing.Size(121, 68);
            this.rtb_Adress.TabIndex = 13;
            this.rtb_Adress.Tag = "Adress";
            this.rtb_Adress.Text = "eeee";
            // 
            // tb_Email
            // 
            this.tb_Email.Enabled = false;
            this.tb_Email.Location = new System.Drawing.Point(68, 53);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(121, 20);
            this.tb_Email.TabIndex = 9;
            this.tb_Email.Tag = "E-mail adress";
            this.tb_Email.Text = "akinincecik@gmail.com";
            // 
            // tb_Phone
            // 
            this.tb_Phone.Location = new System.Drawing.Point(68, 25);
            this.tb_Phone.Name = "tb_Phone";
            this.tb_Phone.Size = new System.Drawing.Size(121, 20);
            this.tb_Phone.TabIndex = 8;
            this.tb_Phone.Tag = "Phone Number";
            this.tb_Phone.Text = "05344508315";
            // 
            // lbl_Adress
            // 
            this.lbl_Adress.AutoSize = true;
            this.lbl_Adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Adress.Location = new System.Drawing.Point(18, 81);
            this.lbl_Adress.Name = "lbl_Adress";
            this.lbl_Adress.Size = new System.Drawing.Size(39, 13);
            this.lbl_Adress.TabIndex = 3;
            this.lbl_Adress.Text = "Adress";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.Location = new System.Drawing.Point(22, 58);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(35, 13);
            this.lbl_Email.TabIndex = 2;
            this.lbl_Email.Text = "E-mail";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Phone.Location = new System.Drawing.Point(19, 30);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(38, 13);
            this.lbl_Phone.TabIndex = 1;
            this.lbl_Phone.Text = "Phone";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(560, 384);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.ButtonClick);
            // 
            // cb_SendMail
            // 
            this.cb_SendMail.AutoSize = true;
            this.cb_SendMail.Location = new System.Drawing.Point(421, 374);
            this.cb_SendMail.Name = "cb_SendMail";
            this.cb_SendMail.Size = new System.Drawing.Size(80, 17);
            this.cb_SendMail.TabIndex = 4;
            this.cb_SendMail.Text = "Send EMail";
            this.cb_SendMail.UseVisualStyleBackColor = true;
            this.cb_SendMail.CheckedChanged += new System.EventHandler(this.cb_SendMail_CheckedChanged);
            // 
            // pb_OpenFileDialog
            // 
            this.pb_OpenFileDialog.FileName = "openFileDialog1";
            this.pb_OpenFileDialog.Tag = "openFileDialog1";
            // 
            // ni_NotifyIcon
            // 
            this.ni_NotifyIcon.Tag = "notifyIcon1";
            this.ni_NotifyIcon.Text = "notifyIcon1";
            this.ni_NotifyIcon.Visible = true;
            // 
            // tb_InfoMail
            // 
            this.tb_InfoMail.Enabled = false;
            this.tb_InfoMail.Location = new System.Drawing.Point(421, 395);
            this.tb_InfoMail.Name = "tb_InfoMail";
            this.tb_InfoMail.Size = new System.Drawing.Size(121, 20);
            this.tb_InfoMail.TabIndex = 22;
            this.tb_InfoMail.Tag = "Info Mail";
            this.tb_InfoMail.Text = "akinsendmail@gmail.com";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(12, 384);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 23;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.ButtonClick);
            // 
            // Frm_Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 433);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.tb_InfoMail);
            this.Controls.Add(this.cb_SendMail);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.gb_ContactInformations);
            this.Controls.Add(this.gb_PersonalInformations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Personal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personal Records";
            this.gb_PersonalInformations.ResumeLayout(false);
            this.gb_PersonalInformations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_PictureBox)).EndInit();
            this.gb_ContactInformations.ResumeLayout(false);
            this.gb_ContactInformations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_PersonalInformations;
        private System.Windows.Forms.Label lbl_Gender;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Surname;
        private System.Windows.Forms.Label lbl_MainLanguage;
        private System.Windows.Forms.Label lbl_DateOfBirth;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.DateTimePicker dtp_DateOfBirth;
        private System.Windows.Forms.RichTextBox rtb_Description;
        private System.Windows.Forms.TextBox tb_Surname;
        private System.Windows.Forms.GroupBox gb_ContactInformations;
        private System.Windows.Forms.Label lbl_Adress;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.RichTextBox rtb_Adress;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.TextBox tb_Phone;
        private System.Windows.Forms.ListView lv_ContactInformation;
        private System.Windows.Forms.ComboBox cmbb_MailTypes;
        private System.Windows.Forms.ComboBox cmbb_PhoneTypes;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ComboBox cmbb_AdressTypes;
        private System.Windows.Forms.PictureBox pb_PictureBox;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.CheckBox cb_SendMail;
        private System.Windows.Forms.OpenFileDialog pb_OpenFileDialog;
        private System.Windows.Forms.RadioButton rb_Gender_Female;
        private System.Windows.Forms.RadioButton rb_Gender_Male;
        private System.Windows.Forms.RadioButton rb_Gender_NotGiven;
        private System.Windows.Forms.ListBox lb_ForeignLanguage;
        private System.Windows.Forms.Label lbl_ForeignLanguage;
        private System.Windows.Forms.TrackBar trb_Level;
        private System.Windows.Forms.Label lbl_Level;
        private System.Windows.Forms.ComboBox cmbb_MainLanguage;
        private System.Windows.Forms.NotifyIcon ni_NotifyIcon;
        private System.Windows.Forms.ColumnHeader clm_Contact;
        private System.Windows.Forms.ColumnHeader clm_Type;
        private System.Windows.Forms.ColumnHeader clm_Value;
        private System.Windows.Forms.TextBox tb_Name;
        private System.Windows.Forms.TextBox tb_InfoMail;
        private System.Windows.Forms.TextBox tb_IdNumber;
        private System.Windows.Forms.Label lbl_IdentificationNumber;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.CheckBox cb_AdressIsActive;
        private System.Windows.Forms.CheckBox cb_EmailIsActive;
    }
}

