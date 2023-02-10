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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Factory.Instance?.GetAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var recipes = Factory.Instance?.GetAll();

            var serializedRecipes = JsonConvert.SerializeObject(recipes);

            File.AppendAllText(@"c:\temp\recipes.json", serializedRecipes);
        }
    }
}