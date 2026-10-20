# Guia de Comandos Executados - TaskFlow

**Aluno:** Fernando almeida de oliveira braga  
**RA:** 326132695  
**Disciplina:** Garantia da Qualidade de Software / Gestão e Qualidade de Software  
**Professor:** Daniel Henrique Matos de Paiva  

---

## 💻 Relação Completa de Comandos

### 0. Configurar Usuário do Git Localmente
```powershell
git config user.name "Fernando almeida de oliveira braga"
```

---

### 1. Inicialização e Estrutura do Projeto

#### Tarefa A: Criar solution .NET 10 e projeto Console
```powershell
dotnet new sln -n TaskFlow
dotnet new console -n TaskFlow.Console
dotnet sln TaskFlow.slnx add TaskFlow.Console/TaskFlow.Console.csproj
git add TaskFlow.slnx TaskFlow.Console
git commit -m "chore(core): initialize .NET 10 solution and console project structure"
```

#### Tarefa B: Criar projeto xUnit e adicionar referência
```powershell
dotnet new xunit -n TaskFlow.Tests
dotnet sln TaskFlow.slnx add TaskFlow.Tests/TaskFlow.Tests.csproj
dotnet add TaskFlow.Tests/TaskFlow.Tests.csproj reference TaskFlow.Console/TaskFlow.Console.csproj
Remove-Item TaskFlow.Tests/UnitTest1.cs
git add TaskFlow.slnx TaskFlow.Tests
git commit -m "chore(test): add xUnit test project and reference to console Project"
```

---

### 2. Implementação de Funcionalidades

#### Tarefa C: Criar classe TaskItem
```powershell
# Criação do arquivo TaskFlow.Console/TaskItem.cs
git add TaskFlow.Console/TaskItem.cs
git commit -m "feat(domain): implement TaskItem entity with completion logic"
```

#### Tarefa D: Criar classe TaskManager
```powershell
# Criação do arquivo TaskFlow.Console/TaskManager.cs
git add TaskFlow.Console/TaskManager.cs
git commit -m "feat(services): implement TaskManager logic for in-memory task management"
```

---

### 3. Garantia da Qualidade com Testes

#### Tarefa E: Criar suíte de testes xUnit
```powershell
# Criação do arquivo TaskFlow.Tests/TaskManagerTests.cs
git add TaskFlow.Tests/TaskManagerTests.cs
git commit -m "test(unit): add xUnit test suite for TaskManager validation rules"

# Executar testes (identificando a falha no método GetById)
dotnet test
```

---

### 4. Correção de Bugs

#### Tarefa F: Tratar exceção e retornar null no GetById
```powershell
# Atualização em TaskFlow.Console/TaskManager.cs
git add TaskFlow.Console/TaskManager.cs
git commit -m "fix(manager): handle missing task gracefully in search method"

# Validar aprovação dos testes
dotnet test
```

---

### 5. Refatoração e Melhorias

#### Tarefa G: Menu interativo em Program.cs
```powershell
# Atualização em TaskFlow.Console/Program.cs
git add TaskFlow.Console/Program.cs
git commit -m "refactor(console): implement interactive menu loop in Program.cs"
```

#### Tarefa H: Documentação no README.md
```powershell
# Atualização de README.md
git add README.md
git commit -m "docs(readme): add build, run and test instructions"
```

---

### 6. Sincronização com o GitHub
```powershell
git push origin main
```

---

### 7. Comandos Úteis do Dia a Dia

- **Compilar:** `dotnet build`
- **Rodar Console:** `dotnet run --project TaskFlow.Console`
- **Rodar Testes:** `dotnet test`
- **Ver Grafo Git:** `git log --oneline --graph`
