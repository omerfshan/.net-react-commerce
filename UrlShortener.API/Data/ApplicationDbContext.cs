using Microsoft.EntityFrameworkCore;
using UrlShortener.API.Models;

namespace UrlShortener.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }
} 