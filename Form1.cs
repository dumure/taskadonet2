namespace task_ado_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                var carsDB = new CarsDB();
                var cars = carsDB.GetCars();
                List<Car> result = new List<Car>();
                if (radioButton1.Checked)
                {
                    foreach (var car in cars)
                    {
                        if (car.Mark.Contains(textBox1.Text))
                        {
                            result.Add(car);
                        }
                    }
                }
                else
                {
                    foreach (var car in cars)
                    {
                        if (car.Model.Contains(textBox1.Text))
                        {
                            result.Add(car);
                        }
                    }
                }
                listBox1.DataSource = null;
                listBox1.DataSource = result;
            }
        }
    }
}
