namespace Register_A_Person_In_A_Database.Forms
{
    partial class DataDisplayForm
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
            LogoutButton = new Button();
            peopleDataGridView = new DataGridView();
            RefreshButton = new Button();
            CreateButton = new Button();
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            ((System.ComponentModel.ISupportInitialize)peopleDataGridView).BeginInit();
            SuspendLayout();
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(694, 374);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(94, 29);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // peopleDataGridView
            // 
            peopleDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            peopleDataGridView.Location = new Point(12, 45);
            peopleDataGridView.Name = "peopleDataGridView";
            peopleDataGridView.RowHeadersWidth = 51;
            peopleDataGridView.RowTemplate.Height = 29;
            peopleDataGridView.Size = new Size(776, 288);
            peopleDataGridView.TabIndex = 1;
            peopleDataGridView.CellContentClick += peopleDataGridView_CellContentClick;
            // 
            // RefreshButton
            // 
            RefreshButton.Location = new Point(694, 409);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(94, 29);
            RefreshButton.TabIndex = 2;
            RefreshButton.Text = "Refresh";
            RefreshButton.UseVisualStyleBackColor = true;
            RefreshButton.Click += RefreshButton_Click;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(12, 339);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(94, 29);
            CreateButton.TabIndex = 3;
            CreateButton.Text = "Create";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(132, 12);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(462, 27);
            SearchTextBox.TabIndex = 4;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(623, 12);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(94, 29);
            SearchButton.TabIndex = 5;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // DataDisplayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(CreateButton);
            Controls.Add(RefreshButton);
            Controls.Add(peopleDataGridView);
            Controls.Add(LogoutButton);
            Name = "DataDisplayForm";
            Text = "DataDisplayForm";
            Load += DataDisplayForm_Load;
            ((System.ComponentModel.ISupportInitialize)peopleDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LogoutButton;
        private DataGridView peopleDataGridView;
        private Button RefreshButton;
        private Button CreateButton;
        private TextBox SearchTextBox;
        private Button SearchButton;
    }
}