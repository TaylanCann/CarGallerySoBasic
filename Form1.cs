using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        List<string> Brands = new List<string>();
        List<Cars> SavedCars = new List<Cars>();
        public class Cars
        {
            public string Brand;
            public string Model;
            public string Fuel;
            public double EngineCapasity;
            public string Color;
            public string Year;
            public int Kilometer;
            public decimal Price;
            public string PhoneNumber;
        }

        public void loadBrads()
        {
            Brands.Add("Fiat");
            Brands.Add("Hyundai");
            Brands.Add("Ford");
            Brands.Add("Renault");
            Brands.Add("Volvo");
            Brands.Add("Mercedes");
            Brands.Add("BMW");
        }



        public Form1()
        {
            InitializeComponent();
            loadBrads();
            start();

        }

        public void start()
        {
            foreach (var item in Brands)
            {
                cbBrands.Items.Add(item);
            }

            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Marka";
            dataGridView1.Columns[1].Name = "Model";
            dataGridView1.Columns[2].Name = "Yakıt";
            dataGridView1.Columns[3].Name = "Motor Hacmi";
            dataGridView1.Columns[4].Name = "Renk";
            dataGridView1.Columns[5].Name = "Yıl";
            dataGridView1.Columns[6].Name = "Kilometre";
            dataGridView1.Columns[7].Name = "Fiyat";
            dataGridView1.Columns[8].Name = "Cep Telefonu";

        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            string rbCheck = "Seçilmedi";
            if (rbDiesel.Checked == true)
            {
                rbCheck = "Dizel";
            }
            else if (rbGas.Checked == true)
            {
                rbCheck = "LPG";
            }
            else if (rbGasoline.Checked == true)
            {
                rbCheck = "Benzin";
            }
            else
            {
                MessageBox.Show("Lütfen Seçim yapınız");
            }

            Cars car = new Cars();
            car.Brand = cbBrands.SelectedItem.ToString();
            car.Color = txtColor.Text.ToString();
            car.EngineCapasity = int.Parse(txtEngineCapacity.Text);
            car.Fuel = rbCheck.ToString();
            car.Kilometer = int.Parse(txtKm.Text);
            car.Model = txtModel.Text.ToString();
            car.PhoneNumber = txtPhone.Text.ToString();
            car.Price = decimal.Parse(txtPrice.Text);
            car.Year = txtYear.Text.ToString();

            SavedCars.Add(car);

            Listing();
        }

        private void Listing()
        {
            SavedCars = SavedCars.OrderBy(x => x.Brand).ToList();
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(SavedCars.Count);

            for (int i = 0; i < SavedCars.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = SavedCars[i].Brand;
                dataGridView1.Rows[i].Cells[1].Value = SavedCars[i].Model;
                dataGridView1.Rows[i].Cells[2].Value = SavedCars[i].Fuel;
                dataGridView1.Rows[i].Cells[3].Value = SavedCars[i].EngineCapasity;
                dataGridView1.Rows[i].Cells[4].Value = SavedCars[i].Color;
                dataGridView1.Rows[i].Cells[5].Value = SavedCars[i].Year;
                dataGridView1.Rows[i].Cells[6].Value = SavedCars[i].Kilometer;
                dataGridView1.Rows[i].Cells[7].Value = SavedCars[i].Price;
                dataGridView1.Rows[i].Cells[8].Value = SavedCars[i].PhoneNumber;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rbCheck = "Seçilmedi";
            if (rbDiesel.Checked == true)
            {
                rbCheck = "Dizel";
            }
            else if (rbGas.Checked == true)
            {
                rbCheck = "LPG";
            }
            else if (rbGasoline.Checked == true)
            {
                rbCheck = "Benzin";
            }
            else
            {
                MessageBox.Show("Lütfen Seçim yapınız");
            }

            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            SavedCars[selectedIndex].Brand = cbBrands.SelectedItem.ToString();
            SavedCars[selectedIndex].Color = txtColor.Text.ToString();
            SavedCars[selectedIndex].EngineCapasity = int.Parse(txtEngineCapacity.Text);
            SavedCars[selectedIndex].Fuel = rbCheck.ToString();
            SavedCars[selectedIndex].Kilometer = int.Parse(txtKm.Text);
            SavedCars[selectedIndex].Model = txtModel.Text.ToString();
            SavedCars[selectedIndex].PhoneNumber = txtPhone.Text.ToString();
            SavedCars[selectedIndex].Price = decimal.Parse(txtPrice.Text);
            SavedCars[selectedIndex].Year = txtYear.Text.ToString();

            Listing();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModel.Text = SavedCars[e.RowIndex].Model;
            txtPhone.Text = SavedCars[e.RowIndex].PhoneNumber;
            txtPrice.Text = SavedCars[e.RowIndex].Price.ToString();
            txtYear.Text = SavedCars[e.RowIndex].Year;
            txtKm.Text = SavedCars[e.RowIndex].Kilometer.ToString();
            txtEngineCapacity.Text = SavedCars[e.RowIndex].EngineCapasity.ToString();
            txtColor.Text = SavedCars[e.RowIndex].Color.ToString();
            
            for (int i = 0; i < cbBrands.Items.Count; i++)
            {
                if (cbBrands.Items[i].ToString() == SavedCars[e.RowIndex].Brand)
                {
                    cbBrands.SelectedIndex = i;
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows.RemoveAt(selectedIndex);

            SavedCars.RemoveAt(selectedIndex);

            dataGridView1.Refresh();
        }
    }
}
