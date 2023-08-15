using Newtonsoft.Json.Linq;
using Register_A_Person_In_A_Database.Data.Enums;
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
        private People _personToUpdate; // Hold the person for updating

        public CreateForm(string token, People personToUpdate = null)
        {
            InitializeComponent();
            InitializeMarriageComboBox();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _token = token;

            if (personToUpdate != null)
            {
                _personToUpdate = personToUpdate;
                InitializeFormForUpdate();
            }
        }

        private void InitializeFormForUpdate()
        {
            // Set form title
            Text = "Update Person";

            // Populate form fields with existing person's data
            FirstNameTextBox.Text = _personToUpdate.FirstName;
            LastNameTextBox.Text = _personToUpdate.LastName;
            BirthdayPicker.Value = _personToUpdate.Birthday;
            PhoneNumberTextBox.Text = _personToUpdate.PhoneNumber;
            MarriageComboBox.SelectedItem = _personToUpdate.MarriageStatus;
            BirthplaceTextBox.Text = _personToUpdate.Birthplace;

            // Set job status checkboxes
            NotEmployedCheckBox.Checked = _personToUpdate.JobStatus == JobStatus.NotEmployed;
            EmployedCheckBox.Checked = _personToUpdate.JobStatus == JobStatus.Employed;

            // Set gender radio buttons
            MaleRadioButton.Checked = _personToUpdate.Gender == Gender.Male;
            FemaleRadioButton.Checked = _personToUpdate.Gender == Gender.Female;

            // Change CreateButton text to "Update"
            CreateButton.Text = "Update";
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

        private void InitializeMarriageComboBox()
        {
            MarriageComboBox.DataSource = Enum.GetValues(typeof(MarriageStatus));
            MarriageComboBox.DropDownStyle = ComboBoxStyle.DropDownList; // Set the drop-down style
        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarriageComboBox.DataSource = Enum.GetValues(typeof(MarriageStatus));
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
            // Set the text for each checkbox
            NotEmployedCheckBox.Text = JobStatus.NotEmployed.ToString();
            EmployedCheckBox.Text = JobStatus.Employed.ToString();

            // Add event handlers to checkboxes
            NotEmployedCheckBox.CheckedChanged += CheckBox_CheckedChanged;
            EmployedCheckBox.CheckedChanged += CheckBox_CheckedChanged;

            // Add event handlers to radio buttons
            MaleRadioButton.CheckedChanged += RadioButton_CheckedChanged;
            FemaleRadioButton.CheckedChanged += RadioButton_CheckedChanged;

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckBox = (CheckBox)sender;

            // Uncheck the other checkbox if this checkbox is checked
            if (clickedCheckBox.Checked)
            {
                if (clickedCheckBox == NotEmployedCheckBox)
                {
                    EmployedCheckBox.Checked = false;
                }
                else if (clickedCheckBox == EmployedCheckBox)
                {
                    NotEmployedCheckBox.Checked = false;
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;

            // Update gender based on the selected radio button
            if (selectedRadioButton.Checked)
            {
                if (selectedRadioButton == MaleRadioButton)
                {
                    FemaleRadioButton.Checked = false;
                }
                else if (selectedRadioButton == FemaleRadioButton)
                {
                    MaleRadioButton.Checked = false;
                }
            }
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text.Trim();

            var updatedPerson = new People
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                Birthday = BirthdayPicker.Value,
                PhoneNumber = PhoneNumberTextBox.Text,
                MarriageStatus = (MarriageStatus)MarriageComboBox.SelectedItem,
                Birthplace = BirthplaceTextBox.Text
            };

            // Check the state of each checkbox and add the corresponding enum value
            if (NotEmployedCheckBox.Checked)
            {
                updatedPerson.JobStatus = JobStatus.NotEmployed;
            }
            else if (EmployedCheckBox.Checked)
            {
                updatedPerson.JobStatus = JobStatus.Employed;
            }
            // Check the state of radio buttons and add the corresponding enum value
            if (MaleRadioButton.Checked)
            {
                updatedPerson.Gender = Gender.Male;
            }
            else if (FemaleRadioButton.Checked)
            {
                updatedPerson.Gender = Gender.Female;
            }

            bool actionSuccessful;

            if (_personToUpdate != null)
            {
                // Update existing person
                actionSuccessful = await UpdatePersonAsync(updatedPerson);
            }
            else
            {
                // Create new person
                actionSuccessful = await CreatePersonAsync(updatedPerson);
            }

            if (actionSuccessful && IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Action completed successfully!");
                Hide();
                using (var dataDisplayForm = new DataDisplayForm(_token))
                {
                    dataDisplayForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Failed to perform action. Please try again.");
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

        private async Task<bool> UpdatePersonAsync(People updatedPerson)
        {
            try
            {
                string accessToken = JObject.Parse(_token)["token"].ToString();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/People/{_personToUpdate.Id}", updatedPerson);
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
