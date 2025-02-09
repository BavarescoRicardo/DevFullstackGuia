API RESTful para Gest�o de Reservas de Mot�is

Este projeto � uma API RESTful desenvolvida em .NET 8 para gerenciar reservas de mot�is. A API inclui funcionalidades como cadastro e login de usu�rios (com autentica��o JWT), listagem de reservas filtradas por data e c�lculo de faturamento mensal. O banco de dados utilizado � o PostgreSQL, e o projeto foi desenvolvido com foco em seguran�a, performance e boas pr�ticas de desenvolvimento.
Requisitos do Projeto

    .NET 8 SDK instalado.

    PostgreSQL instalado e configurado.

    Postman ou outra ferramenta para testar endpoints da API.

    Git (opcional, para clonar o reposit�rio).

Como Executar o Projeto
1. Clonar o Reposit�rio
bash
Copy

git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio

2. Configurar o Banco de Dados

    Crie um banco de dados no PostgreSQL chamado motel_db.

    Atualize a string de conex�o no arquivo appsettings.json:
    json
    Copy

    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=motel_db;Username=seu_usuario;Password=sua_senha"
    }

3. Aplicar Migra��es

    Execute as migra��es para criar as tabelas no banco de dados:
    bash
    Copy

    dotnet ef database update

4. Executar a API

    Execute o projeto:
    bash
    Copy

    dotnet run

    A API estar� dispon�vel em:
    Copy

    http://localhost:3030
    https://localhost:3033

5. Testar os Endpoints

    Use o Postman ou Swagger UI para testar os endpoints:

        Acesse o Swagger UI em:
        Copy

        http://localhost:3030/swagger

Endpoints da API
Autentica��o

    POST /api/auth/register
    Cadastra um novo usu�rio.
    json
    Copy

    {
      "username": "usuario",
      "password": "senha123"
    }

    POST /api/auth/login
    Realiza o login e retorna um token JWT.
    json
    Copy

    {
      "username": "usuario",
      "password": "senha123"
    }

Reservas

    GET /api/reservas?data=YYYY-MM-DD
    Lista todas as reservas filtradas por data.

    POST /api/reservas
    Cria uma nova reserva.
    json
    Copy

    {
      "motelId": 1,
      "suiteId": 1,
      "clienteId": 1,
      "dataInicio": "2024-02-10",
      "dataFim": "2024-02-12"
    }