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
    public partial class ADDClient : Form
    {
        public ADDClient()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53871/api/");

                //HTTP POST --------------------------------------
                var student = new Clients()
                {
                    FIO = textBox3.Text,
                    AGE = Convert.ToInt32(textBox2.Text),
                    PHONE_NUMBER = textBox1.Text
                };

                var postTask = client.PostAsJsonAsync<Clients>("client", student);
                postTask.Wait();

                var PostResult = postTask.Result;
                if (PostResult.IsSuccessStatusCode)
                {

                    var readTask = PostResult.Content.ReadAsAsync<Clients>();
                    readTask.Wait();

                    var insertedProduct = readTask.Result;
                    MessageBox.Show("Оповещение", "Клиент добавлен!");
                }
                else
                {
                    throw new Exception();
                }
            }

        }
    }
}
