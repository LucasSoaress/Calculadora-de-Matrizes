# Calculadora de Matrizes

Calculadora de Matrizes é um projeto educacional, realizado por estudantes do 2º ano, do curso de programação, do <strong>Colégio Estadual José Leite Lopes - NAVE RJ (Núcleo Avançado em Educação).</strong>
Nosso objetivo principal é ajudar estudantes/professores/entusiastas de matemática, seja para aprender ou ensinar, como funciona uma Matriz e suas funções e propriedades.

<b>Desenvolvedores:</b>

<strong>[Lucas Soares](github.com/lucassoaress), [Luca Alves](https://github.com/LucaAlvesNaveRio), [Patrick Scoralick](https://github.com/patrickscoralickcosta) & [Thais Dutra](https://github.com/ThaisDutra)</strong>


<h2>Ferramentas</h2>
Essa calculadora pode fazer cálculos com uma matriz de tamanho até 10 por 10. Pode realizar todas as operações: Soma, Subtração, Multiplicação, Oposta, Transposta, Inversa, Escalar, Elevar e Determinante. 
Contém um gráfico que representa a translação, rotação e escalonamento de polígonos 2D, por meio da própria calculadora. E tem também uma explicação/definição sobre cada operação.

<h2>Input de Matrizes</h2>

Para preencher a matriz, basta clicar em cada espaço e digitar os valores. Somente é aceito números reais.


<h1>Operações</h1>

<h2>Soma</h2>

Essa ferramenta soma duas matrizes, desde que tenham o mesmo tamanho. Ela soma os valores que são da mesma posição, veja no exemplo a seguir:
```
a b   |   e f   |   (a+e) (b+f)
c d   |   g h   |   (c+g) (d+h)
```
<h2>Subtração</h2>
Essa ferramenta subtrai uma matriz da outra, desde que tenham o mesmo tamanho. Ela subtrai os valores que são da mesma posição, veja no exemplo a seguir:
```
a b   |   e f   |   (a-e)  (b-f)
c d   |   g h   |   (c-g)  (d-h)
```

<h2>Multiplicação</h2>
Essa ferramenta multiplica uma matriz pela outra, desde que o número de colunas da primeira é igual ao número de linhas da segunda. Ela multiplica toda uma linha por uma coluna e então soma, resultando num valor, que adquire a posição da interseção do cálculo, veja no exemplo a seguir:
```
a b   |   e f   |   [(a*e)+(b*g)]  [(c*e)+(d*g)]
c d   |   g h   |   [(a*f)+(b*h)]  [(c*f)+(d*h)]
```
<h2>Determinante</h2>
Essa ferramenta calcula a determinante de uma matriz, desde que seja de ordem quadrada. Os métodos utilizados para tal cálculo podem ser: Sarrus, Chio, La Place e Binet, veja no exemplo a seguir:
```
a b   |   (a*d) - (b*c)
c d   |  (Regra de Sarrus)
```

<h2>Multiplicação Escalar</h2>
Essa ferramenta multiplica cada elemento de uma matriz pelo número desejado, veja no exemplo a seguir:
```
F   |   a b   |   Fa Fb
F    |   c d   |   Fc Fd
```
<h2>Elevação</h2>
Essa ferramenta eleva cada elemento de uma matriz pelo número desejado, veja no exemplo a seguir:
```
F^| a b | Fa Fb
  | c d | Fc Fd
  ```

<h2>Inversa</h2>
Essa ferramenta transforma acha o inverso da matriz aplicada. A inversa de uma matriz, é a matriz necessária para que a primeira seja multiplicada e resulte na Matriz Identidade, veja no exemplo a seguir:
```
c a  b   |   e  f   |   1   0
c  d   |   g  h   |   0   1
```
<h6>(Matriz) (Matriz Inversa) (Identidade)</h6>

<h2>Transposta</h2>
Essa ferramenta transforma uma matriz, invertendo linhas por colunas.
```
a b   |   a c
c d   |   b d
```

<h2>Oposta</h2>
Essa ferramenta transforma uma matriz, trocando o sinal de todos os elementos da matriz.
```
a -b   | -a +b
c  d   | -c -d
```

<h2>Lei de Formação</h2>
Essa ferramenta forma uma matriz de acordo com a lei de formação designado. 

`a * i + j`

Observação: Para a nossa calculadora sua lei só pode conter operações básicas, Soma; Subtração; Divisão; Multiplicação.

<h1>Gráfico</h1>
Essa ferramenta lhe permite criar polígonos em uma tela 2D. Basta preencher a matriz com os valores desejados (Cada coluna representando x,y do ponto, no plano cartesiano).

<h2>Rotação</h2>
Essa ferramenta, em conjunto com o gráfico, lhe permite rotacionar o polígono desenhado, no ângulo designado pelo usuário.

<h2>Translação</h2>
Essa ferramenta, em conjunto com o gráfico, lhe permite transladar o polígono desenhado, somando em cada ponto o valor designado, mudando a posição do mesmo.

<h2>Escalonamento</h2>
Essa ferramenta, em conjunto com o gráfico, lhe permite escalonar o polígono desenhado, aumentando ou diminuindo o mesmo.

<h1>Agradecimentos Especiais!</h1>
Muito obrigado a professora de matemática <strong>Cristina Neves</strong> e ao professor de programação <strong>Antoanne Pontes</strong>, que desenvolveram esse projeto e nos auxiliaram na realização do mesmo!

Agradecemos também a você, usuário, e esperamos que seja útil para você! Qualquer comentário, basta nos contatar!



