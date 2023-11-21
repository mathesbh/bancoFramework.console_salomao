Meu primeiro projeto PDI(bancoframework.console) - c#

> #### Criação do banco:
>
>> CREATE DATABASE bancoFramework;
> 
>> USE bancoFramework;
> 
>> CREATE TABLE Clientes(
	ID INT PRIMARY KEY,
	Nome VARCHAR(150) NOT NULL,
	Cpf VARCHAR(14) NOT NULL,
	Saldo DECIMAL(5,2) NOT NULL
 );

 ##### Modifique o usuário e senha na string de conexão localizada no arquivo appsettings.json, com as credenciais do seu banco de dados
