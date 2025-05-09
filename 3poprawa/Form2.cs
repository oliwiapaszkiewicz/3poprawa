using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3poprawa
{
    public partial class Form2 : Form
    {
        public Osoba NowaOsoba { get; private set; }

        public Form2()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Sekretarka", "Menadżer", "Dyrektor" });
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = textBox3.Text;
            string lastName = textBox2.Text;
            decimal age = 0;
            if (decimal.TryParse(textBox1.Text, out age))
            {
                textBox1.Text = age.ToString();
            }
            string position = comboBox1.SelectedItem?.ToString();

            int id = 1;
            id++;

            NowaOsoba = new Osoba(id, firstName, lastName, (int)age, position);
            id++;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
{
}

private void textBox1_TextChanged(object sender, EventArgs e)
{
}

private void textBox2_TextChanged(object sender, EventArgs e)
{
}

private void textBox3_TextChanged(object sender, EventArgs e)
{
}

private void Form2_Load(object sender, EventArgs e)
{
}


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}