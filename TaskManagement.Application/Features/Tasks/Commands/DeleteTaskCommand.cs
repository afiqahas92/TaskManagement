using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Commands;

public class DeleteTaskCommand
{
    public int TaskId { get; set; }
}

public class DeleteTaskCommandHandler
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task Handle(DeleteTaskCommand command, CancellationToken cancellationToken = default)
    {
        await _taskRepository.DeleteAsync(command.TaskId, cancellationToken);
    }
}
