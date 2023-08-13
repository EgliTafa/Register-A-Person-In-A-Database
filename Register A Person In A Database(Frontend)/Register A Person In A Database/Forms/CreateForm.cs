using Newtonsoft.Json.Linq;
using Register_A_Person_In_A_Database.Data.Model;
using Register_A_Person_In_A_Database_.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_A_Person_In_A_Database.Forms
{
    public partial class CreateForm : Form
    {
        private const string BaseUrl = "https://localhost:7295";
        private readonly HttpClient _httpClient;
        private string _token;
        public CreateForm(string token)
        {
            InitializeComponent();
            InitializeJobStatusComboBox();
            InitializeMarriageStatusComboBox();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _token = token; // This should initialize the _token field with the passed token.
            //LoadDataAsync();
        }

        private void UsernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void RoleLabel_Click(object sender, EventArgs e)
        {

        }

        private void InitializeJobStatusComboBox()
        {
            JobStatusComboBox.DataSource = Enum.GetValues(typeof(JobStatus));
        }
        private void InitializeMarriageStatusComboBox()
        {
            MarriageStatusComboBox.DataSource = Enum.GetValues(typeof(MarriageStatus));
        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarriageStatusComboBox.DataSource = Enum.GetValues(typeof(MarriageStatus));

        }

        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            using (var createForm = new DataDisplayForm(_token))
            {
                createForm.ShowDialog();
            }

        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text.Trim();

            var newPerson = new People
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Birthday = BirthdayPicker.Value,
                PhoneNumber = PhoneNumberTextBox.Text,
                MarriageStatus = (MarriageStatus)MarriageStatusComboBox.SelectedItem,
                JobStatus = (JobStatus)JobStatusComboBox.SelectedItem,
                Birthplace = BirthplaceTextBox.Text
            };

            bool created = await CreatePersonAsync(newPerson);

            if (created && IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Person created successfully!");
                Hide(); // Hide the login form
                using (var dataDisplayForm = new DataDisplayForm(_token))
                {
                    dataDisplayForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Failed to create person. Please try again.");
            }
        }

        private async Task<bool> CreatePersonAsync(People person)
        {
            try
            {
                string accessToken = JObject.Parse(_token)["token"].ToString();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/People", person);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Define a regular expression pattern for a valid phone number
            // This is a simplified pattern, you can customize it based on your needs
            string pattern = @"^(355\d{9}|0\d{9})$"; // Examples: 355123456789, 0123456789
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
