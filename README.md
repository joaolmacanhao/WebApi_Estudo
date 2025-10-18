# WebApi_Estudo

> 🚧 Projeto em desenvolvimento — será expandido para incluir **backend completo (API)** e **frontend (interface web)**.  
> O código está sendo escrito com base nas aulas da professora [CrisTech](https://www.youtube.com/@CrisTech20), com **adaptações e melhorias pessoais** conforme minhas próprias decisões técnicas e de aprendizado.

---

## 🧩 Descrição

API simples para gerenciar funcionários — CRUD básico com padrão de resposta genérico `ServiceResponse<T>`, desenvolvida em **ASP.NET Core (.NET 6)** com **Entity Framework Core**.

Este projeto faz parte do meu estudo contínuo em desenvolvimento .NET e boas práticas de arquitetura.  
Embora inspirado nas aulas da professora [CrisTech](https://www.youtube.com/@CrisTech20), o código contém **alterações, refatorações e incrementos próprios**, explorando soluções e padrões adicionais.

---

## ⚙️ Tecnologias utilizadas

- .NET 6  
- C# 10  
- Entity Framework Core  
- Visual Studio 2022 (ou CLI .NET)  

📁 Repositório: [https://github.com/joaolmacanhao/WebApi_Estudo](https://github.com/joaolmacanhao/WebApi_Estudo)

---

## 🧠 Visão geral

A API foi desenvolvida com o objetivo de praticar conceitos fundamentais de **ASP.NET Core** e **Entity Framework Core**, implementando um **CRUD completo de funcionários** com separação em camadas e padrão de resposta genérico (`ServiceResponse<T>`).

O projeto está **em desenvolvimento contínuo** e fará parte de uma aplicação mais ampla, que incluirá também **frontend** e **funcionalidades adicionais** (como autenticação, controle de acesso, e integração com banco de dados real).  

Embora o código tenha sido inicialmente baseado nas aulas da professora [**CrisTech**](https://www.youtube.com/@CrisTech20), ele contém **adaptações, melhorias e extensões próprias**, feitas conforme meu aprendizado e preferências de implementação.

A arquitetura adota uma estrutura simples, porém escalável:
- **Controllers**: expõem os endpoints da API.  
- **Services**: concentram a lógica de negócio.  
- **DataContext (EF Core)**: gerencia o acesso e persistência dos dados.  

Todas as respostas seguem um formato consistente, garantindo clareza e padronização na comunicação entre backend e clientes:

```json
{
  "data": ...,
  "success": true|false,
  "message": "mensagem informativa"
}

🧾 Modelos principais
FuncionarioModel
Campo	Tipo	Descrição
Id	int	Identificador do funcionário
Nome	string	Primeiro nome
Sobrenome	string	Sobrenome
Departamento	string (enum)	Setor de atuação
Ativo	bool	Indica se o funcionário está ativo
Turno	string (enum)	Período de trabalho
DataDeCriacao	DateTime	Data de cadastro
DateDeAlteracao	DateTime	Data da última modificação
ServiceResponse<T>
Campo	Tipo	Descrição
Data	T?	Dados retornados
Success	bool	Indica sucesso ou falha
Message	string	Mensagem de retorno
Enums

DepartamentoEnum: Rh, Financeiro, Compras, Atendimento, Zeladoria, Estagiario

TurnoEnum: Matutino, Vespertino, Noturno

🌐 Endpoints disponíveis

Base: /api/funcionario

GET /api/funcionario

Retorna a lista de funcionários.

Exemplo de resposta:

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

POST /api/funcionario

Cria um novo funcionário.

Exemplo:

curl -X POST http://localhost:5000/api/funcionario \
  -H "Content-Type: application/json" \
  -d '{
    "nome": "Maria",
    "sobrenome": "Oliveira",
    "departamento": "Financeiro",
    "ativo": true,
    "turno": "Vespertino"
  }'

Outros métodos implementados (na camada de serviço)

GetFuncionarioById

DeleteFuncionario

InativaFuncionario

ReativaFuncionario

Esses métodos estão em FuncionarioService / IFuncionarioInterface e podem ser expostos no controller conforme necessidade.

⚙️ Como executar o projeto

Ajuste a connection string em appsettings.json (SQL Server, SQLite etc.).

Compile o projeto:

dotnet build


Crie e atualize o banco:

dotnet ef migrations add InitialCreate
dotnet ef database update


Execute:

dotnet run


Teste os endpoints com Swagger, Postman ou curl.

💡 Observações

O retorno ServiceResponse<T> padroniza as respostas e mensagens de erro.

O projeto será evoluído continuamente, incluindo camada frontend (Angular) e integração completa.

Planejo seguir boas práticas de arquitetura, versionamento e testes automatizados durante o desenvolvimento.

🙌 Créditos

Projeto baseado nas aulas da professora CrisTech
, com adaptações e melhorias próprias para fins de aprendizado e aprofundamento técnico.

🤝 Contribuições

Sinta-se à vontade para contribuir com sugestões, PRs ou melhorias.
Siga boas práticas de versionamento, testes e tratamento de exceções.

🧑‍💻 Autor: João Leonardo Macanhão
📅 Início do projeto: Outubro de 2025
🔗 Repositório: joaolmacanhao/WebApi_Estudo
