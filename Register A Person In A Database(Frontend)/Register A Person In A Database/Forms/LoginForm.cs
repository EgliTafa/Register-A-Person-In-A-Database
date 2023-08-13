using Register_A_Person_In_A_Database.Forms;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace Register_A_Person_In_A_Database
{
    public partial class LoginForm : Form
    {
        private const string BaseUrl = "https://localhost:7295";
        private HttpClient _httpClient;

        public LoginForm()
        {
            InitializeComponent();

            // Attach the Click event handler to the LoginButton
            LoginButton.Click += LoginButton_Click;

            // Initialize the HttpClient and set base address
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Handle the Click event of the LoginButton
        private async void LoginButton_Click(object sender, EventArgs e)
        {
            var loginModel = new
            {
                Username = UsernameTextBox.Text,
                Password = PasswordTextBox.Text
            };

            try
            {
                // Send a POST request to the authentication API endpoint
                var response = await _httpClient.PostAsJsonAsync("api/Authentication/Login", loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();

                    // Save the token in the HttpClient headers for subsequent requests
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Show a success message and open the DataDisplayForm
                    MessageBox.Show("Login successful.");
                    Hide(); // Hide the login form
                    using (var dataDisplayForm = new DataDisplayForm(token))
                    {
                        dataDisplayForm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Login failed. Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        // Handle the Click event of the RegisterRedirect button
        private void RegisterRedirect_Click(object sender, EventArgs e)
        {
            Hide(); // Hide the current form
            using (var registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
        }
    }
}
