using System;

namespace UrlShortener.API.Models
{
    public class ShortenedUrl
    {
        public int Id { get; set; }
        public required string OriginalUrl { get; set; }
        public required string ShortCode { get; set; }
        public required string ShortUrl { get; set; }
        public int Clicks { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 