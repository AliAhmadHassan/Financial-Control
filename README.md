# Financial Control (Orcozol)

Financial control system built for managers at Orcozol. This ASP.NET Web Forms application centralizes budget planning, expenses, revenues, and operational reports across multiple business areas (finance, HR, telecom, and billing).

## Highlights
- Multi-module ERP-style UI: Financeiro (receita, despesa, rateio), Orcamento (carteira, previsao), Relatorios (consolidado, fechamento, extrato bancario), RH (funcionarios, provisoes, salarios), Administrador (usuarios, acesso, fornecedores), Telefonia (ramais), and Parque Grafico (boletos).
- Role-based access via menu authorization and Forms Authentication.
- Spreadsheet import/export flows for operational data (XLS/XLSX).
- Built to support multiple SQL Server databases (finance, access control, CobNet).

## Architecture
Layered design with clear separation of concerns:
- UI: `ControleFinanceiro.UI.Presentation` (ASP.NET Web Forms, master pages, themes, JS).
- BLL: `ControleFinanceiro.BLL` (business rules and orchestration).
- DAL: `ControleFinanceiro.DAL` (ADO.NET + stored procedures).
- DTO: `ControleFinanceiro.DTO` (data transfer objects and metadata).
- Common: shared helpers/utilities.

Data access is strongly structured around stored procedures and reflection-based parameter mapping. The DAL base class builds SQL parameters from DTO properties and maps results back to DTOs, while DTO attributes declare the stored procedures used for each entity.

## Tech stack
- C# / .NET Framework 4.5
- ASP.NET Web Forms (master pages, Web.config configuration)
- ADO.NET (SqlConnection, SqlCommand, SqlDataReader)
- SQL Server (stored procedures, multiple databases)
- jQuery 1.9.1 and AjaxControlToolkit
- IIS/Visual Studio era tooling (MSBuild projects, VS 2010+ compatible)

## Project structure (key folders)
- `ControleFinanceiro.UI.Presentation`: Web UI and assets (themes, scripts, pages).
- `ControleFinanceiro.BLL`: Business logic layer.
- `ControleFinanceiro.DAL`: Data access layer.
- `ControleFinanceiro.DTO`: DTOs and stored-procedure metadata.
- `Common`: shared utilities.

## Notes for running locally
- Update connection strings in `ControleFinanceiro.UI.Presentation/Web.config` and `ControleFinanceiro.DAL/App.Config` to point at your SQL Server instances.
- This solution expects stored procedures per entity (see DTO attributes and DAL base class).

## Public repo checklist
Before publishing, remove or replace any sensitive values:
- Connection strings in `ControleFinanceiro.UI.Presentation/Web.config` and `ControleFinanceiro.DAL/App.Config`.
- SMTP credentials in `ControleFinanceiro.UI.Presentation/Pages/Logados/BasePage.cs`.

## Why this matters
This project demonstrates end-to-end enterprise app development: modular UI, layered architecture, SQL-driven data access, and real operational workflows. It reflects hands-on experience delivering internal tools that support finance, operations, and management reporting.
