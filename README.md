# 🧠 WebApi_Estudo

> 🚧 **Projeto em desenvolvimento** — será expandido para incluir **backend completo (API)** e **frontend (interface web)**.  
> O código é baseado nas aulas da professora [CrisTech](https://www.youtube.com/@CrisTech20), com **adaptações, refatorações e melhorias pessoais** de aprendizado e arquitetura.

---

## 🧩 Descrição

API para **gerenciamento de funcionários**, com **CRUD completo** e padrão de resposta genérico `ServiceResponse<T>`.  
Desenvolvida em **ASP.NET Core (.NET 6)** com **Entity Framework Core** e, agora, **integração com o FastReport** para geração de **relatórios em PDF**.

Este projeto faz parte do meu estudo contínuo em **boas práticas de arquitetura .NET**, **injeção de dependência** e **padrões de projeto aplicados a APIs REST**.  
Embora inspirado nas aulas da professora [CrisTech](https://www.youtube.com/@CrisTech20), o código contém **incrementos e soluções próprias**, explorando abordagens técnicas mais completas.

---

## ⚙️ Tecnologias utilizadas

- .NET 6  
- C#
- Entity Framework Core  
- FastReport (para geração de relatórios PDF)  
- Visual Studio 2022 / CLI .NET  

📁 **Repositório:** [https://github.com/joaolmacanhao/WebApi_Estudo](https://github.com/joaolmacanhao/WebApi_Estudo)

---

## 🧠 Visão geral

A API foi desenvolvida para praticar conceitos fundamentais de **ASP.NET Core**, **Entity Framework Core** e **integração de relatórios** com **FastReport**.

Ela implementa:
- CRUD completo de funcionários.  
- Padrão de resposta genérico (`ServiceResponse<T>`).  
- Geração de relatórios em PDF com dados de funcionários.  
- Injeção de dependência via `Program.cs`.  
- Separação em camadas (Controller, Service, DataContext).

---

## 🧾 Estrutura de resposta

Todas as respostas seguem um formato consistente, garantindo clareza e padronização na comunicação entre backend e clientes:

```json
{
  "data": ...,
  "success": true,
  "message": "mensagem informativa"
}

# WebApi_Estudo — Guia de instalação e execução (PT-BR)

Esta seção descreve, passo a passo, como baixar, configurar e executar o projeto WebApi_Estudo em uma máquina que só tem uma IDE (Visual Studio 2022) instalada. Inclui configuração do banco (SQL Server / LocalDB), migrações EF Core e instalação/configuração do FastReport (OpenSource).

Pré-requisitos
- Windows (ou outro SO compatível com .NET 6)
- Visual Studio 2022 com workload ".NET desktop development" e "ASP.NET and web development"
- .NET 6 SDK instalado (confirme com: dotnet --version)
- Git (ou usar o clone pela IDE)
- SQL Server (Express / LocalDB / Developer) ou acesso a um servidor SQL
- (Opcional) SQL Server Management Studio (SSMS) para gerenciar o banco

1) Clonar o repositório
- Pela linha de comando:
  git clone https://github.com/joaolmacanhao/WebApi_Estudo.git
- Ou: __File > Open > Project/Solution__ no Visual Studio e colar a URL no diálogo de clone.

2) Abrir solução no Visual Studio
- Abra a solução (sln) dentro da pasta clonada.
- No Solution Explorer, selecione WebApi_Estudo como projeto inicial (Set as Startup Project).

3) Pacotes NuGet necessários
No Visual Studio: __Tools > NuGet Package Manager > Package Manager Console__ ou gerencie via UI em _Dependencies > NuGet_.

Pacotes recomendados (adicionar se não existirem):
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- FastReport.OpenSource
- FastReport.OpenSource.Web
- FastReport.OpenSource.Export.PdfSimple
- FastReport.OpenSource.Data.MsSql

Com dotnet CLI (opcional — no diretório do projeto):
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package FastReport.OpenSource
dotnet add package FastReport.OpenSource.Web
dotnet add package FastReport.OpenSource.Export.PdfSimple
dotnet add package FastReport.OpenSource.Data.MsSql

Instale a ferramenta EF Core (se não tiver):
dotnet tool install --global dotnet-ef

4) Configurar connection string
Edite o arquivo appsettings.Development.json / appsettings.json do projeto WebApi_Estudo e defina a chave "ConnectionStrings:DefaultConnection". Exemplo:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WebApi_Estudo_Db;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Reports": {
    "ReportsPath": "Reports" // Sugestão: pasta dentro do projeto
  }
}

Observações:
- Para SQL Server local: use (localdb)\mssqllocaldb ou .\SQLEXPRESS conforme instalado.
- Se usar credenciais, substitua Trusted_Connection=True por User ID=...;Password=...;

5) Migrations / Criar/Atualizar banco
Se o projeto já inclui migrations (ver pasta Migrations), aplique-as:

Pelo Package Manager Console no Visual Studio (Default project: WebApi_Estudo):
Update-Database

Ou com dotnet CLI:
dotnet ef database update --project WebApi_Estudo --startup-project WebApi_Estudo

Se precisar criar nova migration:
dotnet ef migrations add NomeDaMigration --project WebApi_Estudo --startup-project WebApi_Estudo

6) Configurar FastReport (.frx)
- Crie uma pasta no projeto para relatórios, ex: /Reports
- Coloque o arquivo .frx (ex: ListagemFuncionarios.frx) dentro desta pasta.
- Marque o arquivo .frx como "Copy to Output Directory" = "Copy if newer" (clicar no arquivo no Solution Explorer > Properties).
- No controller atual o caminho é absoluto. Recomendo usar configuração via appsettings e ContentRootPath, ex:
  - Defina Reports:ReportsPath no appsettings (ver acima).
  - No controller, construa o caminho usando IHostEnvironment.ContentRootPath + configuration key (opcional: eu posso gerar o snippet se quiser).

7) Permissões e acesso ao arquivo .frx
- Se usar caminho absoluto (C:\...), verifique permissões de leitura.
- Preferível manter os .frx dentro do projeto (Reports) para facilitar deploy e CI.

8) Execução (local)
- Pelo Visual Studio: F5 (IIS Express) ou Ctrl+F5 (sem debug).
- Ou pela CLI, na pasta do projeto:
  dotnet run --project WebApi_Estudo

A API estará acessível em http://localhost:{porta} (veja output do run/launchSettings.json).

9) Endpoints úteis (presentes no controller FuncionarioController)
- GET    /api/Funcionario             — listar
- GET    /api/Funcionario/{id}        — obter por id
- POST   /api/Funcionario             — criar
- DELETE /api/Funcionario/{id}        — deletar
- PUT    /api/Funcionario/inativa/{id} — inativar
- PUT    /api/Funcionario/reativa/{id} — reativar
- GET    /api/Funcionario/relatorio   — gera PDF com FastReport (retorna application/pdf)

10) CORS
- Projeto já inclui política "FrontendDev" para http://localhost:4200. Se usar outra origem, altere em Program.cs.
- Se liberar credenciais (cookies) use .AllowCredentials() e não use .AllowAnyOrigin() ao mesmo tempo.

11) Debug e problemas comuns
- Erro "Cannot modify ServiceCollection after application is built.": verifique se não há chamadas builder.Services.Add* após var app = builder.Build(); (todos os Add devem ficar antes do Build()).
- Erros EF: confirme connection string, execute Update-Database, verifique se o usuário do banco tem permissões.
- FastReport: se faltar pacote, instale os pacotes OpenSource correspondentes. Se for versão comercial, siga instruções de licenciamento do fornecedor.
- Caminho do .frx não encontrado: verifique se o arquivo foi copiado para output (bin) e se o controller monta o caminho corretamente.

12) Deploy básico
- Para publicar: __Build > Publish__ no Visual Studio e escolha destino (Azure, Folder, IIS).
- Garanta que a connection string de produção esteja correta e que os arquivos .frx estejam incluídos no publish.

Exemplo mínimo de appsettings.json (copiar e ajustar):
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WebApi_Estudo_Db;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Reports": {
    "ReportsPath": "Reports"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}

