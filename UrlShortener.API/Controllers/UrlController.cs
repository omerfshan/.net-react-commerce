using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.API.Services;

namespace UrlShortener.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly UrlShortenerService _urlShortenerService;

        public UrlController(UrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpPost]
        public async Task<IActionResult> ShortenUrl([FromBody] UrlRequest request)
        {
            if (string.IsNullOrEmpty(request.Url))
            {
                return BadRequest("URL is required");
            }

            var shortenedUrl = await _urlShortenerService.ShortenUrl(request.Url);
            return Ok(shortenedUrl);
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortCode)
        {
            var shortenedUrl = await _urlShortenerService.GetOriginalUrl(shortCode);
            
            if (shortenedUrl == null)
            {
                return NotFound();
            }

            return Redirect(shortenedUrl.OriginalUrl);
        }
    }

    public class UrlRequest
    {
        public required string Url { get; set; }
    }
} 