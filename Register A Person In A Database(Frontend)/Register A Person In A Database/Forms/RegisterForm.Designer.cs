namespace Register_A_Person_In_A_Database
{
    partial class RegisterForm
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
            RegisterFormLabel = new Label();
            UsernameLabel = new Label();
            UsernameTextBox = new TextBox();
            FirstNameTextBox = new TextBox();
            FirstNameLabel = new Label();
            LastNameTextBox = new TextBox();
            LastNameLabel = new Label();
            EmailTextBox = new TextBox();
            Email = new Label();
            PasswordTextBox = new TextBox();
            Password = new Label();
            RoleLabel = new Label();
            RoleComboBox = new ComboBox();
            RegisterButton = new Button();
            SuspendLayout();
            // 
            // RegisterFormLabel
            // 
            RegisterFormLabel.AutoSize = true;
            RegisterFormLabel.Location = new Point(348, 9);
            RegisterFormLabel.Name = "RegisterFormLabel";
            RegisterFormLabel.Size = new Size(100, 25);
            RegisterFormLabel.TabIndex = 1;
            RegisterFormLabel.Text = "Register Form";
            RegisterFormLabel.UseCompatibleTextRendering = true;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(23, 47);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(74, 25);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username";
            UsernameLabel.UseCompatibleTextRendering = true;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(23, 75);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(125, 27);
            UsernameTextBox.TabIndex = 3;
            UsernameTextBox.TextChanged += UsernameTextBox_TextChanged;
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new Point(23, 148);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(125, 27);
            FirstNameTextBox.TabIndex = 5;
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Location = new Point(23, 120);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(79, 25);
            FirstNameLabel.TabIndex = 4;
            FirstNameLabel.Text = "First Name";
            FirstNameLabel.UseCompatibleTextRendering = true;
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new Point(177, 148);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(125, 27);
            LastNameTextBox.TabIndex = 7;
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Location = new Point(177, 120);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(77, 25);
            LastNameLabel.TabIndex = 6;
            LastNameLabel.Text = "Last Name";
            LastNameLabel.UseCompatibleTextRendering = true;
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(23, 219);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(125, 27);
            EmailTextBox.TabIndex = 9;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(23, 191);
            Email.Name = "Email";
            Email.Size = new Size(42, 25);
            Email.TabIndex = 8;
            Email.Text = "Email";
            Email.UseCompatibleTextRendering = true;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(23, 296);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(125, 27);
            PasswordTextBox.TabIndex = 11;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(23, 268);
            Password.Name = "Password";
            Password.Size = new Size(70, 25);
            Password.TabIndex = 10;
            Password.Text = "Password";
            Password.UseCompatibleTextRendering = true;
            Password.Click += Password_Click;
            // 
            // RoleLabel
            // 
            RoleLabel.AutoSize = true;
            RoleLabel.Location = new Point(177, 191);
            RoleLabel.Name = "RoleLabel";
            RoleLabel.Size = new Size(36, 25);
            RoleLabel.TabIndex = 12;
            RoleLabel.Text = "Role";
            RoleLabel.UseCompatibleTextRendering = true;
            // 
            // RoleComboBox
            // 
            RoleComboBox.FormattingEnabled = true;
            RoleComboBox.Location = new Point(177, 219);
            RoleComboBox.Name = "RoleComboBox";
            RoleComboBox.Size = new Size(151, 28);
            RoleComboBox.TabIndex = 13;
            // 
            // RegisterButton
            // 
            RegisterButton.AllowDrop = true;
            RegisterButton.AutoEllipsis = true;
            RegisterButton.Location = new Point(348, 312);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(94, 29);
            RegisterButton.TabIndex = 14;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RegisterButton);
            Controls.Add(RoleComboBox);
            Controls.Add(RoleLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(Password);
            Controls.Add(EmailTextBox);
            Controls.Add(Email);
            Controls.Add(LastNameTextBox);
            Controls.Add(LastNameLabel);
            Controls.Add(FirstNameTextBox);
            Controls.Add(FirstNameLabel);
            Controls.Add(UsernameTextBox);
            Controls.Add(UsernameLabel);
            Controls.Add(RegisterFormLabel);
            Name = "RegisterForm";
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label RegisterFormLabel;
        private Label UsernameLabel;
        private TextBox UsernameTextBox;
        private TextBox FirstNameTextBox;
        private Label FirstNameLabel;
        private TextBox LastNameTextBox;
        private Label LastNameLabel;
        private TextBox EmailTextBox;
        private Label Email;
        private TextBox PasswordTextBox;
        private Label Password;
        private Label RoleLabel;
        private ComboBox RoleComboBox;
        public Button RegisterButton;
    }
}