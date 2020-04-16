# Estudo.UnitTest
# Na primeira aula, introduzimos testes automatizados, começamos fazendo um teste usando uma aplicação do tipo console, e vimos que ainda não é um teste automatizado.
# 
# Descobrimos isso a partir do padrão Arrange, Act e Assert. Esta última é a parte de verificação da expectativa que ainda estava por conta do desenvolvedor.
# 
# Conhecemos o framework xUnit onde criamos um novo projeto, e neste usamos suas classes para criar os testes. Identificamos cada método de teste com a anotação [Fact] e a parte de verificação da expectativa com Assert.
# 
# Para ver a execução dos testes, usamos uma nova janela do Visual Studio chamada "Gerenciador de Testes", onde encontramos a visualização destes, recebendo alertas do sistema de sucesso ou falha. Vimos que essa técnica nos retorna um rápido feedback sobre o funcionamento do código.
# 
# Já na segunda aula, começamos a pensar na criação de uma série de testes para confirmar a segurança do código. Porém, precisávamos saber uma quantidade ideal de testes para termos certeza dessa segurança.
# 
# Conhecemos as classes de equivalência que nos ajudaram a entender a prioridade de um teste por classe, ou seja, quando temos a mesma expectativa para condições de entrada diferentes. Vimos os padrões Given, When e Then, parecidos com as três partes do padrão anterior para resumir o cenário a um teste apenas.
# 
# O objetivo do testador é justamente achar essas classes de equivalência para o sistema. Para ajudar a reproduzir cenários com várias condições de entrada para a mesma expectativa de saída, temos as anotações [Theory] e [InlineData].
# 
# Continuando na questão de organização dos testes, falamos sobre nomenclatura e como nomeá-los de forma a tornar claro sua função. O primeiro critério é a consistência, usando as mesmas regras para todo o trabalho. Outra questão é a comunicação clara do uso do padrão AAA, contendo o cenário, o que está sendo testado e quais são os objetivos.
# 
# Depois, passamos para a terceira aula onde implementamos uma nova funcionalidade e nos deparamos com o fato desta quebrar o sistema, ou seja, regrediu. Para evitar isso, executamos uma suíte de testes que servem como testes de regressão.
# 
# Porém, uma dúvida surgiu acerca da disciplina sobre a garantia da criação de verificações a cada nova funcionalidade implementada. Nisso, conhecemos a prática do Test Driven Development ou TDD; um fluxo de desenvolvimento começando com o teste para a funcionalidade, para somente depois implementá-la efetivamente, sendo contraintuitivo em um primeiro momento.
# 
# O Ciclo TDD é composto por teste*, *correção e refatoração, ou seja, propõe escrever o teste primeiro, para depois corrigir sua falha devida à ausência do código de produção alertado pelo Gerenciador, fazendo com que sua execução seja bem sucedida. Por fim, ficamos livres para refatorar o código, deixando-o mais limpo e eficiente.
# 
# Na quarta aula, vimos que nosso sistema e os sistemas em geral comunicam exceções. Testamos com o método Throws<> pertencente à classe Assert, onde verificamos se determinado método testado lança a exceção a partir de uma condição de entrada.
# 
# Qualquer comportamento deve ser traduzido em verificações, inclusive as exceções. Depois, quando olhamos para a suíte de testes, vimos que ajuda a documentar o comportamento do sistema.
# 
# Por fim, a última aula abordou uma situação inédita; determinada funcionalidade exigia um redesign das classes, repensando a interação entre elementos e a interface das classes.
# 
# Vimos que poderíamos usar o próprio teste para repensar o design. No cenário, injetamos um código que nem mesmo compilava em um primeiro momento, mas auxiliava nessa reelaboração. Neste sentido, o teste também ajuda a melhorar o código.
# 
# Alguns autores inclusive dizem que o TDD é sigla para Test Driven Design, pois o design é orientado pelos testes escritos.
# 
# Portanto, esperamos que tenha sido de grande utilidade para a nova competência de testador.

#Referencias 
# https://docs.google.com/document/d/1Dy9cT4W7DYg3P-zlvrCaUwTOIXGnQUk7UXKktaqVpkQ/edit
  