API RESTful para Gestão de Reservas de Motéis
Clique aqui para assistir ao vídeo explicativo do código
https://youtu.be/aGiVKNEMd0s

Este projeto é uma API RESTful desenvolvida em .NET 8 para gerenciar reservas de motéis. A API inclui funcionalidades como cadastro e login de usuários (com autenticação JWT), listagem de reservas filtradas por data e cálculo de faturamento mensal. O banco de dados utilizado é o PostgreSQL, e o projeto foi desenvolvido com foco em segurança, performance e boas práticas de desenvolvimento.
Requisitos do Projeto

    .NET 8 SDK instalado.

    PostgreSQL instalado e configurado.

    Postman ou outra ferramenta para testar endpoints da API.

    Git (opcional, para clonar o repositório).

Como Executar o Projeto
1. Clonar o Repositório

git clone https://github.com/seu-usuario/nome-do-repositorio.git
cd nome-do-repositorio

2. Configurar o Banco de Dados

    Crie um banco de dados no PostgreSQL chamado motel_db.

    Atualize a string de conexão no arquivo appsettings.json:
    json
    exemplo:

    "ConnectionStrings": {
      "DefaultConnection": "Host=localhost;Database=motel_db;Username=seu_usuario;Password=sua_senha"
    }

3. Aplicar Migrações

    Execute as migrações para criar as tabelas no banco de dados:
    dotnet ef database update

4. Executar a API

    Execute o projeto:
    dotnet run

    A API estará disponível em:

http://localhost:3033/swagger/index.html

5. Testar os Endpoints

    Use o Postman ou Swagger UI para testar os endpoints:

        Acesse o Swagger UI em:

        http://localhost:3030/swagger

Endpoints da API
Autenticação

    POST /api/auth/register
    Cadastra um novo usuário.
    json
    Exemplo

    {
      "username": "usuario",
      "password": "senha123"
    }

    POST /api/auth/login
    Realiza o login e retorna um token JWT.
    json
    exemplo:

    {
      "username": "usuario",
      "password": "senha123"
    }

Reservas

    GET /api/reservas
    Lista todas as reservas 

    GET /Reserva/GetReservaByData
    Lista todas as reservas filtrando a data
    Parameters     ano(int), mes(int) e dia(int?) opcional
	

    POST /api/reservas
    Cria uma nova reserva.
    json
    exemplo:

    {    
        "data": "2025-04-10",
        "motel": "id model",
        "cliente": "id cliente",
        "suite": "id suite"   
    }

Faturamentp

    GET     /api/Faturamento/mensal
    Parameters
        ano     int	
        mes     int
	
    Exibe faturamento do mes especificado pela data

Segurança

    Proteção contra SQL Injection: Uso de Entity Framework Core para consultas parametrizadas.

    Autenticação JWT: Tokens assinados e validados para proteger os endpoints.

    CORS: Configuração para permitir acesso apenas de origens confiáveis.

Otimizações

    Cache: Implementação de cache em memória para a listagem de reservas.

    Indexes: Uso de índices no banco de dados para otimizar consultas.

    Queries Otimizadas: Consultas SQL eficientes para cálculo de faturamento.

Autor

    Nome: Ricardo Bavaresco

    E-mail: bavaresco.ricardo@gmail.com

    LinkedIn: Ricardo Bavaresco
        www.linkedin.com/in/bavarescoricardo
