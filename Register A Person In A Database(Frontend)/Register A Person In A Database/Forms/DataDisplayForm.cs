using Newtonsoft.Json.Linq;
using Register_A_Person_In_A_Database.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_A_Person_In_A_Database.Forms
{
    public partial class DataDisplayForm : Form
    {
        private const string BaseUrl = "https://localhost:7295";
        private readonly HttpClient _httpClient;
        private string _token;

        public DataDisplayForm(string token)
        {
            InitializeComponent();

            // Initialize the HTTP client and set base address
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Set the token for authorization
            _token = token;

            // Load data asynchronously upon form initialization
            LoadDataAsync();
        }

        // Load data from the API and populate the DataGridView
        private async Task LoadDataAsync()
        {
            try
            {
                // Parse the token JSON and extract the access token
                string tokenJson = _token;
                var tokenObject = JObject.Parse(tokenJson);
                string accessToken = tokenObject["token"].ToString();

                // Set authorization header
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // Send a GET request to retrieve people data
                HttpResponseMessage response = await _httpClient.GetAsync("api/People");
                response.EnsureSuccessStatusCode();

                // Deserialize the response content into a list of People objects
                var people = await response.Content.ReadAsAsync<List<People>>();

                // Clear existing columns and data source
                peopleDataGridView.Columns.Clear();
                peopleDataGridView.DataSource = null;

                // Set the DataGridView data source
                peopleDataGridView.DataSource = people;

                // Add delete and update button columns to the DataGridView
                AddDeleteAndEditButtonColumns();
            }
            catch (HttpRequestException ex)
            {
                // Display an error message if data loading fails
                MessageBox.Show($"Error: {ex.Message}", "Data Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle logout button click event
        private async void LogoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                string accessToken = JObject.Parse(_token)["token"].ToString();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response = await _httpClient.PostAsync("api/Authentication/Logout", null);
                response.EnsureSuccessStatusCode();

                // Show a success message and open the login form
                MessageBox.Show("Logout successful.");
                Close(); // Close the current form
                using (var loginForm = new LoginForm())
                {
                    loginForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Handle label click event (if applicable)
        private void label1_Click(object sender, EventArgs e)
        {
            // Additional code can be added here if needed
        }

        // Add delete and update button columns to the DataGridView
        private void AddDeleteAndEditButtonColumns()
        {
            // Remove existing delete button column
            if (peopleDataGridView.Columns.Contains("DeleteButtonColumn"))
            {
                peopleDataGridView.Columns.Remove("DeleteButtonColumn");
            }

            // Remove existing update button column
            if (peopleDataGridView.Columns.Contains("UpdateButtonColumn"))
            {
                peopleDataGridView.Columns.Remove("UpdateButtonColumn");
            }

            // Add a new column for the delete button
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.Name = "DeleteButtonColumn";
            deleteButtonColumn.Text = "Delete";
            deleteButtonColumn.UseColumnTextForButtonValue = true;

            // Add a new column for the update button
            DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn();
            updateButtonColumn.Name = "UpdateButtonColumn";
            updateButtonColumn.Text = "Update";
            updateButtonColumn.UseColumnTextForButtonValue = true;

            // Attach the CellBeginEdit event handler
            peopleDataGridView.CellBeginEdit += DataGridView_CellBeginEdit;

            // Add the columns to the DataGridView
            peopleDataGridView.Columns.AddRange(deleteButtonColumn, updateButtonColumn);
        }

        // Handle cell content click events in the DataGridView
        private async void peopleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == peopleDataGridView.Columns["DeleteButtonColumn"].Index)
                {
                    // Delete button clicked
                    if (peopleDataGridView.Rows[e.RowIndex].DataBoundItem is People selectedPerson)
                    {
                        // Call the DeletePersonAsync method and refresh data if deletion is successful
                        bool deleted = await DeletePersonAsync(selectedPerson.Id);
                        if (deleted)
                        {
                            await LoadDataAsync();
                        }
                    }
                }
                else if (e.ColumnIndex == peopleDataGridView.Columns["UpdateButtonColumn"].Index)
                {
                    // Update button clicked
                    if (peopleDataGridView.Rows[e.RowIndex].DataBoundItem is People selectedPerson)
                    {
                        // Open the update form with selected person's ID
                        Hide();
                        using (var updateForm = new CreateForm(_token, selectedPerson))
                        {
                            updateForm.ShowDialog();
                        }
                    }
                }
            }
        }

        // Handle the CellBeginEdit event to prevent double-click editing
        private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Cancel the edit action
            e.Cancel = true;
        }

        // Delete a person asynchronously
        private async Task<bool> DeletePersonAsync(int id)
        {
            try
            {
                // Send a DELETE request to delete the specified person
                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/People/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        // Handle refresh button click event
        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            // Refresh data asynchronously
            await LoadDataAsync();
        }

        // Handle create button click event
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // Hide the current form and show the create form
            Hide();
            using (var createForm = new CreateForm(_token))
            {
                createForm.ShowDialog();
            }
        }

        // Handle form load event (if applicable)
        private void DataDisplayForm_Load(object sender, EventArgs e)
        {
            // Additional code can be added here if needed
        }

        // Handle search button click event
        private async void SearchButton_Click(object sender, EventArgs e)
        {
            // Trim and retrieve the search name
            string searchName = SearchTextBox.Text.Trim();

            try
            {
                // Parse the token JSON and extract the access token
                string tokenJson = _token;
                var tokenObject = JObject.Parse(tokenJson);
                string accessToken = tokenObject["token"].ToString();

                // Set authorization header
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage response;

                // If the search name is empty, load all items
                if (string.IsNullOrWhiteSpace(searchName))
                {
                    response = await _httpClient.GetAsync("api/People");
                }
                else
                {
                    // Send a GET request to search for people by name
                    response = await _httpClient.GetAsync($"api/People/search?name={searchName}");
                }

                response.EnsureSuccessStatusCode();

                // Deserialize the response content into a list of People objects
                var filteredPeople = await response.Content.ReadAsAsync<List<People>>();

                // Set the DataGridView data source
                peopleDataGridView.DataSource = filteredPeople;

                // Update the columns including delete and update buttons
                AddDeleteAndEditButtonColumns();
            }
            catch (HttpRequestException ex)
            {
                // Display an error message if data loading fails
                MessageBox.Show($"Error: {ex.Message}", "Data Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
