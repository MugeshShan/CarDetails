using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDetails
{
    public partial class Form1 : Form
    {
        CarEntities db;
        public Form1()
        {
            InitializeComponent();
            db = new CarEntities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newCar = new Car_Details
            {
                Id = Convert.ToInt32(textBox1.Text),
                Name = textBox2.Text,
                Gender = radioButton1.Checked ? "Male" : "Female",
                Address = textBox3.Text,
                PostalCode = textBox4.Text,
                PhoneNumber = textBox5.Text
            };
            db.Car_Details.Add(newCar);
            db.SaveChanges();
            MessageBox.Show("Customer added: " + textBox2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cars = db.Car_Details.ToList();

            if (cars.Count == 0)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = Convert.ToString(cars.Count() + 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cars = db.Car_Details.ToList();
            int index = 0;
            foreach(var car in cars)
            { 
                if(car.Id == Convert.ToInt32(textBox1.Text))
                {
                        
                    car.Name = textBox2.Text;
                    car.Gender = radioButton1.Checked ? "Male" : "Female";
                    car.Address = textBox3.Text;
                    car.PostalCode = textBox4.Text;
                    car.PhoneNumber = textBox5.Text;
                    db.Car_Details.ToList()[index] = car;
                    db.SaveChanges();
                    MessageBox.Show("Customer Updated: " + car.Id);
                    break;
                }
                index++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                var cars = db.Car_Details.ToList();
                int index = 0;
                foreach (var car in cars)
                {
                    if (car.Id == Convert.ToInt32(textBox1.Text))
                    {
                        db.Car_Details.Remove(car);
                        db.SaveChanges();
                        MessageBox.Show("Customer Deleted: " + car.Id);
                        break;
                    }
                    index++;
                }
            }
            else
            {
                MessageBox.Show("Please enter Id...");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                var cars = db.Car_Details.ToList();
                foreach (var car in cars)
                {
                    if (car.Id == Convert.ToInt32(textBox1.Text))
                    {
                        textBox2.Text = car.Name;
                        if(car.Gender == "Male")
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                        textBox3.Text = car.Address;
                        textBox4.Text = car.PostalCode;
                        textBox5.Text = car.PhoneNumber;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter Id...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            var cars = db.Car_Details.ToList();
            textBox1.Text = Convert.ToString(cars.Count() + 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var cars = db.Car_Details.ToList();

            textBox1.Text = Convert.ToString(cars[0].Id);
            textBox2.Text = cars[0].Name;
            if (cars[0].Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox3.Text = cars[0].Address;
            textBox4.Text = cars[0].PostalCode;
            textBox5.Text = cars[0].PhoneNumber;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var cars = db.Car_Details.ToList();

            var lastIndex = cars.Count() - 1;
            textBox1.Text = Convert.ToString(cars[lastIndex].Id);
            textBox2.Text = cars[lastIndex].Name;
            if (cars[lastIndex].Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
            textBox3.Text = cars[lastIndex].Address;
            textBox4.Text = cars[lastIndex].PostalCode;
            textBox5.Text = cars[lastIndex].PhoneNumber;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var cars = db.Car_Details.ToList();
            if (textBox1.Text != string.Empty)
            {
                var prevIndex = Convert.ToInt32(textBox1.Text) - 2;
                if (prevIndex <= -1)
                {
                    MessageBox.Show(" No Prev record found...");
                }
                else
                {
                    textBox1.Text = Convert.ToString(cars[prevIndex].Id);
                    textBox2.Text = cars[prevIndex].Name;
                    if (cars[prevIndex].Gender == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    textBox3.Text = cars[prevIndex].Address;
                    textBox4.Text = cars[prevIndex].PostalCode;
                    textBox5.Text = cars[prevIndex].PhoneNumber;
                }

            }
            else
            {
                MessageBox.Show("Please enter Id...");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var cars = db.Car_Details.ToList();
            if (textBox1.Text != string.Empty)
            {
                var nextIndex = Convert.ToInt32(textBox1.Text);
                if (nextIndex > cars.Count)
                {
                    MessageBox.Show(" No Next record found...");
                }
                else
                {
                    textBox2.Text = cars[nextIndex].Name;
                    if (cars[nextIndex].Gender == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    textBox3.Text = cars[nextIndex].Address;
                    textBox4.Text = cars[nextIndex].PostalCode;
                    textBox5.Text = cars[nextIndex].PhoneNumber;
                }
            }
            else
            {
                MessageBox.Show("Please enter Id...");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var cars = db.Car_Details.ToList();
            dataGridView1.DataSource = cars;
        }
    }
}
