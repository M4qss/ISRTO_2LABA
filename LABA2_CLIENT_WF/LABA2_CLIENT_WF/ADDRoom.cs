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
    public partial class ADDRoom : Form
    {
        public ADDRoom()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53871/api/");

                //HTTP POST --------------------------------------
                var student = new Room()
                {
                    BEDS = Convert.ToInt32(textBox3.Text),
                    FLOOR = Convert.ToInt32(textBox2.Text),
                    CLASS = textBox1.Text
                };

                var postTask = client.PostAsJsonAsync<Room>("room", student);
                postTask.Wait();

                var PostResult = postTask.Result;
                if (PostResult.IsSuccessStatusCode)
                {

                    var readTask = PostResult.Content.ReadAsAsync<Room>();
                    readTask.Wait();

                    var insertedProduct = readTask.Result;
                    MessageBox.Show("Оповещение", "Комната добавлена!");
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
