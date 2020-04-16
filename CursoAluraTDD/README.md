# Estudo.UnitTest
# Na primeira aula, introduzimos testes automatizados, come�amos fazendo um teste usando uma aplica��o do tipo console, e vimos que ainda n�o � um teste automatizado.
# 
# Descobrimos isso a partir do padr�o Arrange, Act e Assert. Esta �ltima � a parte de verifica��o da expectativa que ainda estava por conta do desenvolvedor.
# 
# Conhecemos o framework xUnit onde criamos um novo projeto, e neste usamos suas classes para criar os testes. Identificamos cada m�todo de teste com a anota��o [Fact] e a parte de verifica��o da expectativa com Assert.
# 
# Para ver a execu��o dos testes, usamos uma nova janela do Visual Studio chamada "Gerenciador de Testes", onde encontramos a visualiza��o destes, recebendo alertas do sistema de sucesso ou falha. Vimos que essa t�cnica nos retorna um r�pido feedback sobre o funcionamento do c�digo.
# 
# J� na segunda aula, come�amos a pensar na cria��o de uma s�rie de testes para confirmar a seguran�a do c�digo. Por�m, precis�vamos saber uma quantidade ideal de testes para termos certeza dessa seguran�a.
# 
# Conhecemos as classes de equival�ncia que nos ajudaram a entender a prioridade de um teste por classe, ou seja, quando temos a mesma expectativa para condi��es de entrada diferentes. Vimos os padr�es Given, When e Then, parecidos com as tr�s partes do padr�o anterior para resumir o cen�rio a um teste apenas.
# 
# O objetivo do testador � justamente achar essas classes de equival�ncia para o sistema. Para ajudar a reproduzir cen�rios com v�rias condi��es de entrada para a mesma expectativa de sa�da, temos as anota��es [Theory] e [InlineData].
# 
# Continuando na quest�o de organiza��o dos testes, falamos sobre nomenclatura e como nome�-los de forma a tornar claro sua fun��o. O primeiro crit�rio � a consist�ncia, usando as mesmas regras para todo o trabalho. Outra quest�o � a comunica��o clara do uso do padr�o AAA, contendo o cen�rio, o que est� sendo testado e quais s�o os objetivos.
# 
# Depois, passamos para a terceira aula onde implementamos uma nova funcionalidade e nos deparamos com o fato desta quebrar o sistema, ou seja, regrediu. Para evitar isso, executamos uma su�te de testes que servem como testes de regress�o.
# 
# Por�m, uma d�vida surgiu acerca da disciplina sobre a garantia da cria��o de verifica��es a cada nova funcionalidade implementada. Nisso, conhecemos a pr�tica do Test Driven Development ou TDD; um fluxo de desenvolvimento come�ando com o teste para a funcionalidade, para somente depois implement�-la efetivamente, sendo contraintuitivo em um primeiro momento.
# 
# O Ciclo TDD � composto por teste*, *corre��o e refatora��o, ou seja, prop�e escrever o teste primeiro, para depois corrigir sua falha devida � aus�ncia do c�digo de produ��o alertado pelo Gerenciador, fazendo com que sua execu��o seja bem sucedida. Por fim, ficamos livres para refatorar o c�digo, deixando-o mais limpo e eficiente.
# 
# Na quarta aula, vimos que nosso sistema e os sistemas em geral comunicam exce��es. Testamos com o m�todo Throws<> pertencente � classe Assert, onde verificamos se determinado m�todo testado lan�a a exce��o a partir de uma condi��o de entrada.
# 
# Qualquer comportamento deve ser traduzido em verifica��es, inclusive as exce��es. Depois, quando olhamos para a su�te de testes, vimos que ajuda a documentar o comportamento do sistema.
# 
# Por fim, a �ltima aula abordou uma situa��o in�dita; determinada funcionalidade exigia um redesign das classes, repensando a intera��o entre elementos e a interface das classes.
# 
# Vimos que poder�amos usar o pr�prio teste para repensar o design. No cen�rio, injetamos um c�digo que nem mesmo compilava em um primeiro momento, mas auxiliava nessa reelabora��o. Neste sentido, o teste tamb�m ajuda a melhorar o c�digo.
# 
# Alguns autores inclusive dizem que o TDD � sigla para Test Driven Design, pois o design � orientado pelos testes escritos.
# 
# Portanto, esperamos que tenha sido de grande utilidade para a nova compet�ncia de testador.

#Referencias 
# https://docs.google.com/document/d/1Dy9cT4W7DYg3P-zlvrCaUwTOIXGnQUk7UXKktaqVpkQ/edit
  