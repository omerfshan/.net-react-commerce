
using Core.Entities;

namespace Entities;



public class Game : BaseEntity<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ThumbnailUrl { get; set; }
    public DateTime ReleaseDate { get; set; }
}
