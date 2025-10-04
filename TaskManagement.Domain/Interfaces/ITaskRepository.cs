using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Domain.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<TaskItem>> GetByStatusAsync(bool isCompleted, CancellationToken cancellationToken = default);
    Task<TaskItem> AddAsync(TaskItem task, CancellationToken cancellationToken = default);
    Task UpdateAsync(TaskItem task, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}