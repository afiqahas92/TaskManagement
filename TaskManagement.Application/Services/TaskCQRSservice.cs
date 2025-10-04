using TaskManagement.Application.Features.Tasks.Commands;
using TaskManagement.Application.Features.Tasks.Queries;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Services;

public class TaskCQRSservice : ITaskCQRSservice
{
    private readonly ITaskRepository _taskRepository;

    public TaskCQRSservice(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(CancellationToken cancellationToken = default)
    {
        var query = new GetAllTasksQuery();
        var handler = new GetAllTasksQueryHandler(_taskRepository);
        return await handler.Handle(query, cancellationToken);
    }

    public async Task<IEnumerable<TaskItem>> GetTasksByStatusAsync(bool isCompleted, CancellationToken cancellationToken = default)
    {
        var query = new GetTasksByStatusQuery { IsCompleted = isCompleted };
        var handler = new GetTasksByStatusQueryHandler(_taskRepository);
        return await handler.Handle(query, cancellationToken);
    }

    public async Task<TaskItem> CreateTaskAsync(CreateTaskCommand command, CancellationToken cancellationToken = default)
    {
        var handler = new CreateTaskCommandHandler(_taskRepository);
        return await handler.Handle(command, cancellationToken);
    }

    public async Task<TaskItem?> ToggleTaskStatusAsync(ToggleTaskStatusCommand command, CancellationToken cancellationToken = default)
    {
        var handler = new ToggleTaskStatusCommandHandler(_taskRepository);
        return await handler.Handle(command, cancellationToken);
    }

    public async Task DeleteTaskAsync(DeleteTaskCommand command, CancellationToken cancellationToken = default)
    {
        var handler = new DeleteTaskCommandHandler(_taskRepository);
        await handler.Handle(command, cancellationToken);
    }
}