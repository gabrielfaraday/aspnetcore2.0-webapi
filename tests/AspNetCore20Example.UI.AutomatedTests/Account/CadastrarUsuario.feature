Funcionalidade: Cadastrar Usuario
	Um usuário pode se cadastrar para poder 
	gerenciar seus contatos.

@TestesAutomatizadosNovoUsuario

Cenário: Cadastrar Usuario com Sucesso
	Dado que o usuário está na tela inicial do site
	E clica no link para se registrar
	E preenche os campos com os valores
		| Campo          | Valor           |
		| nome           | Usuario Teste   |
		| cpf            | 73565979003     |
		| email          | teste@teste.com |
		| senha          | 123@Qa          |
		| confirmarSenha | 123@Qa          |
	Quando clicar no botão Registrar
	Então será registrado e será redirecionado com sucesso

@TestesAutomatizadosNovoUsuario

Cenário: Cadastrar Usuario com CPF já utilizado
	Dado que o usuário está na tela inicial do site
	E clica no link para se registrar
	E preenche os campos com os valores
		| Campo          | Valor            |
		| nome           | Usuario Teste  2 |
		| cpf            | 73565979003      |
		| email          | teste2@teste.com |
		| senha          | 123@Qa           |
		| confirmarSenha | 123@Qa           |
	Quando clicar no botão Registrar
	Entao Recebe uma mensagem de erro de CPF já cadastrado

@TestesAutomatizadosNovoUsuario

Cenário: Cadastrar Usuario com Email já utilizado
	Dado que o usuário está na tela inicial do site
	E clica no link para se registrar
	E preenche os campos com os valores
		| Campo          | Valor           |
		| nome           | Usuario Teste 3 |
		| cpf            | 10725033010     |
		| email          | teste@teste.com |
		| senha          | 123@Qa          |
		| confirmarSenha | 123@Qa          |
	Quando clicar no botão Registrar
	Entao recebe uma mensagem de erro de email já cadastrado

@TestesAutomatizadosNovoUsuario
		
Cenário: Cadastrar Usuario com Senha em tamanho inferior ao permitido
	Dado que o usuário está na tela inicial do site
	E clica no link para se registrar
	E preenche os campos com os valores
		| Campo          | Valor            |
		| nome           | Usuario Teste 8  |
		| cpf            | 10725033010      |
		| email          | teste2@teste.com |
		| senha          | 3Qa             |
		| confirmarSenha | 3Qa             |
	Quando clicar no botão Registrar
	Entao Recebe uma mensagem de erro de que a senha esta em tamanho inferior ao permitido

@TestesAutomatizadosNovoUsuario

Cenário: Cadastrar Usuario com Senha diferentes
	Dado que o usuário está na tela inicial do site
	E clica no link para se registrar
	E preenche os campos com os valores
		| Campo          | Valor            |
		| nome           | Usuario Teste 9  |
		| cpf            | 10725033010      |
		| email          | teste2@teste.com |
		| senha          | 123@Qa           |
		| confirmarSenha | 123@Qb           |
	Quando clicar no botão Registrar
	Entao Recebe uma mensagem de erro de que a senha estao diferentes