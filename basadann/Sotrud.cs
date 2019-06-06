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

namespace basadann
{
    public partial class Sotrud : Form
    {
        ShopContext db;
        static uint _Dolzh;
        public Sotrud(uint Dolzh)
        {
            _Dolzh = Dolzh;
            InitializeComponent();
            db = new ShopContext();

            db.Sotrudniki.Load();
            dataGridView1.DataSource = db.Sotrudniki.Local.ToBindingList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
         

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
          private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
           

            }
        //add
        private void button1_Click_1(object sender, EventArgs e)
        {
            addsot add = new addsot();
            DialogResult result = add.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Sotrudniki sot = new Sotrudniki();
            sot.idsotrud = int.Parse(add.textBox1.Text);
            sot.Lastname = add.textBox2.Text;
            sot.Firstname = add.textBox3.Text;
            sot.Backname = add.textBox4.Text;
            sot.Dolznost = add.textBox5.Text;
            sot.Telephone = decimal.Parse(add.textBox6.Text);
            sot.Login = add.textBox7.Text;
            sot.Password =Hash.Hash256(add.textBox8.Text);


            db.Sotrudniki.Add(sot);
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");

        }
        //change
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Sotrudniki sot = db.Sotrudniki.Find(id);

                addsot add = new addsot();

                add.textBox1.Text = sot.idsotrud.ToString();
                add.textBox2.Text = sot.Lastname;
                add.textBox3.Text = sot.Firstname;
                add.textBox4.Text = sot.Backname;
                add.textBox5.Text = sot.Dolznost;
                add.textBox6.Text = sot.Telephone.ToString();
                add.textBox7.Text = sot.Login;
                add.textBox8.Text = sot.Password;
                add.textBox7.ReadOnly = true;
                add.textBox8.ReadOnly = true;


               

                DialogResult result = add.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                
                sot.idsotrud = int.Parse(add.textBox1.Text);
                sot.Lastname = add.textBox2.Text;
                sot.Firstname = add.textBox3.Text;
                sot.Backname = add.textBox4.Text;
                sot.Dolznost = add.textBox5.Text;
                sot.Telephone = decimal.Parse(add.textBox6.Text);


                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Sotrudniki sot = db.Sotrudniki.Find(id);
                db.Sotrudniki.Remove(sot);
                
                
                db.SaveChanges();
                
                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Sotrud_Load(object sender, EventArgs e)
        {

        }

        private void Sotrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new MainForm(_Dolzh).Show();
        }
        }
     
    }

