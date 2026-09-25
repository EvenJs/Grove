namespace Grove.Domain.Common;

public abstract class BaseEntity
{
  public long Id { get; protected set; }
  public DateTime CreatedAt { get; protected set; }
  public DateTime UpdatedAt { get; protected set; }

  public void SetCreatedAt(DateTime value) => CreatedAt = value;
  public void SetUpdatedAt(DateTime value) => UpdatedAt = value;
}