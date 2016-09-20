using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_Matrizes
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NumericUpDown[,] Matriz1;
        private NumericUpDown[,] Matriz2;
        private NumericUpDown[,] matrizResultado;
        private float determinante;

        private int linha1, coluna1;
        private int linha2, coluna2;

        private void btn_criarMatriz2_Click(object sender, EventArgs e)
        {
            try
            {
                panel2.Controls.Clear();
                panel3.Controls.Clear();
                linha2 = Convert.ToInt32(numericUpDown3.Value);
                coluna2 = Convert.ToInt32(numericUpDown4.Value);

                int TamanhoText = panel2.Width / coluna2;
                Matriz2 = new NumericUpDown[linha2, coluna2];
                TamanhoText = panel2.Width / coluna2;
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        Matriz2[x, y] = new NumericUpDown();
                        Matriz2[x, y].Text = "00";
                        Matriz2[x, y].Font = new Font("Microsoft Sans Serif", 10f);
                        Matriz2[x, y].BackColor = Color.LightGray;
                        Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 10;
                        Matriz2[x, y].Left = y * TamanhoText + 2;
                        Matriz2[x, y].Width = 40;
                        Matriz2[x, y].Height = 10;
                        panel2.Controls.Add(Matriz2[x, y]);
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
                float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
                if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                {
                    MessageBox.Show("Só é possível somar matrizes de mesma ordem !", "Erro - Soma Matrizes");
                    return;
                }

                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempMatriz1[x, y] = n;
                    }
                }
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz2[x, y].Text, out n);
                        tempMatriz2[x, y] = n;
                    }
                }

                float[,] tempMatrizResultante = Calculos.SomandoMatrizes(tempMatriz1, tempMatriz2);
                matrizResultado = new NumericUpDown[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                int TamanhoText = panel3.Width / matrizResultado.GetLength(1);
                panel3.Controls.Clear();
                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        matrizResultado[x, y] = new NumericUpDown();
                        matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                        matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                        matrizResultado[x, y].Left = y * TamanhoText + 6;
                        matrizResultado[x, y].Width = 40;
                        matrizResultado[x, y].Height = 10;
                        matrizResultado[x, y].BackColor = Color.LightGray;
                        matrizResultado[x, y].Font = new Font("Microsoft Sans Serif", 10f);

                        panel3.Controls.Add(matrizResultado[x, y]);
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }           
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
                float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
                if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
                {
                    MessageBox.Show("Somente é possível a subtração de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                    return;
                }

                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempMatriz1[x, y] = n;
                    }
                }
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz2[x, y].Text, out n);
                        tempMatriz2[x, y] = n;
                    }
                }

                float[,] tempMatrizResultante = Calculos.SubtraindoMatrizes(tempMatriz1, tempMatriz2);
                matrizResultado = new NumericUpDown[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
                panel3.Controls.Clear();
                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        matrizResultado[x, y] = new NumericUpDown();
                        matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                        matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                        matrizResultado[x, y].Left = y * TamanhoText + 6;
                        matrizResultado[x, y].Width = 40;
                        matrizResultado[x, y].Height = 10;
                        matrizResultado[x, y].BackColor = Color.LightGray;
                        matrizResultado[x, y].Font = new Font("Microsoft Sans Serif", 10f);
                        panel3.Controls.Add(matrizResultado[x, y]);
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
                float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
                if (tempMatriz1.GetLength(1) != tempMatriz2.GetLength(0))
                {
                    MessageBox.Show("Só é possível a multiplicação de matrizes onde, a coluna da matriz 1 e igual a linha da matriz 2  !", "Erro - Multiplicação Matrizes");
                    return;
                }

                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempMatriz1[x, y] = n;
                    }
                }
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz2[x, y].Text, out n);
                        tempMatriz2[x, y] = n;
                    }
                }

                float[,] tempMatrizResultante = Calculos.MultiplicandoMatrizes(tempMatriz1, tempMatriz2);
                matrizResultado = new NumericUpDown[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
                panel3.Controls.Clear();
                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        matrizResultado[x, y] = new NumericUpDown();
                        matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                        matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                        matrizResultado[x, y].Left = y * TamanhoText + 6;
                        matrizResultado[x, y].Width = 40;
                        matrizResultado[x, y].Height = 10;
                        matrizResultado[x, y].BackColor = Color.LightGray;
                        matrizResultado[x, y].Font = new Font("Microsoft Sans Serif", 10f);
                        panel3.Controls.Add(matrizResultado[x, y]);
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnTranspostaMatriz1_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempResultante[x, y] = n;
                    }
                }

                float[,] tempMatrizResultante = Calculos.GerarTransposta(tempResultante);
                int TamanhoText = groupBoxConfigurações.Width / Matriz1.GetLength(1);
                Matriz1 = new NumericUpDown[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                groupBoxConfigurações.Controls.Clear();
                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        Matriz1[x, y] = new NumericUpDown();
                        Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                        Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                        Matriz1[x, y].Left = y * TamanhoText + 6;
                        Matriz1[x, y].Width = TamanhoText;
                        groupBoxConfigurações.Controls.Add(Matriz1[x, y]);
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnDeterminandeMatriz1_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempResultante[x, y] = n;
                    }
                }
                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    determinante = Calculos.GerarDeterminante2x2(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    determinante = Calculos.GerarDeterminante3x3(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else
                {
                    MessageBox.Show("Não é possível gerar determinante !", "Error - Matriz invalida ");
                }
            }

            catch(Exception)
            {
                mensagem();
            }           
        }

        private void btnInversaMatriz1_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
                float[,] matrizAdjunta = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
                float[,] matrizCofatora = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
                float determinante = 0;
                if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
                {
                    if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                    {
                        MessageBox.Show("Matriz invalida !", "Error - Matriz");
                        return;
                    }
                }
                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempResultante[x, y] = n;
                    }
                }

                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    matrizCofatora = Calculos.GerarCofatora2x2(tempResultante);
                    matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                    determinante = Calculos.GerarDeterminante2x2(tempResultante);
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    matrizCofatora = Calculos.GerarCofatora3x3(tempResultante);
                    matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                    determinante = Calculos.GerarDeterminante3x3(tempResultante);
                }
                else
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
                if (determinante == 0)
                {
                    MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                    return;
                }
                float[,] tempMatrizResultante = Calculos.GerarInversa(determinante, matrizAdjunta);
                int TamanhoText = groupBoxConfigurações.Width / Matriz1.GetLength(1);
                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    }
                }
            }
            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnOpostaMatriz2_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz2[x, y].Text, out n);
                        tempResultante[x, y] = n;
                    }
                }

                float[,] tempMatrizResultante = Calculos.GerarOposta(tempResultante);
                int TamanhoText = groupBox1.Width / Matriz2.GetLength(1);
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnTranspostaMatriz2_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz2[x, y].Text, out n);
                        tempResultante[x, y] = n;
                    }
                }

                float[,] tempMatrizResultante = Calculos.GerarTransposta(tempResultante);
                int TamanhoText = groupBox1.Width / Matriz2.GetLength(1);
                Matriz2 = new NumericUpDown[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                groupBox1.Controls.Clear();
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        Matriz2[x, y] = new NumericUpDown();
                        Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                        Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                        Matriz2[x, y].Left = y * TamanhoText + 6;
                        Matriz2[x, y].Width = TamanhoText;
                        groupBox1.Controls.Add(Matriz2[x, y]);
                    }
                }
            }
            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnDeterminanteMatriz2_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz2[x, y].Text, out n);
                        tempResultante[x, y] = n;
                    }
                }
                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    determinante = Calculos.GerarDeterminante2x2(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    determinante = Calculos.GerarDeterminante3x3(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else
                {
                    MessageBox.Show("Não é possével gerar determinante !", "Error - Matriz invalida ");
                }
            }
            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnInversoMatriz2_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
                float[,] matrizAdjunta = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
                float[,] matrizCofatora = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
                float determinante = 0;
                if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
                {
                    if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                    {
                        MessageBox.Show("Matriz invalida !", "Error - Matriz");
                        return;
                    }
                }

                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz2[x, y].Text, out n);
                        tempResultante[x, y] = n;

                    }
                }

                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    matrizCofatora = Calculos.GerarCofatora2x2(tempResultante);
                    matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                    determinante = Calculos.GerarDeterminante2x2(tempResultante);
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    matrizCofatora = Calculos.GerarCofatora3x3(tempResultante);
                    matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                    determinante = Calculos.GerarDeterminante3x3(tempResultante);
                }
                else
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
                if (determinante == 0)
                {
                    MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                    return;
                }
                float[,] tempMatrizResultante = Calculos.GerarInversa(determinante, matrizAdjunta);
                int TamanhoText = groupBox1.Width / Matriz2.GetLength(1);
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnInversoMatriz3_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];
                float[,] matrizAdjunta = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];
                float[,] matrizCofatora = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];
                float determinante = 0;
                if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
                {
                    if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                    {
                        MessageBox.Show("Matriz invalida !", "Error - Matriz");
                        return;
                    }
                }

                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(matrizResultado[x, y].Text, out n);
                        tempResultante[x, y] = n;

                    }
                }

                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    matrizCofatora = Calculos.GerarCofatora2x2(tempResultante);
                    matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                    determinante = Calculos.GerarDeterminante2x2(tempResultante);
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    matrizCofatora = Calculos.GerarCofatora3x3(tempResultante);
                    matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                    determinante = Calculos.GerarDeterminante3x3(tempResultante);
                }
                else
                {
                    MessageBox.Show("Matriz invalida 2!", "Error - Matriz");
                    return;
                }
                if (determinante == 0)
                {
                    MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                    return;
                }
                float[,] tempMatrizResultante = Calculos.GerarInversa(determinante, matrizAdjunta);
                int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }
        private void btnGerarOposta_Click(object sender, EventArgs e)
        {
            if (matrizResultado == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];

            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matrizResultado[x, y].Text, out n);
                    tempResultante[x, y] = n;

                }
            }

            float[,] tempMatrizResultante = Calculos.GerarOposta(tempResultante);
            int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }

        private void btnDeterminanteMatriz3_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempResultante[x, y] = n;

                    }
                }
                if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
                {
                    determinante = Calculos.GerarDeterminante2x2(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
                {
                    determinante = Calculos.GerarDeterminante3x3(tempResultante);
                    MessageBox.Show("" + determinante, "Determinante...");
                }
                else
                {
                    MessageBox.Show("Não é possível gerar determinante !", "Error - Matriz invalida ");
                }
            }

            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnTranspostaMatriz3_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];

                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(matrizResultado[x, y].Text, out n);
                        tempResultante[x, y] = n;

                    }
                }

                float[,] tempMatrizResultante = Calculos.GerarTransposta(tempResultante);
                int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
                matrizResultado = new NumericUpDown[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                groupBoxResultado.Controls.Clear();
                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        matrizResultado[x, y] = new NumericUpDown();
                        matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                        matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                        matrizResultado[x, y].Left = y * TamanhoText + 6;
                        matrizResultado[x, y].Width = TamanhoText;
                        groupBoxResultado.Controls.Add(matrizResultado[x, y]);
                    }
                }
            }
            catch(Exception)
            {
                mensagem();
            }
            
        }

        private void btnLimparMatriz1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Não há oque limpar", "Aviso Importante");
            }
            else
            {
                panel1.Controls.Clear();
            }           
        }

        private void btnLimparMatriz2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Não há oque limpar", "Aviso Importante");
            }

            else
            {
                panel2.Controls.Clear();
            }
            
        }

        private void btnLimparMatriz3_Click(object sender, EventArgs e)
        {
            if (matrizResultado == null)
            {
                MessageBox.Show("Não há oque limpar", "Aviso Importante");
            }

            else
            {
                panel3.Controls.Clear();
            }
        }

        private void btn_criarMatriz1_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Controls.Clear();
                panel3.Controls.Clear();
                linha1 = Convert.ToInt32(numericUpDown1.Value);
                coluna1 = Convert.ToInt32(numericUpDown2.Value);
                int tamanhoLargura = coluna1 * 2;

                Matriz1 = new NumericUpDown[linha1, coluna1];
                int TamanhoText = panel1.Width / coluna1 + tamanhoLargura;
                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        Matriz1[x, y] = new NumericUpDown();
                        Matriz1[x, y].Font = new Font("Microsoft Sans Serif", 10f);
                        Matriz1[x, y].Text = "00";
                        Matriz1[x, y].BackColor = Color.LightGray;
                        Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 10;
                        Matriz1[x, y].Left = y * TamanhoText + 2;
                        Matriz1[x, y].Width = 40;
                        Matriz1[x, y].Height = 10;
                        panel1.Controls.Add(Matriz1[x, y]);
                    }
                }
            }

            catch(Exception)
            {
                mensagem();
            }         
        }

        private void btnOpostaMatriz1_Click(object sender, EventArgs e)
        {

        }

        private void btnOpostaMatriz3_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        float n = 0;
                        float.TryParse(Matriz1[x, y].Text, out n);
                        tempResultante[x, y] = n;
                    }
                }

                float[,] tempMatrizResultante = Calculos.GerarOposta(tempResultante);
                int TamanhoText = groupBoxConfigurações.Width / Matriz1.GetLength(1);
                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    }
                }
            }

            catch (Exception)
            {
                mensagem();
            }
        }

        

        static void mensagem()
        {
            MessageBox.Show("Houve algum problema", "Error");
        }

        private void groupBoxConfigurações_Enter(object sender, EventArgs e)
        {

        }
    }
}
