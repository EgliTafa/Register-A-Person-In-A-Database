using Newtonsoft.Json.Linq;
using Register_A_Person_In_A_Database.Data.Model;
using Register_A_Person_In_A_Database_.Data.Enums;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_A_Person_In_A_Database.Forms
{
    public partial class UpdateForm : Form
    {
        private const string BaseUrl = "https://localhost:7295";
        private readonly HttpClient _httpClient;
        private string _token;
        private int _personId;

        public UpdateForm(string token, int personId)
        {
            InitializeComponent();
            InitializeJobStatusComboBox();
            InitializeMarriageStatusComboBox();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _token = token; // Initialize the _token field with the passed token.
            _personId = personId; // Initialize the _personId field with the passed personId.
            LoadPersonDataAsync();
        }

        // Load person data asynchronously and populate form controls
        private async Task LoadPersonDataAsync()
        {
            try
            {
                string accessToken = JObject.Parse(_token)["token"].ToString();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await _httpClient.GetAsync($"api/People/{_personId}");
                response.EnsureSuccessStatusCode();

                var person = await response.Content.ReadAsAsync<People>();

                // Load person data into the form controls
                FirstNameTextBox.Text = person.FirstName;
                LastNameTextBox.Text = person.LastName;
                BirthdayPicker.Value = person.Birthday;
                PhoneNumberTextBox.Text = person.PhoneNumber;
                MarriageStatusComboBox.SelectedItem = person.MarriageStatus;
                JobStatusComboBox.SelectedItem = person.JobStatus;
                BirthplaceTextBox.Text = person.Birthplace;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Data Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Initialize the JobStatus combo box with enum values
        private void InitializeJobStatusComboBox()
        {
            JobStatusComboBox.DataSource = Enum.GetValues(typeof(JobStatus));
        }

        // Initialize the MarriageStatus combo box with enum values
        private void InitializeMarriageStatusComboBox()
        {
            MarriageStatusComboBox.DataSource = Enum.GetValues(typeof(MarriageStatus));
        }

        // Handle UpdateButton click event
        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text.Trim();

            var updatedPerson = new People
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Birthday = BirthdayPicker.Value,
                PhoneNumber = PhoneNumberTextBox.Text,
                MarriageStatus = (MarriageStatus)MarriageStatusComboBox.SelectedItem,
                JobStatus = (JobStatus)JobStatusComboBox.SelectedItem,
                Birthplace = BirthplaceTextBox.Text
            };

            bool updated = await UpdatePersonAsync(_personId, updatedPerson);

            if (updated && IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Person updated successfully!");
                Close(); // Close the update form
            }
            else
            {
                MessageBox.Show("Failed to update person. Please try again.");
            }
        }

        // Update a person asynchronously using the API
        private async Task<bool> UpdatePersonAsync(int personId, People updatedPerson)
        {
            try
            {
                string accessToken = JObject.Parse(_token)["token"].ToString();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/People/{personId}", updatedPerson);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        // Validate the phone number using a regular expression pattern
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Define a regular expression pattern for a valid phone number
            string pattern = @"^(355\d{9}|0\d{9})$"; // Examples: 355123456789, 0123456789
            return Regex.IsMatch(phoneNumber, pattern);
        }

        // Handle GoBackButton click event
        private void GoBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            using (var dataDisplayForm = new DataDisplayForm(_token))
            {
                dataDisplayForm.ShowDialog();
            }
        }
    }
}
