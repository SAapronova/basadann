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
    public partial class Enter : Form
    {
        ShopContext db;
        public Enter()
        {
            InitializeComponent();
            db=new ShopContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             var s = Hash.Hash256(textBox2.Text.Trim());
 
            if (db.Sotrudniki.FirstOrDefault(p => p.Login.Equals(textBox1.Text.Trim()) && p .Password.Equals(s)) != null)
            {
                var user = db.Sotrudniki.Select(p => new
                {
                    
                    id_User = p.idsotrud,
                    Login = p.Login,
                    Password = p.Password,
                    Status = p.Dolznost,
                   
                }).FirstOrDefault(p => p.Login.Equals(textBox1.Text.Trim()) && p.Password.Equals(s));
                switch (user.Status.Trim())
                {
                    case "Продавец":
                        Hide();
                        new MainForm(0).Show();
                        break;
 
                    case "Администратор":
                        Hide();
                        new MainForm(2).Show();
                        break;

                    case "Директор":
                        Hide();
                        new MainForm(3).Show();
                        break;
 
                
                }
            }
            else
                MessageBox.Show("Вы не зарегистрированы в системе");
 
        }

        private void Enter_Load(object sender, EventArgs e)
        {

        }

        private void Enter_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        }
    }

