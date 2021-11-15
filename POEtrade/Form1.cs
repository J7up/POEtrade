using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.SqlClient;

namespace POEtrade
{
    public partial class Form1 : Form
    {
        static string conStr = "Data Source=10.10.0.120;Initial Catalog=ABD41_18;User ID=abd31_21;Password=123456qwerty.";
        DataContext context = new DataContext(conStr);
        public Form1()
        {
            InitializeComponent();
            Table<Item> item= context.GetTable<Item>();
            dataGridView1.DataSource = item.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Item it = new Item
            {
                name = textBox1.Text,
                category = Convert.ToInt32(comboBox1.SelectedValue),
                rarity = Convert.ToInt32(comboBox2.SelectedValue),
                socket = Convert.ToInt32(comboBox3.SelectedValue),
                color = Convert.ToInt32(comboBox5.SelectedValue),
                link = Convert.ToInt32(comboBox4.SelectedValue),
                quantity = Convert.ToInt32(numericUpDown1.Value),
                price = Convert.ToInt32(numericUpDown2.Value),
            };
            context.GetTable<Item>().InsertOnSubmit(it);
            context.SubmitChanges();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aBD41_18DataSet.Link". При необходимости она может быть перемещена или удалена.
            this.linkTableAdapter.Fill(this.aBD41_18DataSet.Link);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aBD41_18DataSet.Color". При необходимости она может быть перемещена или удалена.
            this.colorTableAdapter.Fill(this.aBD41_18DataSet.Color);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aBD41_18DataSet.Socket". При необходимости она может быть перемещена или удалена.
            this.socketTableAdapter.Fill(this.aBD41_18DataSet.Socket);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aBD41_18DataSet.Rarity". При необходимости она может быть перемещена или удалена.
            this.rarityTableAdapter.Fill(this.aBD41_18DataSet.Rarity);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "aBD41_18DataSet.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.aBD41_18DataSet.Category);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Item it = context.GetTable<Item>().FirstOrDefault(x => x.id_item == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            it.name = textBox1.Text;
            it.category = Convert.ToInt32(comboBox1.SelectedValue);
            it.rarity = Convert.ToInt32(comboBox2.SelectedValue);
            it.socket = Convert.ToInt32(comboBox3.SelectedValue);
            it.color = Convert.ToInt32(comboBox5.SelectedValue);
            it.link = Convert.ToInt32(comboBox4.SelectedValue);
            it.quantity = Convert.ToInt32(numericUpDown1.Value);
            it.price = Convert.ToInt32(numericUpDown2.Value);
            context.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Item item = context.GetTable<Item>().OrderByDescending(x => x.id_item).FirstOrDefault();
            context.GetTable<Item>().DeleteOnSubmit(item);
            context.SubmitChanges();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var f = context.GetTable<Item>().Where(x => x.name.Contains(textBox2.Text));
            dataGridView1.DataSource = f.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = context.GetTable<Item>().Where(x => x.category == Convert.ToInt32(comboBox6.SelectedValue));
            dataGridView1.DataSource = f.ToList();
        }
    }
}
