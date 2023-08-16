namespace Register_A_Person_In_A_Database.Forms
{
    partial class CreateForm
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
            FirstNameTextBox = new TextBox();
            UsernameLabel = new Label();
            LastNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            BirthdayPicker = new DateTimePicker();
            PhoneNumberTextBox = new TextBox();
            label3 = new Label();
            BirthplaceTextBox = new TextBox();
            label4 = new Label();
            RoleLabel = new Label();
            label5 = new Label();
            CreateButton = new Button();
            GoBackButton = new Button();
            EmploymentCheckBox = new CheckBox();
            GenderLabel = new Label();
            MaleRadioButton = new RadioButton();
            FemaleRadioButton = new RadioButton();
            MarriageComboBox = new ComboBox();
            SuspendLayout();
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new Point(12, 37);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(125, 27);
            FirstNameTextBox.TabIndex = 5;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(12, 9);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(79, 25);
            UsernameLabel.TabIndex = 4;
            UsernameLabel.Text = "First Name";
            UsernameLabel.UseCompatibleTextRendering = true;
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new Point(12, 115);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(125, 27);
            LastNameTextBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 87);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 6;
            label1.Text = "Last Name";
            label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 169);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 8;
            label2.Text = "Birthday";
            label2.UseCompatibleTextRendering = true;
            // 
            // BirthdayPicker
            // 
            BirthdayPicker.Location = new Point(12, 197);
            BirthdayPicker.Name = "BirthdayPicker";
            BirthdayPicker.Size = new Size(163, 27);
            BirthdayPicker.TabIndex = 9;
            // 
            // PhoneNumberTextBox
            // 
            PhoneNumberTextBox.Location = new Point(12, 272);
            PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            PhoneNumberTextBox.Size = new Size(125, 27);
            PhoneNumberTextBox.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 244);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 10;
            label3.Text = "Phone Number";
            label3.UseCompatibleTextRendering = true;
            // 
            // BirthplaceTextBox
            // 
            BirthplaceTextBox.Location = new Point(12, 344);
            BirthplaceTextBox.Name = "BirthplaceTextBox";
            BirthplaceTextBox.Size = new Size(125, 27);
            BirthplaceTextBox.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 316);
            label4.Name = "label4";
            label4.Size = new Size(73, 25);
            label4.TabIndex = 12;
            label4.Text = "Birthplace";
            label4.UseCompatibleTextRendering = true;
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(226, 9);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(75, 25);
            RoleLabel.TabIndex = 14;
            RoleLabel.Text = "Job Status";
            RoleLabel.UseCompatibleTextRendering = true;
            RoleLabel.Click += RoleLabel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(226, 97);
            label5.Name = "label5";
            label5.Size = new Size(113, 25);
            label5.TabIndex = 16;
            label5.Text = "Marriage Status";
            label5.UseCompatibleTextRendering = true;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(433, 320);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(94, 29);
            CreateButton.TabIndex = 18;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // GoBackButton
            // 
            GoBackButton.Location = new Point(433, 364);
            GoBackButton.Name = "GoBackButton";
            GoBackButton.Size = new Size(94, 29);
            GoBackButton.TabIndex = 19;
            GoBackButton.Text = "Go Back";
            GoBackButton.UseVisualStyleBackColor = true;
            GoBackButton.Click += GoBackButton_Click;
            // 
            // EmploymentCheckBox
            // 
            EmploymentCheckBox.AutoSize = true;
            EmploymentCheckBox.Location = new Point(226, 40);
            EmploymentCheckBox.Name = "EmploymentCheckBox";
            EmploymentCheckBox.Size = new Size(98, 24);
            EmploymentCheckBox.TabIndex = 21;
            EmploymentCheckBox.Text = "Employed";
            EmploymentCheckBox.UseVisualStyleBackColor = true;
            // 
            // GenderLabel
            // 
            GenderLabel.AutoSize = true;
            GenderLabel.Location = new Point(226, 169);
            GenderLabel.Name = "GenderLabel";
            GenderLabel.Size = new Size(55, 25);
            GenderLabel.TabIndex = 22;
            GenderLabel.Text = "Gender";
            GenderLabel.UseCompatibleTextRendering = true;
            // 
            // MaleRadioButton
            // 
            MaleRadioButton.AutoSize = true;
            MaleRadioButton.Location = new Point(226, 200);
            MaleRadioButton.Name = "MaleRadioButton";
            MaleRadioButton.Size = new Size(63, 24);
            MaleRadioButton.TabIndex = 23;
            MaleRadioButton.TabStop = true;
            MaleRadioButton.Text = "Male";
            MaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // FemaleRadioButton
            // 
            FemaleRadioButton.AutoSize = true;
            FemaleRadioButton.Location = new Point(226, 230);
            FemaleRadioButton.Name = "FemaleRadioButton";
            FemaleRadioButton.Size = new Size(78, 24);
            FemaleRadioButton.TabIndex = 24;
            FemaleRadioButton.TabStop = true;
            FemaleRadioButton.Text = "Female";
            FemaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // MarriageComboBox
            // 
            MarriageComboBox.FormattingEnabled = true;
            MarriageComboBox.Location = new Point(226, 125);
            MarriageComboBox.Name = "MarriageComboBox";
            MarriageComboBox.Size = new Size(151, 28);
            MarriageComboBox.TabIndex = 25;
            // 
            // CreateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MarriageComboBox);
            Controls.Add(FemaleRadioButton);
            Controls.Add(MaleRadioButton);
            Controls.Add(GenderLabel);
            Controls.Add(EmploymentCheckBox);
            Controls.Add(GoBackButton);
            Controls.Add(CreateButton);
            Controls.Add(label5);
            Controls.Add(RoleLabel);
            Controls.Add(BirthplaceTextBox);
            Controls.Add(label4);
            Controls.Add(PhoneNumberTextBox);
            Controls.Add(label3);
            Controls.Add(BirthdayPicker);
            Controls.Add(label2);
            Controls.Add(LastNameTextBox);
            Controls.Add(label1);
            Controls.Add(FirstNameTextBox);
            Controls.Add(UsernameLabel);
            Name = "CreateForm";
            Text = "CreateForm";
            Load += CreateForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FirstNameTextBox;
        private Label UsernameLabel;
        private TextBox LastNameTextBox;
        private Label label1;
        private Label label2;
        private DateTimePicker BirthdayPicker;
        private TextBox PhoneNumberTextBox;
        private Label label3;
        private TextBox BirthplaceTextBox;
        private Label label4;
        private Label RoleLabel;
        private ComboBox MarriageStatusComboBox;
        private Label label5;
        private Button CreateButton;
        private Button GoBackButton;
        private CheckBox EmploymentCheckBox;
        private Label GenderLabel;
        private RadioButton MaleRadioButton;
        private RadioButton FemaleRadioButton;
        private ComboBox MarriageComboBox;
    }
}