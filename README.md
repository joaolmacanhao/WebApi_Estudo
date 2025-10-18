# WebApi_Estudo

API simples para gerenciar funcionários — CRUD básico com padrão de resposta `ServiceResponse<T>` usando ASP.NET Core (.NET 6) e Entity Framework Core.

## Tecnologias
- .NET 6
- C# 10
- Entity Framework Core
- Visual Studio 2022 (opcional) / dotnet CLI

Repositório remoto: https://github.com/joaolmacanhao/WebApi_Estudo

## Visão geral
A API expõe endpoints para consultar e criar funcionários. A camada de serviço (`FuncionarioService`) implementa operações adicionais (buscar por id, deletar, inativar/reativar), que podem ser expostas via controller conforme necessário.

Todas as respostas seguem o formato genérico:
{
  "data": ...,
  "success": true|false,
  "message": "mensagem informativa"
}

## Modelos principais
FuncionarioModel (campos relevantes)
- Id: int
- Nome: string
- Sobrenome: string
- Departamento: string (enum)
- Ativo: bool
- Turno: string (enum)
- DataDeCriacao: DateTime
- DateDeAlteracao: DateTime

ServiceResponse<T>
- Data: T?
- Success: bool
- Message: string

Enums:
- DepartamentoEnum (Rh, Financeiro, Compras, Atendimento, Zeladoria, Estagiario)
- TurnoEnum (Matutino, Vespertino, Noturno)

## Endpoints disponíveis (expostos em FuncionarioController)
Base: /api/funcionario

- GET /api/funcionario
  - Descrição: Retorna lista de funcionários (embrulhada em ServiceResponse<List<FuncionarioModel>>).
  - Exemplo curl:
    curl -sS http://localhost:5000/api/funcionario
  - Exemplo de resposta:
    {
      "data": [
        {
          "id": 1,
          "nome": "João",
          "sobrenome": "Silva",
          "departamento": "Rh",
          "ativo": true,
          "turno": "Matutino",
          "dataDeCriacao": "2025-10-18T12:34:56",
          "dateDeAlteracao": "2025-10-18T12:34:56"
        }
      ],
      "success": true,
      "message": ""
    }

- POST /api/funcionario
  - Descrição: Cria um novo funcionário. Recebe um objeto `FuncionarioModel` (parte dos campos pode ser preenchida pelo servidor).
  - Exemplo curl:
    curl -X POST http://localhost:5000/api/funcionario \
      -H "Content-Type: application/json" \
      -d '{
        "nome": "Maria",
        "sobrenome": "Oliveira",
        "departamento": "Financeiro",
        "ativo": true,
        "turno": "Vespertino"
      }'
  - Exemplo de resposta:
    {
      "data": [ /* lista atualizada de funcionários */ ],
      "success": true,
      "message": ""
    }

Observação: a camada de serviço implementa também:
- GET por id
- DELETE por id
- Inativar (InativaFuncionario)
- Reativar (RetivaFuncionario)
Esses métodos estão presentes em `FuncionarioService` / `IFuncionarioInterface` e podem ser expostos adicionando endpoints no controller.

## Configuração e execução

1. Ajuste a connection string em `appsettings.json` para apontar ao seu banco (SQL Server, SQLite, etc.).
2. (Opcional, via Visual Studio) Abra a solução e execute __Build Solution__.
3. Criar migração / aplicar banco (duas opções):

   - Via CLI (recomendado):
     - dotnet ef migrations add InitialCreate -p WebApi_Estudo
     - dotnet ef database update -p WebApi_Estudo

   - Via Visual Studio: abra __Tools > NuGet Package Manager Console__ e execute:
     - Add-Migration InitialCreate
     - Update-Database

4. Executar a API:
   - Via Visual Studio: __Debug > Start Debugging__ (ou __Debug > Start Without Debugging__).
   - Via CLI: na pasta do projeto:
     - dotnet run

5. Testar endpoints com Postman, curl ou Swagger (se habilitado).

## Observações e sugestões
- O serviço já trata erros e devolve mensagens via `ServiceResponse<T>`. Verifique logs/console em caso de exceções.
- Se desejar expor os métodos de delete/inativar/reativar, adicione os respectivos endpoints no controller (seguindo o padrão do `FuncionarioController`).
- Considere habilitar Swagger para documentação automática (adicionar Swashbuckle no `Program.cs`) para facilitar testes.

## Contribuições
- Fork, branch de feature e PR.
- Siga as boas práticas: testes, tratamento de erros e validação de entrada.
