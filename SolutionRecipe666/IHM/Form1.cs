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
            var obj = new ObjectRecipesService();

            dataGridView1.DataSource = obj.GetAll();
        }
    }
}