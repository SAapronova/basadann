using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace basadann
{
    public partial class MainForm : Form
    {
        ShopContext db;

         static uint _Dolzh;
  
        public MainForm(uint Dolzh)
        {
             _Dolzh = Dolzh;
            
            InitializeComponent();
            db = new ShopContext();
            db.Sotrudniki.Load();

            switch (Dolzh)
            { 
                case 2:
                    label1.Visible = true;
                    label1.Text = "Вы вошли как Администратор";
                    break;
                case 0:
                    button1.Enabled = false;
                    button4.Enabled = false;
                    label1.Visible = true;
                    label1.Text = "Вы вошли как Продавец";
                    break;
    
                case 3:
                    label1.Visible = true;
                    label1.Text = "Вы вошли как Директор";
                    break;
                default:
                    break;
            
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
           new Form1(_Dolzh).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Hide();
            new Sklad(_Dolzh).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            new Sotrud(_Dolzh).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            new Prod(_Dolzh).Show();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
