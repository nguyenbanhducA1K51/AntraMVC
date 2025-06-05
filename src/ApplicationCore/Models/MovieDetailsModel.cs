namespace ApplicationCore.Models;

public class MovieDetailsModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string PosterURL { get; set; }
    public string? Overview { get; set; } 
    public string? TagLine { get; set; }
    public decimal Budget { get; set; }
    public decimal? Price { get; set; }
    public decimal Revenue { get; set; }
    public ICollection<TrailerModel> Trailers { get; set; }
    public ICollection<CastModel> Casts { get; set; }
}