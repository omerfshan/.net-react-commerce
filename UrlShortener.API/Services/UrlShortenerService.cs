using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.API.Data;
using UrlShortener.API.Models;

namespace UrlShortener.API.Services
{
    public class UrlShortenerService
    {
        private readonly ApplicationDbContext _context;
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int ShortCodeLength = 6;

        public UrlShortenerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ShortenedUrl> ShortenUrl(string originalUrl)
        {
            var shortCode = GenerateShortCode();
            var shortenedUrl = new ShortenedUrl
            {
                OriginalUrl = originalUrl,
                ShortCode = shortCode,
                ShortUrl = $"http://localhost:5000/{shortCode}",
                CreatedAt = DateTime.UtcNow,
                Clicks = 0
            };

            _context.ShortenedUrls.Add(shortenedUrl);
            await _context.SaveChangesAsync();

            return shortenedUrl;
        }

        public async Task<ShortenedUrl> GetOriginalUrl(string shortCode)
        {
            var shortenedUrl = await _context.ShortenedUrls
                .FirstOrDefaultAsync(u => u.ShortCode == shortCode);

            if (shortenedUrl != null)
            {
                shortenedUrl.Clicks++;
                await _context.SaveChangesAsync();
            }

            return shortenedUrl;
        }

        private string GenerateShortCode()
        {
            var random = new Random();
            var shortCode = new char[ShortCodeLength];

            for (int i = 0; i < ShortCodeLength; i++)
            {
                shortCode[i] = Alphabet[random.Next(Alphabet.Length)];
            }

            return new string(shortCode);
        }
    }
} 