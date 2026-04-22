# Sistema Lanche

Sistema acadêmico desenvolvido como parte da disciplina de Desenvolvimento de Sistemas, com o objetivo de simular o controle de estoque e vendas de uma rede de lanches fictícia, considerando regras comuns de operação como validade de produtos, controle de temperatura e registro de vendas.

---

## Objetivo

O sistema foi desenvolvido para gerenciar um pequeno estoque de produtos alimentícios, simulando situações do dia a dia de um ambiente comercial, como controle de itens perecíveis, atualização de estoque e registro de operações.

---

## Tecnologias utilizadas

- C#
- Windows Forms
- SQLite

---

## Funcionalidades

- Cadastro de produtos no estoque  
- Controle de quantidade de itens  
- Validação de temperatura (entre 2°C e 8°C)  
- Controle de data de validade dos produtos  
- Registro de vendas  
- Simulação de modo offline para vendas  
- Sincronização de vendas offline  
- Exclusão de registros com verificação por token (autenticação simples simulada)  
- Registro de logs para auditoria das operações  

---

## Observação sobre segurança (MFA simplificado)

O sistema utiliza uma verificação por token como forma de simulação de autenticação para operações sensíveis, como exclusão de registros. Essa abordagem foi implementada apenas para fins acadêmicos.

---

## Observações gerais

O projeto foi desenvolvido com foco no aprendizado de estruturação de sistemas, integração com banco de dados e aplicação de regras de negócio em um cenário prático.

---

## Considerações finais

O desenvolvimento deste projeto contribuiu para a prática de conceitos fundamentais de engenharia de software, especialmente organização de sistemas, persistência de dados e regras de negócio.
