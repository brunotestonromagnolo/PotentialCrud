# PotentialCrud

Para testar:

 - Instalar o plugin no Google Chrome "CORS Unblock".
	* Mesmo ajustando a Api para incluir nos headers de resposta as tags Access-Control-Allow-Origin="*"
	  para permitir todas origens, e incluindo permissão para todas as operações, o Chrome ainda estava
	  apresentando problemas de CORS Policy. (Cross-origin-resource)
 - Habilitar o plugin e ativar as seguintes opções: (opções 1 e 3)
	- Enable Access-Control-Allow-Origin;
	- Enable Access-Control-[Allow/Expose]-Headers;	

Existem 2 opções para testar:

	1. Realizar a migração de dados utilizando o Entity Framework Core;
		1.1 Neste caso, é necessário possuir o Entity Framework Core instalado 
			para realizar a migração dos dados, ou seja, criar a estrutura de dados (tabela) 
			e inserir alguns registros de exemplo;
		1.2 É possível instalar através do powershell com o seguinte comando: 
		    Install-Package Microsoft.EntityFrameworkCore.SqlServer
	2. Utilizar uma imagem já criada do banco de dados.
		2.1 Executando o docker-compose correspondente ele irá baixar a imagem correta do DockerHub;
		2.1 Caso não baixe por algum motivo, pode fazer o seguinte pull:
			 docker pull brunoromagnolo/potentialcrudsqlserver:latest	    

Passos:

	- Acessar a pasta do projeto;
	 Executar o docker compose para a criação dos containers (Bando de dados, ApiRest e FrontEnd);
	    - Criei 2 arquivos do docker composer, um realizando a criacao do banco de dados a partir de uma imagem original (docker-compose-banco_limpo.yml) 
		   e outro utilizando a imagem do banco pronto criado por mim já com a tabela e alguns dados inseridos (docker-compose-banco-pronto.yml)
		- É necessário renomear o arquivo desejado para docker-compose.yml;
		- Executar o comando: 
			docker-compose up -d
	- Após a execução do docker-compose, os 3 containers vão subir (bd, apirest e front) e já podem ser acessados.


**** OBS IMPORTANTE (Para a PRIMEIRA opção descrita):

		- Caso tenha utilizado o docker-compose com a criação do banco de dados a partir de uma imagem limpa, será necessário este passo adicional
		  para migração dos dados (criação da tabela e inserção de dados):		  
		- Acessar o caminho utilizando bash: ./PotentialCrudAPI/PotentialCrudAPI/
		- Executar o comando: 
			dotnet ef database update
		
Como testar:

	- Para acessar o front, basta acessar o seguinte endereço: http://localhost:8080/
	- Para testar a Api sem a utilização do front, é possível testar com o swagger no seguinte endereço: http://localhost:6651/swagger
	- Para acessar o banco de dados:
		- Banco de dados utilizado : SqlServer
		- Porta: 1433
		- Usuário: sa
		- Senha: yourStrong(!)Password
