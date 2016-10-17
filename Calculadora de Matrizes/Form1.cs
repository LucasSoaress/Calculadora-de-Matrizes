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
            textBoxNumeroMatriz1.KeyPress += new KeyPressEventHandler(MatrizesInterface.naoMostrarLetras);
            textBoxNumeroMatriz1.Visible = false;

            textBoxNumeroMatriz2.KeyPress += new KeyPressEventHandler(MatrizesInterface.naoMostrarLetras);
            textBoxNumeroMatriz2.Visible = false;

            textBoxNumeroMatriz3.KeyPress += new KeyPressEventHandler(MatrizesInterface.naoMostrarLetras);
            textBoxNumeroMatriz3.Visible = false;

        }

        //private TextBox[,] Matriz1;
       // private TextBox[,] Matriz2;
        //private TextBox[,] matrizResultado;
       // private float determinante;

        private int linha1, coluna1;
        private int linha2, coluna2;

        public static float[,] matriz1, matriz2, matrizResultante;
        
        private void gerarDeterminante()
        {
            if (linha1 == coluna1 && linha1 != 0 && coluna1 != 0)
            {
                float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
                float determinanteResultado = Calculos.gerarDeterminante(matriz1);
                MessageBox.Show("Resultado = " + determinanteResultado);
            }
            else if (linha1 == 0 && coluna1 == 0)
            {
                MessageBox.Show("Não há matriz para se calcular o determinante", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Esta matriz não é quadrada!", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gerarInversa()
        {
            float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float determinanteResultado = Calculos.gerarDeterminante(matriz1);
            float[,] matrizInversa = Calculos.gerarInversa(determinanteResultado, matriz1);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizInversa);
        }
        
        /// <summary>
        /// Método para achar a identidade de uma matriz e desenhar no painel
        /// </summary>
        /// <param name="linhas">Recebe número de linhas</param>
        /// <param name="colunas">Recebe o número de colunas</param>
        private void gerarIdentidade(int linhas, int colunas)
        {
            float[,] matrizIdentidade = Calculos.gerarIdentidade(linhas, colunas);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizIdentidade);
        }

        /// <summary>
        /// Método chamado ao apertar o botão gerar, e a opção transposta estiver sido escolhida
        /// </summary>
        private void mostrarTranspostaMatriz1()
        {
            panel3.Controls.Clear();
            float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float[,] resultado = Calculos.GerarTransposta(matriz1);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, resultado);
            groupBoxResultado.Text = ("Resultado da transposta da Matriz 1");

            if (Calculos.comparandoMatrizes(matriz1,resultado))
            {
                MessageBox.Show("Esta é uma matriz simétrica","Aviso Importante",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Método chamado ao apertar o botão gerar, e a opção oposta estiver sido escolhida
        /// </summary>
        private void mostrarOpostaMatriz1()
        {
            panel3.Controls.Clear();
            float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float[,] matrizOposta = Calculos.GerarOposta(matriz1);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizOposta);
            groupBoxResultado.Text = "Resultado da oposta da matriz 1";
        }

        /// <summary>
        /// Método chamado ao apertar o botão gerar, e a opção multiplicar estiver sido escolhida
        /// </summary>
        private void multiplicarMatriz1()
        {
            try
            {
                float valor = float.Parse(textBoxNumeroMatriz1.Text);
                panel3.Controls.Clear();
                matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
                matrizResultante = Calculos.multiplicarPorNumeroQualquer(matriz1, valor);
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                groupBoxResultado.Text = "Resultado da multiplicação por um número qualquer";
            }

            catch(Exception)
            {
                MessageBox.Show("Digite um número para multiplicar", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Método para elevar a matriz a qualquer numero
        /// </summary>
        private void elevarMatriz1()
        {
            try
            {
                float expoente = float.Parse(textBoxNumeroMatriz1.Text);
                panel3.Controls.Clear();
                float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
                float[,] resultado = Calculos.elevarMatrizNumeroQualquer(matriz1, expoente);
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, resultado);
                groupBoxResultado.Text = "Resultante da Matriz 1 elevada";
            }

            catch(Exception)
            {
                MessageBox.Show("Digite um número para elevar", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
 
        private void matriz1Menu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (matriz1Menu.Text == "ESCALAR" || matriz1Menu.Text == "ELEVAR")
            {
                textBoxNumeroMatriz1.Visible = true;
            }
            else
            {
                textBoxNumeroMatriz1.Visible = false;
            }
        }

        private void btn_criarMatriz1_Click_1(object sender, EventArgs e)
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

        private void btn_criarMatriz2_Click_1(object sender, EventArgs e)
        {
            linha2 = (int)numericUpDown3.Value;
            coluna2 = (int)numericUpDown4.Value;
            if (linha2 == 0 || coluna2 == 0)
            {
                MessageBox.Show("Digite os valores de linhas e colunas para Matriz B", "Aviso Importante");
            }
            else
            {
                panel2.Controls.Clear();
                panel3.Controls.Clear();
                MatrizesInterface.instanciarTextBox(coluna2, linha2, panel2);
                MatrizesInterface.nomeDosGroupBox(groupBox2, "B", linha2, coluna2);
            }
        }

        private void btnSomar_Click_1(object sender, EventArgs e)
        {
            float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);

            if (matriz1.Length == 0 || matriz2.Length == 0)
            {
                MessageBox.Show("Não há matrizes para somar", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (linha1 == linha2 && coluna1 == coluna2)
            {
                panel3.Controls.Clear();
                matrizResultante = Calculos.SomandoMatrizes(matriz1, matriz2);
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                groupBoxResultado.Text = "Soma das Matrizes A e B";
            }
            else
            {
                DialogResult result = MessageBox.Show("As matrizes não tem ordens iguais", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");
                    MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
                    groupBoxResultado.Text = "Matriz Resultante";
                }
            }
        }

        private void btnSubtrair_Click_1(object sender, EventArgs e)
        {
            float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);

            if (matriz1.Length == 0 || matriz2.Length == 0)
            {
                MessageBox.Show("Não há matrizes para subtrair", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else if (linha1 == linha2 && coluna1 == coluna2)
            {
                float[,] matrizResultante = Calculos.SubtraindoMatrizes(matriz1, matriz2);
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                groupBoxResultado.Text = "Resultante da subtração";
            }

            else
            {
               DialogResult result = MessageBox.Show("As matrizes não tem ordens iguais", "Atenção" , MessageBoxButtons.OK, MessageBoxIcon.Information);
               if (result ==  DialogResult.OK)
               {
                    MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");
                    MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
                    groupBoxResultado.Text = "Matriz Resultante";
                }
                
            }
            
        }

        private void btnMultiplicar_Click_1(object sender, EventArgs e)
        {
            float[,] matriz1 = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);

            if (matriz1.Length == 0 || matriz2.Length == 0)
            {
                MessageBox.Show("Não há matrizes para multiplicar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (coluna1 == linha2)
            {
                matrizResultante = Calculos.MultiplicandoMatrizes(matriz1, matriz2);
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                groupBoxResultado.Text = "Resultante da multiplicação";
            }
            else if (coluna1 != linha2)
            {
                DialogResult result = MessageBox.Show("O número de colunas da Matriz A, não é igual ao número de linhas da Matriz B", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");
                    MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
                    groupBoxResultado.Text = "Matriz Resultante";
                }
            }
            
        }

        private void btnLimparMatriz2_Click_1(object sender, EventArgs e)
        {
            MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
        }

        private void btnLimparMatriz1_Click_1(object sender, EventArgs e)
        {
            MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");
        }

        private void btnLimparMatriz3_Click_1(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            groupBoxResultado.Text = "Matriz resultante";
        }

        private void buttonAction1_Click_1(object sender, EventArgs e)
        {
            switch (matriz1Menu.Text)
            {
                case "":
                    MessageBox.Show("Escolha uma das opções no menu", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "OPOSTA":
                    mostrarOpostaMatriz1();
                    break;

                case "TRANSPOSTA":
                    mostrarTranspostaMatriz1();
                    break;

                case "ESCALAR":
                    multiplicarMatriz1();
                    break;

                case "ELEVAR":
                    elevarMatriz1();
                    break;

                case "INVERSA":
                    gerarInversa();
                    break;

                case "DETERMINANTE":
                    gerarDeterminante();
                    break;

                case "IDENTIDADE":
                    gerarIdentidade(linha1, coluna1);
                    break;
            }
        }

        private void gerar_matriz2_Click_1(object sender, EventArgs e)
        {
            switch (menu_matriz2.Text)
            {
                case "":
                    MessageBox.Show("Escolha uma das opções no menu", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case "OPOSTA":
                    mostrarOpostaMatriz2();
                    break;

                case "TRANSPOSTA":
                    mostrarTranspostaMatriz2();
                    break;

                case "MULTIPLICAR":
                    multiplicarMatriz2();
                    break;

                case "ELEVAR":
                    elevarMatriz2();
                    break;
                case "IDENTIDADE":
                    gerarIdentidade(linha2, coluna2);
                        break;
            }
        }

        private void menu_matriz2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (menu_matriz2.Text == "MULTIPLICAR" || menu_matriz2.Text == "ELEVAR")
            {
                textBoxNumeroMatriz2.Visible = true;
            }
            else
            {
                textBoxNumeroMatriz2.Visible = false;
            }
        }

        private void menu_matriz3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (menu_matriz3.Text == "MULTIPLICAR" || menu_matriz3.Text == "ELEVAR")
            {
                textBoxNumeroMatriz3.Visible = true;
            }
            else
            {
                textBoxNumeroMatriz3.Visible = false;
            }
        }

       
        private void menuResumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (menuResumos.Text)
            {
                case "MATRIZES":
                    colocarExplicacao(0);
                    break;
                case "DETERMINANTES":
                    colocarExplicacao(2);
                    break;
                case "SOMA":
                    colocarExplicacao(1);
                    break;
            }
        }

        /// <summary>
        /// Método utilizado para pegar explicação de elemento
        /// </summary>
        /// <param name="posicao">Recebe um valor inteiro, que corresponde a posição da explicao no array</param>
        public void colocarExplicacao(int posicao)
        {
            labelResumos.Text = explicacao.explicacoes[posicao];
        }
        

        void mostrarOpostaMatriz2()
        {
            panel3.Controls.Clear();
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
            float[,] matrizOposta = Calculos.GerarOposta(matriz2);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizOposta);
            groupBoxResultado.Text = "Resultante da oposta matriz 2";
        }

        void mostrarTranspostaMatriz2()
        {
            panel3.Controls.Clear();
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
            float[,] resultado = Calculos.GerarTransposta(matriz2);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, resultado);
            groupBoxResultado.Text = ("Resultante da transposta matriz 2");
        }

        void multiplicarMatriz2()
        {
            try
            {
                float valor = float.Parse(textBoxNumeroMatriz2.Text);
                panel3.Controls.Clear();
                matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
                matrizResultante = Calculos.multiplicarPorNumeroQualquer(matriz2, valor);
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                groupBoxResultado.Text = "Resultante da multiplicação por um numero matriz 2";
            }

            catch(Exception)
            {
                MessageBox.Show("Digite um número para multiplicar", "Aviso Importante",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            } 
        }

        private void elevarMatriz2()
        {
            try
            {
                float expoente = float.Parse(textBoxNumeroMatriz2.Text);
                panel3.Controls.Clear();
                float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
                float[,] resultado = Calculos.elevarMatrizNumeroQualquer(matriz2, expoente);
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, resultado);
                groupBoxResultado.Text = "Resultante da Matriz 2 elevada";
            }

            catch(Exception)
            {
                MessageBox.Show("Digite um número para elevar", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }          
        }

        private void gerar_matriz3_Click(object sender, EventArgs e)
        {

        }

        private void btnInserirMatrizResultante_Click(object sender, EventArgs e)
        {
            float[,] matrizResultante = MatrizesInterface.resgatarNumeros(panel3,linha1,coluna1);

            if (matrizResultante == null)
            {
                MessageBox.Show("Atenção", "Não há matriz para ser lida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (comboBoxInserir.Text == "A")
                {
                    panel1.Controls.Clear();
                    MatrizesInterface.instanciarTextBoxMatrizResultante(panel1, matrizResultante);
                }
                else if (comboBoxInserir.Text == "B")
                {
                    panel2.Controls.Clear();
                    MatrizesInterface.instanciarTextBoxMatrizResultante(panel2, matrizResultante);
                }
            }
        } 
    }
}

