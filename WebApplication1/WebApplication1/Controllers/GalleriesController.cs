using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/galleries")]
public class GalleriesController : ControllerBase
{
    private readonly ArtDbContext _context;

    public GalleriesController(ArtDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}/exhibitions")]
    public IActionResult GetExhibitions(int id)
    {
        /*var gallery = _context.Galleries
            .Include(g => g.Exhibitions)
            .ThenInclude(e => e.ExhibitionArtworks)
            .ThenInclude(ea => ea.Artwork)
            .ThenInclude(a => a.Artist)
            .FirstOrDefault(g => g.GalleryId == id);

        if (gallery == null)
            return NotFound();

        var result = new
        {
            galleryId = gallery.GalleryId,
            name = gallery.Name,
            establishedDate = gallery.EstablishedDate.ToString("yyyy-MM-dd"),
            exhibitions = gallery.Exhibitions.Select(e => new
            {
                title = e.Title,
                startDate = e.StartDate.ToString("yyyy-MM-dd"),
                endDate = e.EndDate.ToString("yyyy-MM-dd"),
                numberOfArtworks = e.ExhibitionArtworks.Count,
                artworks = e.ExhibitionArtworks.Select(ea => new
                {
                    title = ea.Artwork.Title,
                    yearCreated = ea.Artwork.YearCreated,
                    insuranceValue = ea.InsuranceValue,
                    artist = new
                    {
                        firstName = ea.Artwork.Artist.FirstName,
                        lastName = ea.Artwork.Artist.LastName,
                        birthDate = ea.Artwork.Artist.BirthDate.ToString("yyyy-MM-dd")
                    }
                })
            })
        };

        return Ok(result);*/
        return Ok();
    }
}