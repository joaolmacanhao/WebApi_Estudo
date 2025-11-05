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
