using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Tasks.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TaskItem>> GetByStatusAsync(bool isCompleted, CancellationToken cancellationToken = default)
    {
        return await _context.Tasks
            .Where(t => t.IsCompleted == isCompleted)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<TaskItem> AddAsync(TaskItem task, CancellationToken cancellationToken = default)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);
        return task;
    }

    public async Task UpdateAsync(TaskItem task, CancellationToken cancellationToken = default)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var task = await GetByIdAsync(id, cancellationToken);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}