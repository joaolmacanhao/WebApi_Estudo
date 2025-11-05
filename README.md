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

# WebApi_Estudo — Guia de instalação e execução (PT-BR)

Esta seção descreve, passo a passo, como baixar, configurar e executar o projeto **WebApi_Estudo** em uma máquina que só tem uma IDE (Visual Studio 2022) instalada. Inclui configuração do banco (SQL Server / LocalDB), migrações EF Core e instalação/configuração do **FastReport (OpenSource)**.

---

## 🧰 Pré-requisitos

- Windows (ou outro SO compatível com .NET 6)  
- Visual Studio 2022 com workloads:
  - **.NET desktop development**
  - **ASP.NET and web development**
- .NET 6 SDK instalado → confirme com:  
  ```bash
  dotnet --version
  ```
- Git (ou use o clone pela IDE)
- SQL Server (Express / LocalDB / Developer) ou acesso a um servidor SQL
- (Opcional) SQL Server Management Studio (SSMS) para gerenciar o banco

---

## 1️⃣ Clonar o repositório

Via terminal:
```bash
git clone https://github.com/joaolmacanhao/WebApi_Estudo.git
```

Ou via Visual Studio:  
**File > Open > Project/Solution** e cole a URL no diálogo de clone.

---

## 2️⃣ Abrir a solução no Visual Studio

- Abra o arquivo `.sln` dentro da pasta clonada.  
- No **Solution Explorer**, clique com o botão direito em `WebApi_Estudo` →  
  **Set as Startup Project**

---

## 3️⃣ Instalar os pacotes NuGet necessários

Abra no Visual Studio:  
**Tools > NuGet Package Manager > Package Manager Console**  
ou adicione via **Dependencies > Manage NuGet Packages**.

Pacotes essenciais:
```bash
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
FastReport.OpenSource
FastReport.OpenSource.Web
FastReport.OpenSource.Export.PdfSimple
FastReport.OpenSource.Data.MsSql
```

Ou instale via CLI:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package FastReport.OpenSource
dotnet add package FastReport.OpenSource.Web
dotnet add package FastReport.OpenSource.Export.PdfSimple
dotnet add package FastReport.OpenSource.Data.MsSql
```

Instale a ferramenta global do EF Core (se necessário):
```bash
dotnet tool install --global dotnet-ef
```

---

## 4️⃣ Configurar a Connection String

Edite o arquivo `appsettings.Development.json` **ou** `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=WebApi_Estudo_Db;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Reports": {
    "ReportsPath": "Reports"
  }
}
```

**Observações:**
- Para SQL Server local use `(localdb)\\mssqllocaldb` ou `.\SQLEXPRESS`.
- Se usar login/senha, substitua `Trusted_Connection=True` por:
  ```
  User ID=seuUsuario;Password=suaSenha;
  ```

---

## 5️⃣ Executar migrações e criar banco

Se já existir a pasta `Migrations`, apenas atualize o banco:

No **Package Manager Console** (default project: WebApi_Estudo):
```bash
Update-Database
```

Ou via CLI:
```bash
dotnet ef database update --project WebApi_Estudo --startup-project WebApi_Estudo
```

Criar nova migration (se necessário):
```bash
dotnet ef migrations add NomeDaMigration --project WebApi_Estudo --startup-project WebApi_Estudo
```

---

## 6️⃣ Configurar FastReport (.frx)

- Crie uma pasta no projeto chamada `/Reports`
- Coloque o arquivo `.frx` (ex: `ListagemFuncionarios.frx`) dentro dela.
- Propriedade do arquivo: **Copy to Output Directory = Copy if newer**
- Recomenda-se definir o caminho via `appsettings` e não hardcoded.

Exemplo de uso via configuração:
- Defina `Reports:ReportsPath` no appsettings.
- No controller, combine `IHostEnvironment.ContentRootPath` + caminho configurado.

---

## 7️⃣ Permissões e acesso ao arquivo .frx

- Se usar caminho absoluto (C:\...), verifique permissões de leitura.  
- Ideal manter os `.frx` **dentro do projeto** para facilitar deploy e CI/CD.

---

## 8️⃣ Executar localmente

Pelo Visual Studio:  
- `F5` (IIS Express) ou `Ctrl+F5` (sem debug).

Ou via terminal:
```bash
dotnet run --project WebApi_Estudo
```

A API estará disponível em:  
👉 http://localhost:{porta}  
(verifique `launchSettings.json` para confirmar a porta).

---

## 9️⃣ Endpoints principais (FuncionarioController)

| Método | Endpoint | Descrição |
|---------|-----------|-----------|
| GET | /api/Funcionario | Lista todos os funcionários |
| GET | /api/Funcionario/{id} | Retorna funcionário por ID |
| POST | /api/Funcionario | Cria novo funcionário |
| DELETE | /api/Funcionario/{id} | Remove funcionário |
| PUT | /api/Funcionario/inativa/{id} | Inativa funcionário |
| PUT | /api/Funcionario/reativa/{id} | Reativa funcionário |
| GET | /api/Funcionario/relatorio | Gera relatório PDF (FastReport) |

---

## 🔒 10) CORS

- Já existe a política `FrontendDev` permitindo `http://localhost:4200`.  
- Se mudar o front-end, ajuste em `Program.cs`.
- Para usar cookies, utilize `.AllowCredentials()` e **não** `.AllowAnyOrigin()`.

---

## 🧩 11) Debug e erros comuns

- ❗ *Erro:* `Cannot modify ServiceCollection after application is built.`  
  ➜ Corrija chamadas `builder.Services.Add*` colocadas após `builder.Build()`.

- ⚙️ *Erro EF Core:* verifique connection string, execute `Update-Database`, e confira permissões do banco.

- 📄 *Erro FastReport:* instale pacotes OpenSource. Se usar versão comercial, siga o licenciamento do fornecedor.

- 📁 *Erro de caminho .frx:* verifique se o arquivo foi copiado para `bin` e se o controller monta o caminho com `ContentRootPath`.

---

## 🚀 12) Deploy básico

No Visual Studio:  
**Build > Publish** → escolha destino (Azure, Pasta, IIS).

Verifique:
- Connection string correta no ambiente de produção.
- Arquivos `.frx` incluídos na publicação.

Exemplo mínimo de `appsettings.json`:

```json
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
```

---

📘 **Autor:** [João L. Macanhão](https://github.com/joaolmacanhao)  
🗓️ **Última atualização:** Novembro/2025
