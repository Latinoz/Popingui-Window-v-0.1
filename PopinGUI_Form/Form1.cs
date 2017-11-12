using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                //Task thread1 = new Task(PingFuncion);
                //////Thread thread2 = new Thread(PingFuncion);


                //////thread2.Start();
                //int n = 0;
                //while (n++ < 4)
                //{
                //    //PingFuncion();
                //    thread1.Start();
                //    thread1.Wait();

                //}

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
            
            //label1.Text = textBox1.Text;
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
