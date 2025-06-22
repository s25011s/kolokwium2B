using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class ExhibitionArtwork
{
    public int ExhibitionId { get; set; }
    [ForeignKey("ExhibitionId")]
    public Exception Exhibition { get; set; }
    public int ArtworkId { get; set; }
    [ForeignKey("ArtworkId")]
    public Artwork Artwork { get; set; }
    public decimal InsuranceValue { get; set; }
}