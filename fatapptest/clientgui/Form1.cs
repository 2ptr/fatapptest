using System.Security.Policy;
using System.Text.Json.Nodes;
using System.Text;
using api_backend.Controllers;
using api_backend.Dtos;
using Newtonsoft.Json;

namespace clientgui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var foodModel = new CreateFoodRequest()
            {
                Name = textBox1.Text,
                Count = Convert.ToInt32(numericUpDown1.Value),
                IsHealthy = checkBox1.Checked
            };
            using (HttpClient client = new HttpClient())
            {
                var jsonObject = JsonConvert.SerializeObject(foodModel);
                var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                var result = client.PostAsync("http://localhost:5128/api/food", content).Result;
            }
        }

        private async void GetAllButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5128/api/food");
                string message = await response.Content.ReadAsStringAsync();
                JsonDisplay.Text = message;
            }
        }
    }
}
