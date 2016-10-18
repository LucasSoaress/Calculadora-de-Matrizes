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
    /// <summary>
    /// Classe associada ao design do form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Váriaveis iniciadas como false, para não mostrar os textboxs de fórmulas e cálculos
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            textBoxNumeroMatriz1.KeyPress += new KeyPressEventHandler(MatrizesInterface.naoMostrarLetras);
            textBoxNumeroMatriz1.Visible = false;

            textBoxNumeroMatriz2.KeyPress += new KeyPressEventHandler(MatrizesInterface.naoMostrarLetras);
            textBoxNumeroMatriz2.Visible = false;

            textBoxNumeroMatriz3.KeyPress += new KeyPressEventHandler(MatrizesInterface.naoMostrarLetras);
            textBoxNumeroMatriz3.Visible = false;

            formulaMatriz1.Visible = false;
            formulaMatriz2.Visible = false;

        }

        private int linha1, coluna1;
        private int linha2, coluna2;

        public static float[,] matriz1, matriz2, matrizResultante;

        /// <summary>
        /// Método para gerar determinante da matriz 1
        /// </summary>
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

            if (Calculos.comparandoMatrizes(matriz1, resultado))
            {
                MessageBox.Show("Esta é uma matriz simétrica", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            catch (Exception)
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

            catch (Exception)
            {
                MessageBox.Show("Digite um número para elevar", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// <summary>
        /// Método para escolher opção no menu drop da Matriz A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void matriz1Menu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (matriz1Menu.Text)
            {
                case "ESCALAR":
                    textBoxNumeroMatriz1.Visible = true;
                    break;
                case "ELEVAR":
                    textBoxNumeroMatriz1.Visible = true;
                    break;
                case "FÓRMULA":
                    formulaMatriz1.Visible = true;
                    break;
                default:
                    formulaMatriz1.Visible = false;
                    textBoxNumeroMatriz1.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// Método para clique do botão criar matriz 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para clique do botão criar matriz 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para clique do botão SOMAR MATRIZES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para clique do botão SUBTRAIR MATRIZES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                DialogResult result = MessageBox.Show("As matrizes não tem ordens iguais", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");
                    MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
                    groupBoxResultado.Text = "Matriz Resultante";
                }

            }

        }

        /// <summary>
        /// Método para clique do botão MULTIPLICAR MATRIZES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Método para o botão limpar da matriz 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMatriz2_Click_1(object sender, EventArgs e)
        {
            MatrizesInterface.limparMatrizes(panel2, numericUpDown3, numericUpDown4, groupBox2, "Matriz B");
        }

        /// <summary>
        /// Método para o botão limpar da matriz 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMatriz1_Click_1(object sender, EventArgs e)
        {
            MatrizesInterface.limparMatrizes(panel1, numericUpDown1, numericUpDown2, groupBox1, "Matriz A");
        }

        /// <summary>
        /// Método para o botão limpar da matriz resultante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMatriz3_Click_1(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            groupBoxResultado.Text = "Matriz resultante";
        }
        /// <summary>
        /// Método de clique para o botão gerar da matriz 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    inversaMatriz1();
                    break;

                case "DETERMINANTE":
                    gerarDeterminante();
                    break;

                case "IDENTIDADE":
                    gerarIdentidade(linha1, coluna1);
                    break;

                case "FÓRMULA":
                    preecherMatriz1PorFormula();
                    break;
            }
        }

        /// <summary>
        /// Método para preecher matriz 1 com formula dada por usuario
        /// Método auxilia o evento de clique do botão gerar
        /// </summary>
        private void preecherMatriz1PorFormula()
        {
            try
            {
                float[,] matrizResultante = Calculos.matrizPorFormula((int)numericUpDown1.Value, (int)numericUpDown2.Value, formulaMatriz1.Text);
                panel1.Controls.Clear();
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel1, matrizResultante);
            }
            catch(Exception)
            {
                MessageBox.Show("Fórmula para lei de formação inválida", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        /// <summary>
        /// Método de clique do botão gerar para matriz 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                case "FÓRMULA":
                    preencherMatriz2PorFormula();
                    break;

                case "INVERSA":
                    inversaMatriz2();
                    break;
            }
        }

        /// <summary>
        /// Método para gerar inversa da matriz 2
        /// </summary>
        private void inversaMatriz2()
        {
            try
            {
                float[,] matrizInicial = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
                float[,] matrizResultante = Calculos.gerarInversa(matrizInicial);
                panel3.Controls.Clear();
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                groupBoxResultado.Text = "Inversa da Matriz B";
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro na inversa de sua matriz");
            }
            
        }

        /// <summary>
        /// Método para gerar inversa da matriz 1
        /// </summary>
        private void inversaMatriz1()
        {
            try
            {
                float[,] matrizInicial = MatrizesInterface.resgatarNumeros(panel1, linha1, coluna1);
                float[,] matrizResultante = Calculos.gerarInversa(matrizInicial);
                panel3.Controls.Clear();
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizResultante);
                groupBoxResultado.Text = "Inversa da Matriz A";
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro na inversa de sua matriz");
            }
        }
        /// <summary>
        /// Método para preecnher matriz 2 por fórmula
        /// Método que auxilia o clique do botão gerar 
        /// </summary>
        private void preencherMatriz2PorFormula()
        {
            try
            {
                float[,] matrizResultante = Calculos.matrizPorFormula(linha2, coluna2, formulaMatriz2.Text);
                panel2.Controls.Clear();
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel2, matrizResultante);
            }
            catch(Exception)
            {
                MessageBox.Show("Lei de Formação para matriz inválida", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método para escolher opção do menu drop da Matriz B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_matriz2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (menu_matriz2.Text)
            {
                case "ESCALAR":
                    textBoxNumeroMatriz2.Visible = true;
                    break;
                case "ELEVAR":
                    textBoxNumeroMatriz2.Visible = true;
                    break;
                case "FÓRMULA":
                    formulaMatriz2.Visible = true;
                    break;
                default:
                    formulaMatriz2.Visible = false;
                    textBoxNumeroMatriz2.Visible = false;
                    break;
            }
        }


        /// <summary>
        /// Método para escolher opção da Matriz Resultante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para escolher opção do menu drop, para explicação na aba de sobre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Método para mostrar Oposta da Matriz 2 - associado ao clique 
        /// </summary>
        void mostrarOpostaMatriz2()
        {
            panel3.Controls.Clear();
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
            float[,] matrizOposta = Calculos.GerarOposta(matriz2);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, matrizOposta);
            groupBoxResultado.Text = "Resultante da oposta matriz 2";
        }

        /// <summary>
        /// Método para mostrar transposta da Matriz 2 - associado ao clique
        /// </summary>
        void mostrarTranspostaMatriz2()
        {

            panel3.Controls.Clear();
            float[,] matriz2 = MatrizesInterface.resgatarNumeros(panel2, linha2, coluna2);
            float[,] resultado = Calculos.GerarTransposta(matriz2);
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel3, resultado);
            groupBoxResultado.Text = ("Resultante da transposta matriz 2");

            if (Calculos.comparandoMatrizes(matriz2, resultado))
            {
                MessageBox.Show("Esta é uma matriz simétrica", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Método para multiplicar Matriz 2 - associado ao clique
        /// </summary>
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

            catch (Exception)
            {
                MessageBox.Show("Digite um número para multiplicar", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Método para elevar Matriz 2 - associado ao clique
        /// </summary>
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

            catch (Exception)
            {
                MessageBox.Show("Digite um número para elevar", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Método de evento do clique do botão criar matriz para o gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void criarMatrizGrafico_Click(object sender, EventArgs e)
        {
            try
            {
                MatrizesInterface.instanciarTextBox((int)numericUpDownColunasGrafico.Value, 2, panel4GraficoMatriz);
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Método para evento de clique no botão criar gráfico a partir da matriz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCriarGrafico_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] matrizInicial = MatrizesInterface.resgatarNumeros(panel4GraficoMatriz, 2, (int)numericUpDownColunasGrafico.Value);
                Grafico.desenharPontos(chart1, matrizInicial, "Matrizes");
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro", "Aviso Importante");
            }
        }

        /// <summary>
        /// Método para evento de clique do botão limpar do painel da matriz para o gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparMatriz_Click(object sender, EventArgs e)
        {
            panel4GraficoMatriz.Controls.Clear();
        }

        /// <summary>
        /// Método para evento de clique do botão limpar gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimparGrafico_Click(object sender, EventArgs e)
        {
           // chart1.Series["Matrizes"].Points.Clear();
        }

        private void gerar_matriz3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método de clique do botão para inserir valores da matriz resultante nas matrizes A e B 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInserirMatrizResultante_Click(object sender, EventArgs e)
        {
            try
            {
                //float[,] matrizResultante1 = MatrizesInterface.resgatarNumeros(panel3, linha1, coluna1);
               // panel1.Controls.Clear();
               // f//loat[,] matrizResultante2;

                if (matrizResultante == null)
                {
                    MessageBox.Show("Atenção", "Não há matriz para ser lida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (comboBoxInserir.Text == "A")
                    {
                        passarNumerosParaA();
                    }
                    else if (comboBoxInserir.Text == "B")
                    {
                        panel2.Controls.Clear();
                        MatrizesInterface.instanciarTextBoxMatrizResultante(panel2, matrizResultante);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro", "Aviso Importante");
            }
            
        }

        private void passarNumerosParaA()
        {
            float[,] matrizParaA = MatrizesInterface.resgatarNumeros(panel3, linha1, coluna1);
            panel1.Controls.Clear();
            MatrizesInterface.instanciarTextBoxMatrizResultante(panel1, matrizParaA);
        }

        /// <summary>
        /// Método do evento KeyPress, para bloquear outras letras da caixa para inserir fórmula da Matriz A
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formulaMatriz1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string caracteresPermitidos = " 0123456789IJ,.;+-^/*";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper())))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Método do evento KeyPress, para bloquear outras letras da caixa para inserir fórmula da Matriz B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formulaMatriz2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string caracteresPermitidos = " 0123456789IJ,.;+-^/*";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper())))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Método do evento KeyPress, para bloquear outras letras da caixa para inserir fórmula para Matriz do Gráfico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbFormulaMatrizGrafico_KeyPress(object sender, KeyPressEventArgs e)
        {
            string caracteresPermitidos = " 0123456789IJ,.;+-^/*";

            if (!(caracteresPermitidos.Contains(e.KeyChar.ToString().ToUpper())))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Método do evento do clique do botão gerar matriz por fórmula para criar matriz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGerarMatrizPorFormula_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] matrizResultante = Calculos.matrizPorFormula(2, (int)numericUpDownColunasGrafico.Value, txbFormulaMatrizGrafico.Text);
                panel4GraficoMatriz.Controls.Clear();
                MatrizesInterface.instanciarTextBoxMatrizResultante(panel4GraficoMatriz, matrizResultante);
            }
            catch (Exception)
            {
                MessageBox.Show("Fórmula para lei de formação inválida", "Aviso Importante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

