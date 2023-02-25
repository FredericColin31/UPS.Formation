using DataContracts;
using Flurl.Http;
using Newtonsoft.Json;
using Services;

namespace IHM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var url = "http://localhost:5153/api/v1/Recipes";

            dataGridView1.DataSource = await url.GetJsonAsync<List<Recipe>>();
         }

        private void button2_Click(object sender, EventArgs e)
        {
            //var recipes = Factory.Instance?.GetAll();

            //var serializedRecipes = JsonConvert.SerializeObject(recipes);

            //File.AppendAllText(@"c:\temp\recipes.json", serializedRecipes);
        }
    }
}