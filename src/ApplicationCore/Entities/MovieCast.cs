using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class MovieCasts
{
 public int MovieId { get; set; }
 public int CastId { get; set; }
 [MaxLength(450)]
 public string Character { get; set; }
 //navigation property
 public Movie Movie { get; set; }
 public Cast Cast { get; set; }
}