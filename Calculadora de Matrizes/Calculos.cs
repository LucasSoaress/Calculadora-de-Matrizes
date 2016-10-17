using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;


namespace Calculadora_de_Matrizes
{
    /// <summary>
    /// Classe criada para conter os cálculos ultilizados na calculadora
    /// </summary>
    class Calculos
    {   
        /// <summary>
        /// Responsável por fazer os cálculos de soma das matrizes
        /// </summary>
        /// <param name="matriz1">Recebe os valores da Matriz1</param>
        /// <param name="matriz2">Recebe os valores da Matriz2</param>
        /// <returns>Retorna a Matriz Resultante</returns>
        public static float[,] SomandoMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultado = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];

            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = matriz1[x, y] += matriz2[x, y];
                }
            }
            return matrizResultado;
        }

        /// <summary>
        /// Responsável por fazer os cálculos de subtração das matrizes
        /// </summary>
        /// <param name="matriz1">Recebe os valores da Matriz1</param>
        /// <param name="matriz2">Recebe os valores da Matriz2</param>
        /// <returns>Retorna a Matriz Resultante</returns>
        public static float[,] SubtraindoMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultado = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = matriz1[x, y] -= matriz2[x, y];
                }
            }
            return matrizResultado;
        }

        /// <summary>
        /// Responsável por fazer os cálculos de multiplicação das matrizes
        /// </summary>
        /// <param name="matriz1">Recebe os valores da Matriz1</param>
        /// <param name="matriz2">Recebe os valores da Matriz2</param>
        /// <returns>Retorna a Matriz Resultante</returns>
        public static float[,] MultiplicandoMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultado = new float[matriz1.GetLength(0), matriz2.GetLength(1)];
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    for (int n = 0; n < matriz2.GetLength(0); n++)
                    {
                        string i = "" + matriz1[x, n];
                        matrizResultado[x, y] += matriz1[x, n] * matriz2[n, y];
                    }
                }
            }
            return matrizResultado;
        }

        /// <summary>
        /// Método para multiplicar matriz por um número qualquer
        /// </summary>
        /// <param name="matriz">Recebe a matriz para ser calculada</param>
        /// <param name="numeroQualquer">Recebe o valor pelo qual a matriz será multiplicada</param>
        /// <returns>Retorna a matriz resultante</returns>
        public static float[,] multiplicarPorNumeroQualquer(float[,] matriz, float numeroQualquer)
        {
            int linhas = matriz.GetLength(0);
            int colunas = matriz.GetLength(1);
            float[,] matrizResultado = new float[linhas, colunas];

            for (int x = 0; x < linhas; x++)
            {
                for (int y = 0; y < colunas; y++)
                {
                    matrizResultado[x, y] = matriz[x, y] * numeroQualquer;
                }
            }

            return matrizResultado;
        }

        /// <summary>
        /// Método para elevar a matriz a qualquer número
        /// </summary>
        /// <param name="matriz">Recebe a matriz que será elevada</param>
        /// <param name="expoente">Recebe o valor do seu expoente ao qual será elevada</param>
        /// <returns>Retorna a matriz resultante</returns>
        public static float[,] elevarMatrizNumeroQualquer(float[,] matriz, float expoente)
        {
            float[,] matrizResultado = matriz;

            for (int i = 1; i < expoente; i++)
            {
                matrizResultado = MultiplicandoMatrizes(matrizResultado, matriz);
            }
            return matrizResultado;
        }

        /// <summary>
        /// Método para achar determinante de qualquer matriz
        /// </summary>
        /// <param name="matriz"></param>
        /// <returns>Retorna o valor do determinante de qualquer matriz</returns>
        public static float gerarDeterminante(float [,] matriz)
        {
            float[,] parametro = matriz;
            float resultado = 0;
            

            if (matriz.GetLength(0) == 1)
            {
                return matriz[0,0];
            }

            for (int i = 0; i < parametro.GetLength(1); i++)
            {
                matriz = TrimArray(0, i, parametro);
                resultado += parametro[0, i] * (float)Math.Pow(-1, 0 + i) * gerarDeterminante(matriz);
            }

            return resultado;
        }

        
        /// <summary>
        /// Método para achar a Transposta de uma Matriz
        /// </summary>
        /// <param name="matriz">Recebe a Matriz para se achar a Transposta</param>
        /// <returns>Retorna a Transposta da Matriz</returns>
        public static float[,] GerarTransposta(float[,] matriz)
        {
            float[,] matrizTransposta = new float[matriz.GetLength(1), matriz.GetLength(0)];
            for (int x = 0; x < matrizTransposta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizTransposta.GetLength(1); y++)
                {
                    matrizTransposta[x, y] += matriz[y, x];
                }
            }
            return matrizTransposta;
        }

        
        /// <summary>
        /// Método para calcular a matriz oposta
        /// </summary>
        /// <param name="matriz">Recebe a matriz que será calculada</param>
        /// <returns>A matriz oposta</returns>
        public static float[,] GerarOposta(float[,] matriz)
        {
            float[,] matrizOposta = multiplicarPorNumeroQualquer(matriz, -1);
            return matrizOposta;
        }


        /// <summary>
        /// Método para calcular a identidade de uma matriz
        /// </summary>
        /// <param name="linhas">Recebe o número de linhas</param>
        /// <param name="colunas">Recebe o número de colunas</param>
        /// <returns>Retorna a matriz identidade</returns>
        public static float [,] gerarIdentidade(int linhas, int colunas)
        {
            float[,] identidadeResultante = new float[linhas, colunas];
            
            for (int i = 0; i < linhas; i++)
            {
                for (int c = 0; c < colunas; c++)
                {
                    if (i == c)
                    {
                        identidadeResultante[i, c] = 1;
                    }
                    else
                    {
                        identidadeResultante[i, c] = 0;
                    }
                }
            }

            return identidadeResultante;
        }


        /// <summary>
        /// Método para achar a matriz inversa
        /// </summary>
        /// <param name="determinante">Recebe o valor do determinante da matriz</param>
        /// <param name="matriz">Recebe a matriz</param>
        /// <returns>Retorna sua inversa</returns>
        public static float[,] gerarInversa(float determinante, float[,] matriz)
        {
            float[,] matrizInversa = new float[matriz.GetLength(0), matriz.GetLength(1)];

            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    //matrizInversa[x,y] =(float)Math.Round((decimal)) 
                }
            }

            return matrizInversa;
        }


        /// <summary>
        /// Método para remover linhas e colunas, utilizado com o método para gerarDeterminante
        /// </summary>
        /// <param name="rowToRemove">Recebe a linha para remover</param>
        /// <param name="columnToRemove">Recebe a coluna para remover</param>
        /// <param name="originalArray">Recebe a matriz original</param>
        /// <returns>Retorna a matriz com linha e coluna removidos</returns>
        public static float[,] TrimArray(int rowToRemove, int columnToRemove, float[,] originalArray)
        {
            float[,] result = new float[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                if (i == rowToRemove)
                    continue;

                for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                {
                    if (k == columnToRemove)
                        continue;

                    result[j, u] = originalArray[i, k];
                    u++;
                }
                j++;
            }

            return result;
        }

        /// <summary>
        /// Método para verificar se matrizes são simétricas
        /// </summary>
        /// <param name="matriz1">Recebe a matriz 1</param>
        /// <param name="matriz2">Recebe sua matriz transposta</param>
        /// <returns>Retorna se é simétrica ou não, a partir de uma booleana</returns>
        public static bool comparandoMatrizes(float[,] matriz1, float [,] matriz2)
        {
            bool resposta =  matriz1.Rank == matriz2.Rank &&
            Enumerable.Range(0, matriz1.Rank).All(dimension => matriz1.GetLength(dimension) == matriz2.GetLength(dimension)) &&
            matriz1.Cast<float>().SequenceEqual(matriz2.Cast<float>());

            return resposta;
        }

        
    }
}
