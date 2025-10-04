using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Commands;

public class CreateTaskCommand
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class CreateTaskCommandHandler
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskItem> Handle(CreateTaskCommand command, CancellationToken cancellationToken = default)
    {
        var task = new TaskItem
        {
            Title = command.Title,
            Description = command.Description,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        return await _taskRepository.AddAsync(task, cancellationToken);
    }
}
