using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Commands;

public class ToggleTaskStatusCommand
{
    public int TaskId { get; set; }
}

public class ToggleTaskStatusCommandHandler
{
    private readonly ITaskRepository _taskRepository;

    public ToggleTaskStatusCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskItem?> Handle(ToggleTaskStatusCommand command, CancellationToken cancellationToken = default)
    {
        var task = await _taskRepository.GetByIdAsync(command.TaskId, cancellationToken);
        if (task != null)
        {
            task.IsCompleted = !task.IsCompleted;
            await _taskRepository.UpdateAsync(task, cancellationToken);
        }
        return task;
    }
}
