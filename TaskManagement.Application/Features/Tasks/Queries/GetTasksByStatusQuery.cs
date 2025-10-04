using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Queries;

public class GetTasksByStatusQuery
{
    public bool IsCompleted { get; set; }
}

public class GetTasksByStatusQueryHandler
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksByStatusQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskItem>> Handle(GetTasksByStatusQuery query, CancellationToken cancellationToken = default)
    {
        return await _taskRepository.GetByStatusAsync(query.IsCompleted, cancellationToken);
    }
}
