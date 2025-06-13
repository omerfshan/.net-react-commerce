
namespace Core.Repositories;
// Bu arayüz, veri tabanına sorgu yazmak için gerekli yapıyı tanımlar
public interface IQuery<T>
{
    // Tüm verileri LINQ ile sorgulamak için bir Query metodu sunar
    IQueryable<T> Query();
}