using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int J { get => dataGridView1.ColumnCount - 1; }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int j = J;
            string s = "x" + Convert.ToString(J + 1);
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn fcol = new DataGridViewTextBoxColumn();
            col.HeaderText = s;
            col.Name = s;
            fcol.HeaderText = s;
            fcol.Name = "f" + s;
            dataGridView1.Columns.Insert(j, col);
            dataGridView2.Columns.Insert(j, fcol);
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int j = J;
            dataGridView1.Columns.Remove("x" + Convert.ToString(j));
            dataGridView2.Columns.Remove("fx" + Convert.ToString(j));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double[,] task = new double[dataGridView1.RowCount+1, dataGridView2.ColumnCount];
            for (int i = 0; i < dataGridView1.RowCount; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    task[i, j] = Convert.ToDouble(dataGridView1[i, j]);
                }
            for (int j = 0; j < dataGridView2.ColumnCount; j++)
                task[dataGridView1.RowCount, j] = Convert.ToDouble(dataGridView2[0, j]);
        }
    }
}
