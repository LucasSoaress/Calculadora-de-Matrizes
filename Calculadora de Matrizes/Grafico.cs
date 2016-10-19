using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calculadora_de_Matrizes
{
    /// <summary>
    /// Classe para métodos do gráfico
    /// </summary>
    class Grafico
    {
        /// <summary>
        /// Váriavel para fazer a simetria do eixo X
        /// Simetria atráves de uma multiplicação por essa matriz da váriavel
        /// </summary>
        public static float[,] simetriaX = new float[2, 2] { { 1, 0 }, { 0, -1 } };

        /// <summary>
        /// Váriavel para fazer simetria do eixo Y
        /// Simetria atráves de uma multiplicação por essa matriz da váriavel
        /// </summary>
        public static float[,] simetriaY = new float[2, 2] { { -1, 0 }, { 0, 1 } };

        /// <summary>
        /// Método para desenhar os pontos no gráfico a apartir da Matriz
        /// </summary>
        /// <param name="chart">Recebe o chart para ser desenhado</param>
        /// <param name="matriz">Recebe a matriz que serão os pontos</param>
        /// <param name="series">Recebe a series do chart para desenhar os pontos</param>
        public static void desenharPontos(Chart chart, float[,]matriz, string series )
        {
            chart.Series[series].Points.Clear();

            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                chart.Series[series].Points.AddXY(matriz[0, j], matriz[1, j]);
            }
            chart.Series[series].Points.AddXY(matriz[0, 0], matriz[1, 0]);
        }

        /// <summary>
        /// Método para rotacionar a forma gerada pela matriz em qualquer angulo
        /// </summary>
        /// <param name="anguloParaRotacionar">Recebe o valor do angulo</param>
        /// <returns>Retorna a matriz rotacionada pelo angulo</returns>
        public static float [,] rotacionar(float anguloParaRotacionar)
        {
            double angulo = (Math.PI * anguloParaRotacionar) / 180;
            float[,] resultado = new float[2, 2] { { (float)Math.Cos(angulo), (float)Math.Sin(angulo) }, { (float)-Math.Sin(angulo), (float)Math.Cos(angulo) } };
            return resultado;
        }

        /// <summary>
        /// Método para aumentar o gráfico, elevando ela
        /// </summary>
        /// <param name="numero">Recebe o número para escalar</param>
        /// <returns>Retorna a matriz escalonada</returns>
        public static float[,] elevarGrafico(float numero)
        {
            float[,] resultado = new float[2, 2] { { numero, 0 }, { 0, numero } };
            return resultado;
        }

    }
}
