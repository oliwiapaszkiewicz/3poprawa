using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3poprawa
{
    public partial class Form2: Form
    {
        private DataGridView dataGridView;

        public Form2(DataGridView dgv)
        {
            InitializeComponent();
            dataGridView = dgv;
            comboBox1.Items.AddRange(new string[] { "Sekretarka", "Menadżer", "Dyrektor" });
            comboBox1.SelectedIndex = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = (dataGridView.Rows.Count).ToString();
            string firstName = textBox3.Text;
            string lastName = textBox2.Text;
            decimal age = 0;
            if(decimal.TryParse(textBox1.Text, out age))
            {
                textBox1.Text = age.ToString();

            }
            string position = comboBox1.SelectedItem?.ToString();
            dataGridView.Rows.Add(id, firstName, lastName,age, position);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
