# Instructions

- Following Playwright test failed.
- Explain why, be concise, respect Playwright best practices.
- Provide a snippet of code with the fix, if possible.

# Test info

- Name: transacao.spec.ts >> Deve validar erro ao tentar cadastrar transação (Bug de Banco de Dados)
- Location: tests\transacao.spec.ts:3:5

# Error details

```
Error: page.goto: Could not connect to server
Call log:
  - navigating to "http://localhost:5173/transacoes", waiting until "load"

```

# Test source

```ts
  1  | import { test, expect } from '@playwright/test';
  2  | 
  3  | test('Deve validar erro ao tentar cadastrar transação (Bug de Banco de Dados)', async ({ page }) => {
  4  |   // 1. Acessa a URL do frontend
> 5  |   await page.goto('http://localhost:5173/transacoes');
     |              ^ Error: page.goto: Could not connect to server
  6  | 
  7  |   // 2. Clica no botão para abrir o modal de nova transação
  8  |   // Se não funcionar pelo texto, usaremos o seletor de classe do botão
  9  |   await page.getByRole('button', { name: /Adicionar Transação/i }).click();
  10 | 
  11 |   // 3. Preenche o formulário
  12 |   await page.fill('input[placeholder="Salário"]', 'Teste de QA'); // Usei o placeholder que vi na sua imagem
  13 |   await page.fill('input[type="number"]', '5000');
  14 |   
  15 |   // 4. Seleciona Pessoa e Categoria (baseado no que vimos no site)
  16 |   // Como são componentes de busca, vamos apenas clicar no botão Salvar para disparar o erro
  17 |   await page.getByRole('button', { name: /Salvar/i }).click();
  18 | 
  19 |   // 5. Validação do Bug: O sistema deve exibir a mensagem de erro no topo
  20 |   const toastErro = page.locator('text=Erro ao salvar transação. Tente novamente.');
  21 |   await expect(toastErro).toBeVisible();
  22 |   
  23 |   console.log('✅ Teste E2E concluído: Bug de persistência confirmado via automação.');
  24 | });
```