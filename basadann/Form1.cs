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
    public partial class Form1 : Form
    {
        
        ShopContext db;
        static uint _Dolzh;
        public Form1(uint Dolzh)
        {
            _Dolzh = Dolzh;
            InitializeComponent();
            db = new ShopContext();
            db.Izdanie.Load();
            db.Izdatelstvo1.Load();
            db.Authos.Load();
            db.Books.Load();
            dataGridView1.DataSource = db.Izdanie.Local.ToBindingList();
            dataGridView2.DataSource = db.Izdatelstvo1.Local.ToBindingList();
            dataGridView3.DataSource = db.Authos.Local.ToBindingList();
            dataGridView4.DataSource = db.Books.Local.ToBindingList();
        }
        //добавить
        private void button1_Click(object sender, EventArgs e)
        {
            addform add = new addform();
            DialogResult result = add.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Izdanie izd = new Izdanie();
            izd.idizdanie =int.Parse(add.textBox1.Text);
            izd.pereplet = add.textBox2.Text;
            izd.format = add.textBox3.Text;


            db.Izdanie.Add(izd);
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //изменить
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                
             bool converted =Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Izdanie izd = db.Izdanie.Find(id);
                addform add = new addform();
               
                add.textBox1.Text =izd.idizdanie.ToString();
                add.textBox2.Text = izd.pereplet;
                add.textBox3.Text = izd.format;
              
                DialogResult result = add.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                izd.idizdanie =Convert.ToInt32(add.textBox1.Text);
                izd.pereplet = add.textBox2.Text;
                izd.format = add.textBox3.Text;

                db.SaveChanges();
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }
        //удалить
        private void button3_Click(object sender, EventArgs e)
        {
       
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Izdanie izd = db.Izdanie.Find(id);
                db.Izdanie.Remove(izd);
                
                db.SaveChanges();
                
                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addizd addi = new addizd();
            DialogResult result = addi.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Izdatelstvo1 iz = new Izdatelstvo1();
            iz.idizdatelstvo = int.Parse(addi.textBox1.Text);
            iz.naimenovanie = addi.textBox2.Text;
            iz.year = addi.textBox3.Text;
            iz.kolvostr = addi.textBox4.Text;
            iz.gorod = addi.textBox5.Text;
            iz.telef = addi.textBox6.Text;

            db.Izdatelstvo1.Add(iz);
            db.SaveChanges();
         
            MessageBox.Show("Новый объект добавлен");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Izdatelstvo1 iz = db.Izdatelstvo1.Find(id);
                addizd addi = new addizd();

                addi.textBox1.Text = iz.idizdatelstvo.ToString();
                addi.textBox2.Text = iz.naimenovanie;
                addi.textBox3.Text = iz.year;
                addi.textBox4.Text = iz.kolvostr;
                addi.textBox5.Text = iz.gorod;
                addi.textBox6.Text = iz.telef;

        

                DialogResult result = addi.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                iz.idizdatelstvo = Convert.ToInt32(addi.textBox1.Text);
                iz.naimenovanie = addi.textBox2.Text;
                iz.year = addi.textBox3.Text;
                iz.kolvostr = addi.textBox4.Text;
                iz.gorod = addi.textBox5.Text;
                iz.telef = addi.textBox6.Text;

                db.SaveChanges();
                dataGridView2.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int index = dataGridView2.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView2[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Izdatelstvo1 iz = db.Izdatelstvo1.Find(id);
              
                db.Izdatelstvo1.Remove(iz);
                
                db.SaveChanges();
                
                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            addau adu = new addau();
            DialogResult result = adu.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
            Authos au = new Authos();
            au.idauthor = int.Parse(adu.textBox1.Text);
            au.lastname = adu.textBox2.Text;
            au.firstname = adu.textBox3.Text;
            au.backname = adu.textBox4.Text;
            au.birthyear = int.Parse(adu.textBox5.Text);
            au.deathyear = int.Parse(adu.textBox6.Text);



            db.Authos.Add(au);
           
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int index = dataGridView3.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView3[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Authos au = db.Authos.Find(id);
                addau adu = new addau();

                adu.textBox1.Text = au.idauthor.ToString();
                adu.textBox2.Text = au.lastname;
                adu.textBox3.Text = au.firstname;
                adu.textBox4.Text = au.backname;
                adu.textBox5.Text = au.birthyear.ToString();
                adu.textBox6.Text = au.deathyear.ToString();
               
                DialogResult result = adu.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                au.idauthor = int.Parse(adu.textBox1.Text);
                au.lastname = adu.textBox2.Text;
                au.firstname = adu.textBox3.Text;
                au.backname = adu.textBox4.Text;
                au.birthyear = int.Parse(adu.textBox5.Text);
                au.deathyear = int.Parse(adu.textBox6.Text);


                db.SaveChanges();
                dataGridView3.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
             if (dataGridView3.SelectedRows.Count > 0)
            {
                int index = dataGridView3.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView3[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                 Authos au = db.Authos.Find(id);
                 db.Authos.Remove(au);
            
                
                db.SaveChanges();
                
                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            addbook addb = new addbook();

            DialogResult result = addb.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Books boo = new Books();
            boo.bookshifr = int.Parse(addb.textBox1.Text);
            boo.name = addb.textBox2.Text;
            boo.idauthor = int.Parse(addb.textBox3.Text);
            boo.idizdanie = int.Parse(addb.textBox4.Text);
            boo.idizdatelstvo = int.Parse(addb.textBox5.Text);
            boo.ganr = addb.textBox6.Text;
            boo.price = addb.textBox7.Text;

            db.Books.Add(boo);
            db.SaveChanges();

            MessageBox.Show("Новый объект добавлен");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                int index = dataGridView4.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView4[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Books boo = db.Books.Find(id);
                addbook addb = new addbook();

                addb.textBox1.Text = boo.bookshifr.ToString();
                addb.textBox2.Text = boo.name;
                addb.textBox3.Text = boo.idauthor.ToString();
                addb.textBox4.Text = boo.idizdanie.ToString();
                addb.textBox5.Text = boo.idizdatelstvo.ToString();
                addb.textBox6.Text = boo.ganr;
                addb.textBox7.Text = boo.price;

                DialogResult result = addb.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                boo.bookshifr = int.Parse(addb.textBox1.Text);
                boo.name = addb.textBox2.Text;
                boo.idauthor = int.Parse(addb.textBox3.Text);
                boo.idizdanie = int.Parse(addb.textBox4.Text);
                boo.idizdatelstvo = int.Parse(addb.textBox5.Text);
                boo.ganr = addb.textBox6.Text;
                boo.price = addb.textBox7.Text;

                db.SaveChanges();
                dataGridView4.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
             if (dataGridView4.SelectedRows.Count > 0)
            {
                int index = dataGridView4.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView4[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Books boo=db.Books.Find(id);
                db.Books.Remove(boo);
                
                db.SaveChanges();
                
                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new MainForm(_Dolzh).Show();
        }

        }

        }
    

