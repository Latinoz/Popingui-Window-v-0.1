using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PopinGUI_Form
{
    public partial class Form1 : Form
    {
        Ping pingSender = new Ping();

        public string address;

        public int n;
       
        public async void DoPingThread()
        {
            try

            {

                PingReply reply;

                while (n++ < 4)
                {
                    var result = await Task.Run(() =>
                    {
                    
                        reply = pingSender.Send(address);
                        Thread.Sleep(1000);
                        return reply.Status;
                    });

                    if (result == IPStatus.Success)
                    {

                        label1.Text += "ICMP ответ получен - " + n + " Раз" + '\n';
                        //System.Threading.Thread.Sleep(100);
                    }
                    else
                    {
                        label1.Text = "Ping'a нет!";
                    }
                }
                

            }

            catch (PingException)
            {
                label1.Text = "Некорректный ip адрес!";

            }
        }
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Получить ip адрес из textBox1
            
            address = textBox1.Text;

            if (String.IsNullOrEmpty(address))
            {
                label1.Text = "Введите ip адрес";
            }

            else
            {
                // Пингуем хост
                DoPingThread();
    
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
