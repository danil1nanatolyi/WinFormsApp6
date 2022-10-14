using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
            outputTB.Text = "";
            int size = Int32.Parse(sizeTB.Text);
            int[,] matrix = new int[size, size];
            Random random = new Random();
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(0, 100);
                }
            }

            for (int i = 0; i < size; i++)
            {
                int[] array = getOneArray(matrix, i);
                sort(array);
                insertRow(array, matrix, i);

                for (int j = 0; j < size; j++)
                {
                    outputTB.Text += matrix[i, j] + "\t";
                }
                outputTB.Text += "\r\n";
            }
        }

        private int[] getOneArray(int[,] array, int row)
        {
            int[] result = new int[array.GetLength(1)];
            for(int i = 0; i < array.GetLength(1); i++)
            {
                result[i] = array[row, i];
            }
            return result;
        }

        public void insertRow(int[] array, int[,] matrix, int row)
        {
            for(int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[row, i] = array[i];
            }
        }

        private void sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int k = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > k)
                {
                    array[j + 1] = array[j];
                    array[j] = k;
                    j--;
                }
            }
            //return array;
        }
    }
}
