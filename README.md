FornecedoresAPI

FornecedoresAPI é uma API RESTful desenvolvida com ASP.NET Core 8 para gerenciar fornecedores. A API permite realizar operações CRUD (Criar, Ler, Atualizar e Excluir) para gerenciar informações sobre fornecedores.

Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server

Requisitos

- .NET 8 SDK: Download
- SQL Server: Download

Configuração do Projeto

1. Clonar o Repositório

   git clone https://github.com/xXPythonistaXx/FornecedoresAPI.git
   cd FornecedoresAPI

2. Configurar o Banco de Dados

   1. Criar o Banco de Dados
      - Abra o SQL Server Management Studio (SSMS) e crie um banco de dados chamado FornecedoresDB.

   2. Configurar a String de Conexão
      - Abra o arquivo appsettings.json e configure a string de conexão para o SQL Server:
        {
          "ConnectionStrings": {
            "DefaultConnection": "Server=localhost;Database=FornecedoresDB;Trusted_Connection=True;"
          }
        }

3. Restaurar Pacotes e Aplicar Migrações

   1. Atualize o banco de dados, no Package Manager Console, execute o comando:
   
     Update-Database

4. Iniciar a API

   Para iniciar a API, execute o comando:
   dotnet run

   A API estará disponível em https://localhost:5001.

Endpoints da API

1. Listar Todos os Fornecedores

   - Método: GET
   - URL: /api/fornecedores

     Resposta de Exemplo:
     [
       {
         "id": 1,
         "nome": "Fornecedor A",
         "email": "fornecedorA@exemplo.com"
       },
       {
         "id": 2,
         "nome": "Fornecedor B",
         "email": "fornecedorB@exemplo.com"
       }
     ]

2. Buscar Fornecedor por ID

   - Método: GET
   - URL: /api/fornecedores/{id}

     Resposta de Exemplo:
     {
       "id": 1,
       "nome": "Fornecedor A",
       "email": "fornecedorA@exemplo.com"
     }

3. Adicionar um Novo Fornecedor

   - Método: POST
   - URL: /api/fornecedores
   - Corpo da Requisição:
     {
       "nome": "Fornecedor C",
       "email": "fornecedorC@exemplo.com"
     }

     Resposta de Sucesso:
     {
       "id": 3,
       "nome": "Fornecedor C",
       "email": "fornecedorC@exemplo.com"
     }

4. Atualizar um Fornecedor Existente

   - Método: PUT
   - URL: /api/fornecedores/{id}
   - Corpo da Requisição:
     {
       "nome": "Fornecedor Atualizado",
       "email": "fornecedorAtualizado@exemplo.com"
     }

     Resposta de Sucesso:
     {
       "id": 1,
       "nome": "Fornecedor Atualizado",
       "email": "fornecedorAtualizado@exemplo.com"
     }

5. Excluir um Fornecedor

   - Método: DELETE
   - URL: /api/fornecedores/{id}

     Resposta de Sucesso:
     {
       "message": "Fornecedor excluído com sucesso."
     }

Documentação da API

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse https://localhost:5001/swagger para visualizar e testar os endpoints.
