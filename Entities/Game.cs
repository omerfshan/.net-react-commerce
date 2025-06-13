
using Core.Entities;

namespace Entities;



public class Game : BaseEntity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ThumbnailUrl { get; set; }
    public DateTime ReleaseDate { get; set; }

    public Guid CategoryId {get; set;}
    public virtual Category? Category { get; set; }

    public Game(){}
    public Game(Guid _Id,Guid _CategoryId,string _name,string _Description,string _ThumbnailUrl,DateTime _ReleaseDate)
    {
        Id = _Id;
       CategoryId=_CategoryId;
       Name=_name;
       Description=_Description;
       ThumbnailUrl=_ThumbnailUrl;
       ReleaseDate=_ReleaseDate;
    }


}
