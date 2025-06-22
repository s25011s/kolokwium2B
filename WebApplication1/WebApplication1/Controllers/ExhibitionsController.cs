using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AddExhibitionDto
{
    public string Title { get; set; }
    public string Gallery { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<AddArtworkDto> Artworks { get; set; }
}
public class AddArtworkDto
{
    public int ArtworkId { get; set; }
    public decimal InsuranceValue { get; set; }
}

[ApiController]
[Route("api/exhibitions")]
public class ExhibitionsController : ControllerBase
{
    private readonly ArtDbContext _context;

    public ExhibitionsController(ArtDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddExhibition([FromBody] AddExhibitionDto dto)
    {
        var gallery = _context.Galleries.FirstOrDefault(g => g.Name == dto.Gallery);
        if (gallery == null)
            return BadRequest("Gallery does not exist.");

        foreach (var art in dto.Artworks)
        {
            if (!_context.Artworks.Any(a => a.ArtworkId == art.ArtworkId))
                return BadRequest($"Artwork with ID {art.ArtworkId} does not exist.");
        }

        var exhibition = new Exhibition
        {
            Title = dto.Title,
            GalleryId = gallery.GalleryId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            ExhibitionArtworks = dto.Artworks.Select(a => new ExhibitionArtwork
            {
                ArtworkId = a.ArtworkId,
                InsuranceValue = a.InsuranceValue
            }).ToList()
        };

        _context.Exhibitions.Add(exhibition);
        _context.SaveChanges();

        return CreatedAtAction(nameof(AddExhibition), new { id = exhibition.ExhibitionId }, null);
    }
}
