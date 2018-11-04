using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Simplex
    {
        double[,] table;

        int m, n;

        List<int> basisVar;

        public List<int> Basis { get; }

        public Simplex(double[,] input)
        {
            int minput = input.GetLength(0);
            int ninput = input.GetLength(1);

            int ntable = ninput + minput - 1;
            table = new double[minput, ntable];            

            basisVar = new List<int>();

            for (int i = 0; i < minput; i++)
            {
                for (int j = 0; j < ntable; j++)
                {
                    if (j < ninput)
                    {
                        table[i, j] = input[i, j];
                    }
                    else
                    {
                        table[i, j] = 0;
                    }
                }
                
                if ((ninput + i) < ntable)
                {
                    table[i, ninput + i] = 1;
                    basisVar.Add(ninput + i);
                }
            }

            n = ntable;
            m = minput;
        }

        public double[,] GetRes(double[] output)
        {
            int col, row;

            while (!IsRes())
            {
                col = getCol();
                row = getRow(col);
                basisVar[row] = col;

                double[,] tableNew = new double[m, n];

                for (int j = 0; j < n; j++)
                {
                    tableNew[row, j] = table[row, j] / table[row, col];
                }

                for (int i = 0; i < m; i++)
                {
                    if (i == row)
                    {
                        continue;
                    }

                    for (int j = 0; j < n; j++)
                    {
                        tableNew[i, j] = table[i, j] - table[i, col] * tableNew[row, j];
                    }
                }
                table = tableNew;
            }

            for (int i = 0; i < output.Length; i++)
            {
                int k = basisVar.IndexOf(i + 1);
                if (k != -1)
                {
                    output[i] = table[k, 0];
                }
                else
                {
                    output[i] = 0;
                }
            }

            return table;
        }

        private bool IsRes()
        {
            bool res = true;

            for (int j = 1; j < n; j++)
            {
                if (table[m - 1, j] < 0)
                {
                    res = false;
                    break;
                }
            }

            return res;
        }

        private int getCol()
        {
            int col = 1;

            for (int j = 2; j < n; j++)
            {
                if (table[m - 1, j] < table[m - 1, col])
                {
                    col = j;
                }
            }

            return col;
        }

        private int getRow(int col)
        {
            int row = 0;

            for (int i = 0; i < m - 1; i++)
            {
                if (table[i, col] > 0)
                {
                    row = i;
                    break;
                }
            }

            for (int i = row + 1; i < m - 1; i++)
            {
                if ((table[i, col] > 0) && ((table[i, 0] / table[i, col]) < (table[row, 0] / table[row, col])))
                {
                    row = i;
                }
            }

            return row;
        }
    }
}

