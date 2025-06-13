using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
namespace Core.Repositories;


// Bu arayüz, veri işlemleri (CRUD) için temel metodları tanımlar
public interface IRepository<TEntity, TEntityId> : IQuery<TEntity>

where TEntity : BaseEntity<TEntityId>// Bu interface sadece BaseEntity'den türeyen sınıflarda geçerli olur
{
    // Yeni veri eklemek için kullanılır
    TEntity Add(TEntity TEntity);
    // Veriyi güncellemek için kullanılır
    TEntity Update(TEntity TEntity);
    // Veriyi silmek (ya da silinmiş gibi göstermek) için kullanılır
    TEntity Delete(TEntity TEntity);
    // Tüm verileri getirmek için kullanılır. Filtre ve ilişkili veriler dahil edilebilir.
    List<TEntity> GetAll(
        Expression<Func<TEntity,bool>>? predicate = null, // filtre
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null // ilişkili tablolar
    );

    // Tek bir veri getirmek için kullanılır
    TEntity Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
    );

}
