﻿using System;
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
        private int J { get => dataGridView1.ColumnCount - 2; }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "x" + Convert.ToString(J + 1);
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = s;
            col.Name = s;
            dataGridView1.Columns.Insert(J, col);
            Console.WriteLine("Hello world");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("x" + Convert.ToString(J));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel._Worksheet sheet1;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                for (int j = 0; i < dataGridView1.ColumnCount; i++)
                {
                    sheet1.Cells[i, j] = dataGridView1[i, j];
                }
        }
    }
}
