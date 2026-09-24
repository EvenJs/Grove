using Grove.Domain.Enums;
using Grove.Domain.Common;

namespace Grove.Domain.Entities;

public class Note : BaseEntity
{
  public Guid Uuid { get; private set; }
  public string Slug { get; private set; } = string.Empty;
  public string Title { get; private set; } = string.Empty;
  public string ContentMd { get; private set; } = string.Empty;
  public string? ContentHtml { get; private set; }
  public NoteStatus Status { get; private set; }
  public NoteVisibility Visibility { get; private set; }
  public DateTime? PublishedAt { get; private set; }
  public string? Excerpt { get; private set; }
  public string? CoverImageUrl { get; private set; }
  public ICollection<Tag> Tags { get; private set; } = new List<Tag>();


  public bool isPubliclyVisible => Status == NoteStatus.Published && Visibility == NoteVisibility.Public;

  private Note() { }

  public Note(string slug, string title, string contentMd)
  {
    Uuid = Guid.NewGuid();
    Slug = slug;
    Title = title;
    ContentMd = contentMd;
    Status = NoteStatus.Draft;
    Visibility = NoteVisibility.Private;
  }

}