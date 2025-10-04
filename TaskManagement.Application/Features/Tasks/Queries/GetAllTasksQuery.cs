using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;

namespace TaskManagement.Application.Features.Tasks.Queries;

public class GetAllTasksQuery
{
    
}

public class GetAllTasksQueryHandler
{
    private readonly ITaskRepository _taskRepository;

    public GetAllTasksQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery query, CancellationToken cancellationToken = default)
    {
        return await _taskRepository.GetAllAsync(cancellationToken);
    }
}
