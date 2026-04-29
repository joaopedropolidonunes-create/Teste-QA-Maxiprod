 Solução: Teste Técnico QA - Pirâmide de Testes

Este repositório contém a automação de testes para o sistema "Minhas Finanças", estruturado conforme a estratégia de Pirâmide de Testes.

 Estrutura da Pirâmide

Unitários (Base): Testes de lógica no Back-end (C#) para validar regras de negócio isoladas.

Integração (Meio): Validação da comunicação entre API e Banco de Dados (verificado via Swagger/Logs).

End-to-End (Topo): Fluxos completos de usuário simulados com Playwright no Front-end (React).

 Como rodar os testes:

1. Testes Unitários (.NET)

Estes testes validam as regras de negócio isoladas, como a restrição de idade para receitas no backend.

Pré-requisitos: Ter o .NET SDK instalado.

Comandos:

cd backend
dotnet test


2. Testes End-to-End (Playwright)

Estes testes simulam a navegação real do usuário e validam a integração total do fluxo de transações.

Pré-requisitos: Node.js instalado e dependências do Playwright.

Comandos:

Rodar testes no terminal
npx playwright test

Rodar testes com interface visual
npx playwright test --ui


3. Testes de Integração (Manual/Logs)

A validação de integração foi realizada através da análise de logs da API e via Swagger (Interface de documentação da API).

Endpoint validado: POST /api/Transacoes

Bug identificado: Erro de banco de dados (SQLite) ao tentar acessar coluna inexistente.

Bugs Encontrados

1. Crítico: Erro de Persistência no SQLite

Ao tentar salvar uma nova transação, o sistema falha devido à tentativa de inserção em uma coluna inexistente no banco de dados (CategoriaId1). Isso bloqueia a funcionalidade principal do sistema.

2. UI/UX: Acessibilidade e Interface

Contraste: Botão "Adicionar Categoria" possui baixo contraste, dificultando a leitura.

Sobreposição: No Dashboard, os rótulos do gráfico de pizza estão sobrepostos, tornando os dados ilegíveis.

Layout: Botão de paginação no relatório de totais apresenta falha visual de alinhamento.

3. Regra de Negócio: Falha de Tratamento (Erro 500)

O sistema não trata corretamente a tentativa de cadastro de receita para menores de 18 anos no Front-end, resultando em um erro genérico de servidor em vez de uma mensagem de validação amigável.

Justificativa das Escolhas

xUnit: Escolhido pela integração nativa com .NET e facilidade em isolar testes de lógica pura.

Playwright: Utilizado pela capacidade de testar em múltiplos navegadores simultaneamente (Chromium, Firefox, Webkit), o que permitiu confirmar que o bug de banco de dados era consistente em todas as plataformas.

Foco em Bugs Bloqueantes: Priorizei a automação do fluxo de transação, pois é a funcionalidade core do negócio.

Observações sobre o Teste Técnico

O teste exigiu uma análise profunda para diferenciar erros de ambiente de bugs reais. A solução entregue foca em documentar e automatizar a reprodução de falhas para acelerar a correção pelo time de desenvolvimento, cobrindo todos os níveis da pirâmide de testes solicitada.
