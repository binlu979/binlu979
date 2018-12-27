using binlu979.HttpLib;
using binlu979.LogNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace binlu979
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            if (url == "")
            {
                url = "https://www.baidu.com";
            }
        }
        string html;
        private void lod_web(string url)
        {
            Http.Get(url).OnSuccess(data => { show_html(data); html = data; }).Go();
        }
        void show_html(string ht)
        {
            this.Invoke((MethodInvoker)delegate
            {
                label1.Text = ht;
            });
 
        }
        private ILogNet logNet = new LogNetSingle(Application.StartupPath + "\\Logs\\123.txt");
        private void button2_Click(object sender, EventArgs e)
        {
            logNet.WriteDebug("这个是一条调试信息");
        }
    }
}
