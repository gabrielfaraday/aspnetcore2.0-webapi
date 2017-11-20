Funcionalidade: Cadastrar contato
	Um usuário fará login no site e
	irá adicionar seus contatos

@TestesAutomatizadosNovoContato

Cenário: Adicionar Novo Contato
	Dado que o usuário está no site
	E realiza o Login
	E navega até a lista de contatos
	E clica em novo contato
	E preenche o formulário com os valores 
		| Campo                                   | Valor               |
		| nome                                    | Contato 01          |
		| email                                   | contato01@teste.com |
		| //*[@id="dataNascimento"]/div/div/input | 15/04/1997          |
		| logradouro                              | av. das nações      |
		| numero                                  | 123                 |
		| complemento                             | ap. 34              |
		| bairro                                  | centro              |
		| cep                                     | 14810112            |
		| cidade                                  | Araraquara          |
		| estado                                  | SP                  |
	Quando clicar no botao Criar
	Entao O contato é registrado e o usuario redirecionado para a edição do contato

