namespace Arduino_connection
{
    public partial class Form1 : Form
    {
        private const string ArduinoURL = "http://192.168.147.90";
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using var httpClient = new HttpClient();

            try
            {
                string valueToSend = inputTextBox.Text; // Get text from TextBox
                var content = new StringContent(valueToSend, System.Text.Encoding.UTF8, "text/plain");
                HttpResponseMessage response = await httpClient.PostAsync(ArduinoURL, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                resultLabel.Text = "Response from Arduino:\n" + responseBody;
            }
            catch (HttpRequestException ex)
            {
                resultLabel.Text = $"Request exception: {ex.Message}";
            }
        }
    }
}