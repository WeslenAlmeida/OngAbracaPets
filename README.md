# Projeto que atende as seguintes necessidades de uma ONG de animais:

1 - Cadastra os dados de uma Pessoa Física que deseja adotar um animal.

2 - Cadastra os dados de um animal para ele ter a possibilidade de ser adotado.

3 - Cria um registro das adoções com os dados do Adotante e do Animal e a data da adoção.

4 - Os cadastros podem ser alterados com exceção do CPf do Adotante e o número do chip do Animal.

5 - Uma pessoa física pode adotar mais de um animal.

O Sistema se comunica com o banco de dados SQL Server para Consultar e Alterar as 3 tabelas que o sistema necessita (Adotante, Animal e Adocao).

No banco de dados foi criada uma TRIGGER para inserir na data da doação, a data atual após ser inseridos os dados na tabela Adocao.

