using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Features.Tasks.Commands;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Services;

public interface ITaskCQRSservice
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TaskItem>> GetTasksByStatusAsync(bool isCompleted, CancellationToken cancellationToken = default);
    Task<TaskItem> CreateTaskAsync(CreateTaskCommand command, CancellationToken cancellationToken = default);
    Task<TaskItem?> ToggleTaskStatusAsync(ToggleTaskStatusCommand command, CancellationToken cancellationToken = default);
    Task DeleteTaskAsync(DeleteTaskCommand command, CancellationToken cancellationToken = default);
}
