using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Artist
{
    [Key]
    public int ArtistId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
}