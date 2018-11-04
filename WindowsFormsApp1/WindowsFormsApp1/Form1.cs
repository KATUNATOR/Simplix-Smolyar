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
using static System.Console;

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
            int j = J+1;
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
            double[,] task = new double[dataGridView1.RowCount, dataGridView1.ColumnCount];
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    task[i, j] = Convert.ToDouble(dataGridView1[j, i].Value);
                }
            task[dataGridView1.RowCount-1, 0] = 0;
            for (int j = 1; j < dataGridView2.ColumnCount; j++)
                task[dataGridView1.RowCount - 1, j] = Convert.ToDouble(dataGridView2[j, 0].Value);
            for (int i = 0; i < task.GetLength(0); i++)
            {
                for (int j = 0; j < task.GetLength(1); j++)
                    Console.Write(task[i,j] + " ");
                Console.WriteLine();
            }
            /*Simplex table = new Simplex(task);
            double[,] result = table.Calculate();
            int n = result.GetLength(1) - 1;
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
                x[i] = 0;
            for (int i = 0; i < (result.GetLength(0) - 1); i++)
                x[table.Basis[i]] = result[i, 0];
            double[] y = new double[n];
            for (int j = 0; j < n; j++)
                y[j] = result[result.GetLength(0) - 1, ((j + J) % n) + 1];
            string s = "(";
            foreach (double k in x)
                s += " " + Convert.ToString(k) + ",";
            s = s.Substring(0, s.Length - 1);
            s += ")";
            label5.Text = s;
            s = "(";
            foreach (double k in y)
                s += " " + Convert.ToString(k) + ",";
            s = s.Substring(0, s.Length - 1);
            s += ")";
            label6.Text = s;
            */

        }
    }
}
