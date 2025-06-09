
using Core.Entities;

namespace Entities;



public class Game : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ThumbnailUrl { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Guid CategoryId {get; set;}
    public virtual Category? category;

    public Game(){}
    public Game(Guid id,Guid CategoryId,string _name,string Description,string ThumbnailUrl,DateTime _ReleaseDate)
    {
        id
    }


}
