using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_Matrizes
{
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

        public static float gerarDeterminante(float [,] matriz)
        {
            float resultado = 0;

            if (matriz.GetLength(0) == 1)
            {
                return matriz[0,0];
            }
            else
            {
                for (int i = 0; i < matriz.GetLength(1); i++)
                {
                    resultado += matriz[0, i] * (float)Math.Pow(-1, 0 + i) * gerarDeterminante(matriz);
                }

                return resultado;
            }
        }

        public static float[,] GerarInversa(float determinante, float[,] matriz1)
        {
            float[,] matrizInversa = new float[matriz1.GetLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < matriz1.GetLength(1); y++)
                {
                    float n = matriz1[x, y];
                    n = n / determinante;
                    matrizInversa[x, y] += n;
                }
            }

            return matrizInversa;
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
            float[,] matrizOposta = new float[matriz.GetLength(0), matriz.GetLength(1)];
            for (int x = 0; x < matrizOposta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizOposta.GetLength(1); y++)
                {
                    matrizOposta[x, y] += matriz[x, y] * -1;
                }
            }
            return matrizOposta;
        }
    }
}
