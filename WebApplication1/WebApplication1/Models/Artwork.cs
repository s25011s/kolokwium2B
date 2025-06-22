using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Artwork
{
    [Key]
    public int ArtworkId { get; set; }
    public int ArtistId { get; set; }
    [ForeignKey("ArtistId")]
    public Artist Artist { get; set; }
    [MaxLength(100)]
    public string Title { get; set; }
    public int YearCreated { get; set; }
}