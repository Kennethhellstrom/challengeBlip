# Challenge Blip

Este repositório contém o código-fonte e os arquivos necessários para o desafio. O projeto inclui a criação de um chatbot utilizando a plataforma Blip, bem como uma API RESTful intermediária para integração com a API pública do GitHub. O objetivo é implementar um contato inteligente que siga o fluxo conversacional proposto no desafio.

---

## Tecnologias Utilizadas

### Backend (API RESTful)
- **Linguagem:** C#
- **Framework:** ASP.NET Core
- **Hospedagem:** Azure
- **Padrões de Desenvolvimento:**
  - Clean Code
  - Princípios SOLID
  - Padrão RESTful

### Chatbot
- **Plataforma:** Blip (https://portal.blip.ai)
- **Fluxo:** Baseado no exemplo fornecido pelo desafio

---

## Funcionalidades

### Chatbot
1. **Carrossel com Repositórios:**
   - Exibe os 5 repositórios de C# mais antigos da organização `takenet` no GitHub.
   - Cada card no carrossel inclui:
     - **Imagem:** Avatar da Blip no GitHub.
     - **Título:** Nome completo do repositório.
     - **Subtítulo:** Descrição do repositório.

2. **Validações de Input:**
   - Uso de expressões regulares (regex) para garantir que as entradas do usuário estejam dentro dos padrões esperados.

3. **Tratamento de Erros:**
   - Fluxo de exceções para entradas inválidas ou falhas na integração da API.

### API RESTful
1. **Endpoint para Repositórios:**
   - Url: `https://githubapi-fmehasbyeudmbtae.brazilsouth-01.azurewebsites.net/api/repositories`
   - Rota: `/api/repositories`
   - Método: `GET`
   - Retorna:
     - Lista ordenada dos repositórios mais antigos conforme os critérios especificados.

3. **Códigos de Status HTTP:**
   - `200 OK`: Sucesso.
---



