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
- **Status**: Expirada, Pendente, Cancelada, Finalizada | (Pendente por padrão)

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

- Task_Attributes: Define os atributos de cada tarefa (Nome, Descrição, Data de vencimento, Prioridade, Status) e utiliza modificadores de acesso protected/public.
- Connect_db: Gerencia a conexão com o banco de dados MySQL e implementa a string de conexão.
- TaskService - Armazenamento de dados (pasta de classes): Incremento dos métodos da interface ‘ITask_Storage’, onde é executado uma interação com o usuário, coleta de dados e redirecionamento para os métodos da interface ‘ITask_Execution’.
- TasKService - Execução dos comandos DB (pasta de classes): Conforme apontamento dos métodos da interface ‘ITask_Storage’, é feito a execução dos comandos (CRUD), onde ocorre a lógica de gerenciamento de tarefas e execução de operações no banco de dados com base nos métodos definidos.
- Static_Count_Task: Função responsável em realizar a contagem de tarefas presentes no banco de dados, por meio de uma operação ADO.NET e retorno de um número inteiro com o resultado.
- CheckTask: Incremento de uma lógica concisa que realiza uma operação de consulta de tarefas com status pendente, convertendo o status para expirado caso a data vinculada a tarefa seja inferior a data atual.
- Console_Main: Contém o método Main que controla o fluxo da aplicação e gerencia as interações com o usuário.

## Contato
- **Email**: [parthur207@gmail.com]
- **Telefone**: (31) 9 89650-0406
- **LinkedIn**: [www.linkedin.com/in/paulo-andrade-836956237]
