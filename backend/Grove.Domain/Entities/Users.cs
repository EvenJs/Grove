using Grove.Domain.Common;

namespace Grove.Domain.Entities;

public class User : BaseEntity
{
  public string Email { get; private set; } = string.Empty;
  public string PasswordHash { get; private set; } = string.Empty;
  public string FirstName { get; private set; } = string.Empty;
  public string LastName { get; private set; } = string.Empty;
  public int FailedLoginAttempts { get; private set; } = 0;

  public DateTime? LockedUntil { get; private set; } = null;

  private User() { }

  public User(string passwordHash, string firstName, string lastName, string email)
  {
    this.PasswordHash = passwordHash;
    FirstName = firstName;
    LastName = lastName;
    Email = NormalizeEmail(email);
  }

  public string DisplayName => $"{FirstName} {LastName}".Trim();

  private static string NormalizeEmail(string email)
  {
    if (string.IsNullOrWhiteSpace(email))
      throw new ArgumentException("Email could not be empty or whitespace");

    var normalized = email.Trim().ToLowerInvariant();

    if (!normalized.Contains('@'))
      throw new ArgumentException("Email format is invalid");

    return normalized;
  }
}