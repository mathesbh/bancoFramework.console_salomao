Meu primeiro projeto PDI(bancoframework.console) - c#

> #### Cria��o do banco:
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

 ##### Modifique o usu�rio e senha na string de conex�o localizada no arquivo appsettings.json, com as credenciais do seu banco de dados
