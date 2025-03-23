using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace _3poprawa
{
    public partial class Form1: Form
    {

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Imię";
            dataGridView1.Columns[2].Name = "Nazwisko";
            dataGridView1.Columns[3].Name = "Wiek";
            dataGridView1.Columns[4].Name = "Stanowisko";
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2(dataGridView1);
            addForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridView1.Rows.Remove(row);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv";
            saveFileDialog1.Title = "Wybierz lokalizację zapisu pliku CSV";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(dataGridView1, saveFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Pliki CSV (*.csv)|*.csv";
            openFileDialog1.Title = "Wybierz plik CSV do wczytania";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadCSVToDataGridView(openFileDialog1.FileName);
            }
        }
        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            StringBuilder csvContent = new StringBuilder();
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                csvContent.Append(dataGridView.Columns[i].Name + (i < dataGridView.ColumnCount - 1 ? "," : ""));
            }
            csvContent.AppendLine();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    csvContent.AppendLine(string.Join(",", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString() ?? "")));
                }
            }
            File.WriteAllText(filePath, csvContent.ToString());
        }

        private void LoadCSVToDataGridView(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0) return;

            dataGridView1.Rows.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                dataGridView1.Rows.Add(lines[i].Split(','));
            }
        }
    }
}

  