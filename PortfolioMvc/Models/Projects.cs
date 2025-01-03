using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PortfolioMvc.Models;

public class Projects
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.ImageUrl)]
    public string? Image { get; set; }
    [Display(Name = "Release Date")]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Code { get; set; }
    [DataType(DataType.Text)]
    public string? Context { get; set; }
}
