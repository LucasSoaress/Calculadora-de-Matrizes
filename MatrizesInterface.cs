using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_Matrizes
{
    public static class MatrizesInterface
    {
        public static TextBox[,] Matriz1;
        public static TextBox[,] Matriz2;
        public static TextBox[,] matrizResultado;
        public static float determinante;

        public static int linha1, coluna1;
        public static int linha2, coluna2;


        /// <summary>
        /// Método criado para instanciar os textboxs dentro do panel para gerar as matrizes
        /// </summary>
        /// <param name="linhas">Números de linhas, oriundo do numericUpDown</param>
        /// <param name="colunas">Número de colunas, oriundo do numericUpDown</param>
        /// <param name="matrixFinal">Panel no qual serão instanciados os textBoxs</param>
        public static void instanciarTextBox(int linhas, int colunas, Panel matrixFinal)
        {
            int altura = 35;
            int largura = 50;

            Matriz1 = new TextBox[linhas, colunas];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Font = new Font("Microsoft Sans Serif", 10f);
                    Matriz1[x, y].Text = "0";
                    Matriz1[x, y].BackColor = Color.LightGray;
                    Matriz1[x, y].Location = new Point((40) * x, (30) * y);
                    Matriz1[x, y].KeyPress += new System.Windows.Forms.KeyPressEventHandler(naoMostrarLetras);
                    Matriz1[x, y].Size = new Size(altura, largura);
                    matrixFinal.Controls.Add(Matriz1[x, y]);
                }
            }
        }

        /// <summary>
        /// Método para exibir apenas números nos textBoxs das Matrizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void naoMostrarLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != ',' && e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
