using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA2_CLIENT_WF
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53871/api/");
                var responseTask = client.GetAsync("Room");
                responseTask.Wait();

                var GetResult = responseTask.Result;
                if (GetResult.IsSuccessStatusCode)
                {
                    var readTask = GetResult.Content.ReadAsAsync<Room[]>();
                    readTask.Wait();

                    var products = readTask.Result;
                    dataGridView1.DataSource = products;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53871/api/");
                var responseTask = client.GetAsync("Client");
                responseTask.Wait();

                var GetResult = responseTask.Result;
                if (GetResult.IsSuccessStatusCode)
                {
                    var readTask = GetResult.Content.ReadAsAsync<Clients[]>();
                    readTask.Wait();

                    var products = readTask.Result;
                    dataGridView1.DataSource = products;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADDClient add = new ADDClient();
            add.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53871/api/");

                // операция удаления
                var deleteTask = client.DeleteAsync($"client/" + textBox3.Text);
                deleteTask.Wait();

                // получение StatusCode необязательно
                HttpResponseMessage deleteResult = deleteTask.Result;
                Console.WriteLine(deleteResult.StatusCode.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53871/api/");

                // операция удаления
                var deleteTask = client.DeleteAsync($"room/" + textBox1.Text);
                deleteTask.Wait();

                // получение StatusCode необязательно
                HttpResponseMessage deleteResult = deleteTask.Result;
                Console.WriteLine(deleteResult.StatusCode.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADDRoom aDD = new ADDRoom();
            aDD.ShowDialog();
        }
    }
}
