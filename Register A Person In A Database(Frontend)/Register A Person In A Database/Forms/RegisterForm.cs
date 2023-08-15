using Register_A_Person_In_A_Database.Forms;
using Register_A_Person_In_A_Database_.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_A_Person_In_A_Database
{
    public partial class RegisterForm : Form
    {
        private const string BaseUrl = "https://localhost:7295";
        private readonly HttpClient _httpClient;

        public RegisterForm()
        {
            InitializeComponent();
            InitializeRoleComboBox();
            RegisterButton.Click += RegisterButton_Click;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            var registrationDto = new
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text,
                FirstName = FirstNameLabel.Text,
                LastName = LastNameLabel.Text,
                Role = RoleComboBox.SelectedItem.ToString(), // Assuming a ComboBox for roles
                Email = EmailTextBox.Text
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Authentication/Register", registrationDto);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Registration successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                using (var dataDisplayForm = new LoginForm())
                {
                    dataDisplayForm.ShowDialog();
                }
                Close();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
        }

        private void RegisterFormLabel_Click(object sender, EventArgs e)
        {
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void InitializeRoleComboBox()
        {
            RoleComboBox.DataSource = Enum.GetValues(typeof(Roles));
            RoleComboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Set the drop-down style to read-only
        }
    }
}
