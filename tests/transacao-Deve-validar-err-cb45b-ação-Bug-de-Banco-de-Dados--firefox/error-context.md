# Instructions

- Following Playwright test failed.
- Explain why, be concise, respect Playwright best practices.
- Provide a snippet of code with the fix, if possible.

# Test info

- Name: transacao.spec.ts >> Deve validar erro ao tentar cadastrar transação (Bug de Banco de Dados)
- Location: tests\transacao.spec.ts:3:5

# Error details

```
Error: page.goto: NS_ERROR_CONNECTION_REFUSED
Call log:
  - navigating to "http://localhost:5173/transacoes", waiting until "load"

```

# Page snapshot

```yaml
- generic [ref=e2]:
  - generic [ref=e3]:
    - heading "Unable to connect" [level=1] [ref=e5]
    - paragraph [ref=e6]: Firefox can’t establish a connection to the server at localhost:5173.
    - paragraph
    - list [ref=e8]:
      - listitem [ref=e9]: The site could be temporarily unavailable or too busy. Try again in a few moments.
      - listitem [ref=e10]: If you are unable to load any pages, check your computer’s network connection.
      - listitem [ref=e11]: If your computer or network is protected by a firewall or proxy, make sure that Nightly is permitted to access the web.
  - button "Try Again" [active] [ref=e13]
```

# Test source

```ts
  1  | import { test, expect } from '@playwright/test';
  2  | 
  3  | test('Deve validar erro ao tentar cadastrar transação (Bug de Banco de Dados)', async ({ page }) => {
  4  |   // 1. Acessa a URL do frontend
> 5  |   await page.goto('http://localhost:5173/transacoes');
     |              ^ Error: page.goto: NS_ERROR_CONNECTION_REFUSED
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