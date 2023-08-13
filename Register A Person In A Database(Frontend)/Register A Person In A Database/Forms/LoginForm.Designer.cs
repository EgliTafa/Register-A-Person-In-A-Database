namespace Register_A_Person_In_A_Database
{
    partial class LoginForm
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
            UsernameTextBox = new TextBox();
            UsernameLabel = new Label();
            RegisterFormLabel = new Label();
            PasswordTextBox = new TextBox();
            Password = new Label();
            LoginButton = new Button();
            RegisterRedirect = new Button();
            SuspendLayout();
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(25, 75);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(125, 27);
            UsernameTextBox.TabIndex = 6;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(25, 47);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(74, 25);
            UsernameLabel.TabIndex = 5;
            UsernameLabel.Text = "Username";
            UsernameLabel.UseCompatibleTextRendering = true;
            // 
            // RegisterFormLabel
            // 
            RegisterFormLabel.AutoSize = true;
            RegisterFormLabel.Location = new Point(350, 9);
            RegisterFormLabel.Name = "RegisterFormLabel";
            RegisterFormLabel.Size = new Size(83, 25);
            RegisterFormLabel.TabIndex = 4;
            RegisterFormLabel.Text = "Login Form";
            RegisterFormLabel.UseCompatibleTextRendering = true;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(25, 158);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(125, 27);
            PasswordTextBox.TabIndex = 13;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(25, 130);
            Password.Name = "Password";
            Password.Size = new Size(70, 25);
            Password.TabIndex = 12;
            Password.Text = "Password";
            Password.UseCompatibleTextRendering = true;
            // 
            // LoginButton
            // 
            LoginButton.AllowDrop = true;
            LoginButton.AutoEllipsis = true;
            LoginButton.Location = new Point(25, 205);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 29);
            LoginButton.TabIndex = 15;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            // 
            // RegisterRedirect
            // 
            RegisterRedirect.AllowDrop = true;
            RegisterRedirect.AutoEllipsis = true;
            RegisterRedirect.Location = new Point(25, 261);
            RegisterRedirect.Name = "RegisterRedirect";
            RegisterRedirect.Size = new Size(94, 29);
            RegisterRedirect.TabIndex = 16;
            RegisterRedirect.Text = "Register";
            RegisterRedirect.UseVisualStyleBackColor = true;
            RegisterRedirect.Click += RegisterRedirect_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RegisterRedirect);
            Controls.Add(LoginButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(Password);
            Controls.Add(UsernameTextBox);
            Controls.Add(UsernameLabel);
            Controls.Add(RegisterFormLabel);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameTextBox;
        private Label UsernameLabel;
        private Label RegisterFormLabel;
        private TextBox PasswordTextBox;
        private Label Password;
        public Button LoginButton;
        public Button RegisterRedirect;
    }
}