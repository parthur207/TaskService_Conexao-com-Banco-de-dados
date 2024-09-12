# TaskService - Conexão com Banco de Dados

## Descrição
Este projeto é um sistema de gestão de tarefas desenvolvido em C# com integração ao banco de dados MySQL. O sistema permite a inserção, remoção, atualização e consulta de tarefas, além de listar tarefas expiradas e alterar automaticamente seu status.

## Funcionalidades Principais

### 1. Inserção de Tarefas
Permite inserir novas tarefas com os seguintes atributos: 
- **Nome da tarefa**
- **Descrição**
- **Data de vencimento**
- **Prioridade** (ALTA, MÉDIA ou BAIXA)
- **Status** (Pendente por padrão)

### 2. Remoção de Tarefas
Remove tarefas com base no nome especificado pelo usuário. Também é possível remover todas as tarefas do banco de dados.

### 3. Atualização de Tarefas
Permite alterar atributos de uma tarefa existente, como:
- Nome
- Descrição
- Data de vencimento
- Prioridade
- Status (Pendente, Finalizada ou Cancelada)

### 4. Consulta de Tarefas
Oferece diversas opções de consulta:
- Tarefa específica
- Todas as tarefas atuais
- Tarefas pendentes
- Tarefas finalizadas
- Tarefas expiradas
- Prioridade da tarefa (ALTA, MÉDIA ou BAIXA)

### 5. Verificação Automática de Expiração
O sistema verifica se as tarefas pendentes estão expiradas ao comparar a data atual com a data de vencimento, alterando automaticamente o status da tarefa para "Expirada".

## Tecnologias Utilizadas

- **Linguagem de Programação**: C#
- **Banco de Dados**: MySQL
- **Bibliotecas**: MySql.Data
- **Conceitos**: Programação orientada a objetos, Interface, Enums, Manipulação de banco de dados com ADO.NET

## Como Executar

1. Clone o repositório do projeto:
    ```bash
    git clone https://github.com/seu-repositorio/gerenciador-de-tarefas.git
    ```

2. Abra o projeto em sua IDE e configure a string de conexão com o banco de dados MySQL.

3. Compile e execute o projeto para começar a gerenciar suas tarefas.

## Estrutura do Projeto

- **Atributos.cs**: Define os atributos da tarefa, como Nome, Descrição, Data, Prioridade e Status. Também inclui enums para os valores de prioridade e status.
- **Connect_db.cs**: Gerencia a conexão com o banco de dados MySQL.
- **ITask_Execution.cs**: Interface que define as operações principais como inserir, remover, consultar e atualizar tarefas.
- **TaskService.cs**: Implementa a lógica de armazenamento e execução dos comandos no banco de dados.
- **VerificationDate.cs**: Verifica se há tarefas expiradas e altera automaticamente seu status.

## Contato
- **Email**: [parthur207@gmail.com]
- **Telefone**: (31) 9 89650-0406
- **LinkedIn**: [www.linkedin.com/in/paulo-andrade-836956237]
