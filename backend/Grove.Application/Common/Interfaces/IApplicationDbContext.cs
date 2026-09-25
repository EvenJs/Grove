
using Grove.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grove.Application.Common.Interfaces;

public interface IApplicationDbContext
{
  DbSet<Note> Notes { get; }
  DbSet<Tag> Tags { get; }
  DbSet<User> Users { get; }
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}