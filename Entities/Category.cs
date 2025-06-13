namespace Entities;
using Core.Entities;

public class Category:BaseEntity<Guid>
{
   public string? Name { get; set; }
   public ICollection<Game>? Game{get; set;}

public Category(){}
public Category(Guid _Id,string _name){
   Name=_name;
   Id=_Id;
}
}