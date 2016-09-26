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

        private TextBox[,] Matriz1;
        private TextBox[,] Matriz2;
        private TextBox[,] matrizResultado;
        private float determinante;

        private int linha1, coluna1;
        private int linha2, coluna2;

        public static float[,] matriz1, matriz2, matrizResultante;


        /// <summary>
        /// Clique no botão para gerar a segunda Matriz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_criarMatriz2_Click(object sender, EventArgs e)
        {
            coluna2 = (int)numericUpDown3.Value;
            linha2 = (int)numericUpDown4.Value;
            if (linha2 == 0 || coluna2 == 0)
            {
                MessageBox.Show("Digite os valores de linhas e colunas para Matriz B", "Aviso Importante");
            }
            else
            {
                panel2.Controls.Clear();
                panel3.Controls.Clear();
                MatrizesInterface.instanciarTextBox(linha2, coluna2, panel2);
                MatrizesInterface.nomeDosGroupBox(groupBox2, "B", linha2, coluna2);
            }
        }

        /// <summary>
        /// Clique no botão somar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSomar_Click(object sender, EventArgs e)
        {
                //resgata os numeros digitados pelo usuario
                matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
                matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);

                if (matriz1.Length == 0 || matriz2.Length == 0)
                {
                    MessageBox.Show("Não há matrizes para somar", "Aviso Importante");
                }
                else if (matriz1.Length == matriz2.Length)
                {
                    matrizResultante = Calculos.SomandoMatrizes(matriz1, matriz2);
                    MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                    groupBoxResultado.Text = "Soma das Matrizes A e B";
                }
                else
                {
                    DialogResult result = MessageBox.Show("As matrizes não tem ordens iguais", "Aviso Importante");
                    if (result == DialogResult.OK)
                    {
                        MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");
                        MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
                        groupBoxResultado.Text = "Matriz Resultante";
                    }
                }
        }

        /// <summary>
        /// Clique no botão de subtrair matrizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
            matrizResultante = Calculos.SubtraindoMatrizes(matriz1, matriz2);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
        }

        /// <summary>
        /// Clique no botão de multiplicar as matrizes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
            matrizResultante = Calculos.MultiplicandoMatrizes(matriz1, matriz2);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
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
                Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                panel3.Controls.Clear();
                for (int x = 0; x < Matriz1.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz1.GetLength(1); y++)
                    {
                        Matriz1[x, y] = new TextBox();
                        Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                        Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                        Matriz1[x, y].Left = y * TamanhoText + 6;
                        Matriz1[x, y].Width = TamanhoText;
                        panel3.Controls.Add(Matriz1[x, y]);
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
                Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                groupBox1.Controls.Clear();
                for (int x = 0; x < Matriz2.GetLength(0); x++)
                {
                    for (int y = 0; y < Matriz2.GetLength(1); y++)
                    {
                        Matriz2[x, y] = new TextBox();
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
                matrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
                groupBoxResultado.Controls.Clear();
                for (int x = 0; x < matrizResultado.GetLength(0); x++)
                {
                    for (int y = 0; y < matrizResultado.GetLength(1); y++)
                    {
                        matrizResultado[x, y] = new TextBox();
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

        /// <summary>
        /// Limpa o painel da Matriz A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMatriz1_Click(object sender, EventArgs e)
        {
            MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");      
        }

        /// <summary>
        /// Limpa o painel da Matriz B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMatriz2_Click(object sender, EventArgs e)
        {
            MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
        }

        /// <summary>
        /// Limpa o painel da Matriz Resultante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMatriz3_Click(object sender, EventArgs e)
        {
                panel3.Controls.Clear();
        }

        /// <summary>
        /// Clique do botão para gerar a MATRIZ A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_criarMatriz1_Click(object sender, EventArgs e)
        {
            coluna1 = (int)numericUpDown2.Value;
            linha1 = (int)numericUpDown1.Value;

            if (coluna1 == 0 || linha1 == 0)
            {
                MessageBox.Show("Digite os valores de linha e colunas para Matriz A", "Aviso Importante");
            }
            else
            {
                panel1.Controls.Clear();
                panel3.Controls.Clear();
                MatrizesInterface.instanciarTextBox(coluna1, linha1, panel1);
                MatrizesInterface.nomeDosGroupBox(groupBox1, "A", linha1, coluna1);
            }             
        }

        /// <summary>
        /// Clique no botão de multiplicar por número qualquer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMultiplicarNumero_Click(object sender, EventArgs e)
        {
            matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float valor = (float)numericUpDownMultiplicar.Value;
            matrizResultante = Calculos.multiplicarPorNumeroQualquer(matriz1, valor);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
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

