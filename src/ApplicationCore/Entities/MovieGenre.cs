namespace ApplicationCore.Entities;

public class MovieGenre
{
    public int GenreId { get; set; }
    public int MovieId { get; set; }
    
    //Navigation Property
    
    public Genre Genre { get; set; }
    public Movie Movie { get; set; }
}