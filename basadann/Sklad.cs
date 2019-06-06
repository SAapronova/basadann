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
 
    public partial class Sklad : Form
    {
       
        
        ShopContext db;
        static uint _Dolzh;
        public Sklad(uint Dolzh)
        {
            _Dolzh = Dolzh;
            InitializeComponent();
            db = new ShopContext();
            db.Izdanie.Load();
            db.Izdatelstvo1.Load();
            db.Authos.Load();
            db.Books.Load();
            dataGridView1.DataSource = db.Books.Local.ToBindingList();
            dataGridView2.DataSource = db.Authos.Local.ToBindingList();
            dataGridView3.DataSource = db.Izdanie.Local.ToBindingList();
            dataGridView4.DataSource = db.Izdatelstvo1.Local.ToBindingList();
          _Dolzh = Dolzh;
          db.Sotrudniki.Load();

            switch (Dolzh)
            { 
                case 2:
                    
                    break;
                case 0:
                    button2.Enabled = false;

                    button3.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button12.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;


                    break;
      
               
                case 3:
                   
                    break;
                default:
                    break;
            
            }
            
        }
            
           private void Sklad_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Books.Where(x => x.name.Contains(textBox1.Text)
                || x.name.Contains(textBox1.Text)).ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Books.Where(x =>x.price.Contains(textBox2.Text)
               || x.price.Contains(textBox2.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
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
                dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Books.Where(x => x.ganr.Contains(textBox3.Text)
               || x.ganr.Contains(textBox3.Text)).ToList();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[0].Value != null)
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(textBox4.Text))
                        {
                            
                            dataGridView1.Rows[i].Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index;
                               
                           
                            break;
                        }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.Authos.Where(x => x.lastname.Contains(textBox7.Text)
              || x.lastname.Contains(textBox7.Text)).ToList();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.Authos.Where(x => x.firstname.Contains(textBox6.Text)
             || x.firstname.Contains(textBox6.Text)).ToList();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.Authos.Where(x => x.backname.Contains(textBox5.Text)
            || x.backname.Contains(textBox5.Text)).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var tmp = false;
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    if (dataGridView2.Rows[i].Cells[j].Value != null)
                        if ((dataGridView2.Rows[i].Cells[0].Value.ToString()==textBox8.Text))
                            
                        {
                            dataGridView2.Rows[i].Selected = true;
                            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.SelectedRows[0].Index;
                            tmp = true;
                            break;
                        }
            }
            if (!tmp)
                MessageBox.Show("Ничего не найдено");
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
                dataGridView2.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
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

                 Authos au = db.Authos.Find(id);
                 db.Authos.Remove(au);
            
                
                db.SaveChanges();
                
                MessageBox.Show("Объект удален");
            }
            else
                MessageBox.Show("Выберите строку таблицы)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        }
        //найти код издания
        private void button7_Click(object sender, EventArgs e)
        {
            var tmp = false;
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                dataGridView3.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                        if ((dataGridView3.Rows[i].Cells[0].Value.ToString() == textBox12.Text))
                        {
                            dataGridView3.Rows[i].Selected = true;
                            dataGridView3.FirstDisplayedScrollingRowIndex = dataGridView3.SelectedRows[0].Index;
                            tmp = true;
                            break;
                        }
            }
            if (!tmp)
                MessageBox.Show("Ничего не найдено");
        }
        //изменить издание
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                int index = dataGridView3.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView3[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Izdanie izd = db.Izdanie.Find(id);
                addform add = new addform();

                add.textBox1.Text = izd.idizdanie.ToString();
                add.textBox2.Text = izd.pereplet;
                add.textBox3.Text = izd.format;

                DialogResult result = add.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                izd.idizdanie = Convert.ToInt32(add.textBox1.Text);
                izd.pereplet = add.textBox2.Text;
                izd.format = add.textBox3.Text;

                db.SaveChanges();
                dataGridView3.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }
        //удалить издание
        private void button8_Click(object sender, EventArgs e)
        {
             if (dataGridView3.SelectedRows.Count > 0)
            {
                int index = dataGridView3.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView3[0, index].Value.ToString(), out id);
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
        //фильтр переплета
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = db.Izdanie.Where(x => x.pereplet.Contains(textBox11.Text)
           || x.pereplet.Contains(textBox11.Text)).ToList();
        }
        //фильтр формата
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource = db.Izdanie.Where(x => x.format.Contains(textBox10.Text)
           || x.format.Contains(textBox10.Text)).ToList();
        }
        //поиск номера издательства
        private void button10_Click(object sender, EventArgs e)
        {
            var tmp = false;
            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                dataGridView4.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    if (dataGridView4.Rows[i].Cells[j].Value != null)
                        if ((dataGridView4.Rows[i].Cells[0].Value.ToString() == textBox14.Text))
                        {
                            dataGridView4.Rows[i].Selected = true;
                            dataGridView4.FirstDisplayedScrollingRowIndex = dataGridView4.SelectedRows[0].Index;
                            tmp = true;
                            break;
                        }
            }
            if (!tmp)
                MessageBox.Show("Ничего не найдено");
        }
        //измпенить издательство
        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                int index = dataGridView4.SelectedRows[0].Index;
                int id = 0;

                bool converted = Int32.TryParse(dataGridView4[0, index].Value.ToString(), out id);
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
                dataGridView4.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
            }
        }
        //удалить издательство
        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                int index = dataGridView4.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView4[0, index].Value.ToString(), out id);
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
        //фильтр наименования
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.DataSource = db.Izdatelstvo1.Where(x => x.naimenovanie.Contains(textBox13.Text)
          || x.naimenovanie.Contains(textBox13.Text)).ToList();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.DataSource = db.Izdatelstvo1.Where(x => x.gorod.Contains(textBox9.Text)
         || x.gorod.Contains(textBox9.Text)).ToList();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.DataSource = db.Izdatelstvo1.Where(x => x.year.Contains(textBox15.Text)
        || x.year.Contains(textBox15.Text)).ToList();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Sklad_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            new MainForm(_Dolzh).Show();

        }
            
          
        }

        }
    

