// TaskFlow - Gerenciador de Tarefas via Console
// Aluno: Fernando almeida de oliveira braga - RA: 326132695

var manager = new TaskManager();
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("==================================================");
    Console.WriteLine("           TaskFlow - Gerenciador de Tarefas       ");
    Console.WriteLine("   Aluno: Fernando almeida de oliveira braga      ");
    Console.WriteLine("   RA: 326132695                                  ");
    Console.WriteLine("==================================================");
    Console.WriteLine("1. Adicionar Tarefa");
    Console.WriteLine("2. Listar Tarefas");
    Console.WriteLine("3. Concluir Tarefa");
    Console.WriteLine("4. Sair");
    Console.WriteLine("--------------------------------------------------");
    Console.Write("Escolha uma opção: ");

    var option = Console.ReadLine()?.Trim();

    switch (option)
    {
        case "1":
            AddTaskView(manager);
            break;
        case "2":
            ListTasksView(manager);
            break;
        case "3":
            CompleteTaskView(manager);
            break;
        case "4":
            running = false;
            Console.WriteLine("\nEncerrando TaskFlow. Até logo!");
            break;
        default:
            Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
    }
}

static void AddTaskView(TaskManager manager)
{
    Console.Clear();
    Console.WriteLine("--- Adicionar Nova Tarefa ---");
    Console.Write("Título da tarefa: ");
    var title = Console.ReadLine();

    try
    {
        var task = manager.AddTask(title ?? string.Empty);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n[Sucesso] Tarefa adicionada com sucesso!");
        Console.ResetColor();
        Console.WriteLine($"ID: {task.Id} | Título: {task.Title}");
    }
    catch (ArgumentException ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n[Erro] {ex.Message}");
        Console.ResetColor();
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}

static void ListTasksView(TaskManager manager)
{
    Console.Clear();
    Console.WriteLine("--- Lista de Tarefas ---");

    if (!manager.Tasks.Any())
    {
        Console.WriteLine("Nenhuma tarefa cadastrada no momento.");
    }
    else
    {
        foreach (var task in manager.Tasks)
        {
            var status = task.IsCompleted ? "[X] Concluída" : "[ ] Pendente ";
            var color = task.IsCompleted ? ConsoleColor.Green : ConsoleColor.Yellow;

            Console.ForegroundColor = color;
            Console.Write($"{status} ");
            Console.ResetColor();
            Console.WriteLine($"- {task.Title} (ID: {task.Id})");
        }
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}

static void CompleteTaskView(TaskManager manager)
{
    Console.Clear();
    Console.WriteLine("--- Concluir Tarefa ---");

    if (!manager.Tasks.Any())
    {
        Console.WriteLine("Nenhuma tarefa disponível para conclusão.");
    }
    else
    {
        Console.WriteLine("Tarefas cadastradas:");
        var tasksList = manager.Tasks.ToList();
        for (int i = 0; i < tasksList.Count; i++)
        {
            var t = tasksList[i];
            var status = t.IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"[{i + 1}] {status} {t.Title} (ID: {t.Id})");
        }

        Console.Write("\nDigite o número da tarefa ou o ID (Guid) para concluir: ");
        var input = Console.ReadLine()?.Trim();

        Guid targetId = Guid.Empty;
        if (int.TryParse(input, out int index) && index >= 1 && index <= tasksList.Count)
        {
            targetId = tasksList[index - 1].Id;
        }
        else if (Guid.TryParse(input, out Guid parsedId))
        {
            targetId = parsedId;
        }

        if (targetId != Guid.Empty && manager.CompleteTask(targetId))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[Sucesso] Tarefa marcada como concluída!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[Aviso] Tarefa não encontrada ou ID inválido.");
            Console.ResetColor();
        }
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
}
