using Grove.Domain.Common;
using Grove.Domain.Enums;

namespace Grove.Domain.Entities;

public class Tag : BaseEntity
{
  public string Name { get; private set; } = string.Empty;
  public string Slug { get; private set; } = string.Empty;

  public ICollection<Note> Notes { get; private set; } = new List<Note>();

  private Tag() { }

  public Tag(string name, string slug)
  {
    Name = name;
    Slug = slug;
  }
}