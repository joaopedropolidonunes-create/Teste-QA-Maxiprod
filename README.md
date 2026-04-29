Solução: Teste Técnico QA - Pirâmide de Testes

Este repositório contém a automação de testes para o sistema "Minhas Finanças", estruturado conforme a Pirâmide de Testes.

Estrutura da Pirâmide
Unitários (Base): Testes de lógica no Back-end (C#) para validar regras de negócio isoladas.
Integração (Meio): Validação da comunicação entre API e Banco de Dados (verificado via Swagger/Logs).
End-to-End (Topo): Fluxos completos de usuário simulados com Playwright no Front-end (React).

Como rodar os testes:

*Pré-requisitos: Ter o .NET SDK instalado.
*Comando
1. Testes Unitários (.NET)
Estes testes validam as regras de negócio isoladas, como a restrição de idade para receitas.
```bash
cd backend
dotnet test

2. Testes End-to-End (Front-end - Playwright)
*Estes testes simulam a navegação real do usuário e validam a integração total do fluxo de transações.
Pré-requisitos: Node.js instalado e dependências do Playwright.

*comando
npx playwright test

Comando (Modo UI - Visual)
npx playwright test --ui

3. Testes de Integração (Manual/Logs)
A validação de integração foi realizada através da análise de logs da API e via Swagger (Interface de documentação da API).

Endpoint validado: POST /api/Transacoes

Bug identificado: Erro de banco de dados (SQLite) ao tentar acessar coluna inexistente.




