# TaskFlow - Gerenciador de Tarefas via Console

Aplicação console desenvolvida em **.NET 10** para gerenciamento de lista de tarefas (*To-Do List*), com suporte a testes unitários automatizados com **xUnit** e histórico de versionamento padronizado utilizando **Conventional Commits**.

---

## 👨‍🎓 Identificação do Aluno

- **Nome:** Fernando almeida de oliveira braga
- **RA:** 326132695
- **Disciplina:** Garantia da Qualidade de Software / Gestão e Qualidade de Software
- **Professor:** Daniel Henrique Matos de Paiva
- **Instituição:** Ânima Educação

---

## 🚀 Tecnologias Utilizadas

- **C# 13**
- **.NET 10 SDK**
- **xUnit** (Testes Unitários)
- **Git** (Conventional Commits)

---

## 📁 Estrutura da Solução

```text
taskflow-console/
│
├── TaskFlow.slnx                     # Solução .NET 10
│
├── TaskFlow.Console/                 # Projeto de Console
│   ├── TaskItem.cs                   # Entidade de domínio da tarefa
│   ├── TaskManager.cs                # Gerenciador de tarefas em memória
│   ├── Program.cs                    # Interface interativa de console
│   └── TaskFlow.Console.csproj
│
└── TaskFlow.Tests/                   # Projeto de Testes Unitários
    ├── TaskManagerTests.cs           # Suíte de testes com xUnit
    └── TaskFlow.Tests.csproj
```

---

## 🛠️ Comandos Executados Passo a Passo

Abaixo está o registro completo de todos os comandos aplicados para a realização do exercício, seguindo estritamente as tarefas propostas:

### 0. Configuração do Autor no Git
```powershell
git config user.name "Fernando almeida de oliveira braga"
```

### 1. Inicialização e Estrutura do Projeto (Tarefas A e B)
```powershell
# Tarefa A: Criação da solution e do projeto Console
dotnet new sln -n TaskFlow
dotnet new console -n TaskFlow.Console
dotnet sln TaskFlow.slnx add TaskFlow.Console/TaskFlow.Console.csproj
git add TaskFlow.slnx TaskFlow.Console
git commit -m "chore(core): initialize .NET 10 solution and console project structure"

# Tarefa B: Criação do projeto de testes xUnit e adição da referência
dotnet new xunit -n TaskFlow.Tests
dotnet sln TaskFlow.slnx add TaskFlow.Tests/TaskFlow.Tests.csproj
dotnet add TaskFlow.Tests/TaskFlow.Tests.csproj reference TaskFlow.Console/TaskFlow.Console.csproj
Remove-Item TaskFlow.Tests/UnitTest1.cs
git add TaskFlow.slnx TaskFlow.Tests
git commit -m "chore(test): add xUnit test project and reference to console Project"
```

### 2. Implementação de Funcionalidades (Tarefas C e D)
```powershell
# Tarefa C: Implementação da entidade de domínio TaskItem
git add TaskFlow.Console/TaskItem.cs
git commit -m "feat(domain): implement TaskItem entity with completion logic"

# Tarefa D: Implementação do serviço de gerenciamento TaskManager
git add TaskFlow.Console/TaskManager.cs
git commit -m "feat(services): implement TaskManager logic for in-memory task management"
```

### 3. Garantia da Qualidade com Testes (Tarefa E)
```powershell
# Tarefa E: Criação da suíte de testes xUnit (TaskManagerTests.cs)
git add TaskFlow.Tests/TaskManagerTests.cs
git commit -m "test(unit): add xUnit test suite for TaskManager validation rules"

# Execução dos testes (evidencia a falha por KeyNotFoundException em GetById)
dotnet test
```

### 4. Correção de Bugs (Tarefa F)
```powershell
# Tarefa F: Ajuste em TaskManager.cs para retornar null caso a tarefa não exista
git add TaskFlow.Console/TaskManager.cs
git commit -m "fix(manager): handle missing task gracefully in search method"

# Validação dos testes após a correção (todos passam com sucesso)
dotnet test
```

### 5. Refatoração e Melhorias (Tarefas G e H)
```powershell
# Tarefa G: Menu interativo em Program.cs
git add TaskFlow.Console/Program.cs
git commit -m "refactor(console): implement interactive menu loop in Program.cs"

# Tarefa H: Documentação de compilação, execução e testes no README.md
git add README.md
git commit -m "docs(readme): add build, run and test instructions"
```

### 6. Sincronização com o Repositório Remoto
```powershell
git push origin main
```

---

## ⚙️ Como Compilar e Executar

### 1. Pré-requisitos
- [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado.

### 2. Compilar a Solução
Para restaurar dependências e compilar todos os projetos:
```bash
dotnet build
```

### 3. Executar a Aplicação Console
Para iniciar o menu interativo no terminal:
```bash
dotnet run --project TaskFlow.Console
```

### 4. Executar os Testes Unitários
Para rodar a suíte de testes automatizados com xUnit:
```bash
dotnet test
```

---

## 🧪 Cobertura de Testes Unitários

A suíte de testes xUnit valida as principais regras de negócio:
- `AddTask_Should_Add_Task_When_Title_Is_Valid`: Valida a criação correta de tarefas com título válido e status pendente.
- `AddTask_Should_Throw_Exception_When_Title_Is_Empty`: Garante que títulos nulos ou em branco lancem `ArgumentException`.
- `GetById_Should_Return_Null_When_Task_Does_Not_Exist`: Garante retorno nulo seguro ao buscar por um ID inexistente.

---

## 📜 Histórico de Commits (Conventional Commits)

Os commits foram realizados sequencialmente seguindo a especificação de *Conventional Commits*:

1. `chore(core): initialize .NET 10 solution and console project structure`
2. `chore(test): add xUnit test project and reference to console Project`
3. `feat(domain): implement TaskItem entity with completion logic`
4. `feat(services): implement TaskManager logic for in-memory task management`
5. `test(unit): add xUnit test suite for TaskManager validation rules`
6. `fix(manager): handle missing task gracefully in search method`
7. `refactor(console): implement interactive menu loop in Program.cs`
8. `docs(readme): add build, run and test instructions`

Para visualizar a árvore e o histórico limpo de commits:
```bash
git log --oneline --graph
```