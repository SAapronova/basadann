using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Windows.Forms.VisualStyles;
using System.IO;
using System.Diagnostics;
using DGV2Printer;

namespace basadann
{
    public partial class Prod : Form
    {
        ShopContext db;
        static uint _Dolzh;
        public Prod(uint Dolzh)
        {
            _Dolzh = Dolzh;
            InitializeComponent();
            db = new ShopContext();
            db.Prodazhi.Load();
            dataGridView1.DataSource = db.Prodazhi.Local.ToBindingList();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
            
            dataGridView1.DataSource = db.Prodazhi.Where(x => x.bookshifr.ToString().Contains(textBox6.Text)
           || x.bookshifr.ToString().Contains(textBox6.Text)).ToList();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true )
            {
                dataGridView1.DataSource = db.Prodazhi.Where(x => x.idsotrud.ToString().Contains(textBox7.Text)
              || x.idsotrud.ToString().Contains(textBox7.Text)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox6.Clear();
            
            dataGridView1.DataSource = db.Prodazhi.Local.ToBindingList();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDataGridView pr = new PrintDataGridView(dataGridView1);
            pr.isRightToLeft = false;
            pr.ReportHeader = "Продажи";
            pr.ReportFooter = "OOO BookShop";
            pr.Print();

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Prodazhi pr = db.Prodazhi.Find(id);
                db.Prodazhi.Remove(pr);
                db.SaveChanges();

                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Prodazhi pr = new Prodazhi();
            pr.idprod = int.Parse(textBox1.Text);
            pr.idsotrud = int.Parse(textBox2.Text);
            pr.bookshifr = int.Parse(textBox3.Text);
            pr.date = DateTime.Parse(textBox4.Text);
            pr.time = TimeSpan.Parse(textBox5.Text);



            db.Prodazhi.Add(pr);
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");

        }

        private void Prod_Load(object sender, EventArgs e)
        {

        }

        private void Prod_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new MainForm(_Dolzh).Show();

        }
    }
}
