using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Cast
{
public int Id { get; set; }
public string Gender { get; set; }
[MaxLength(128)]
public string Name { get; set; }
[MaxLength(2084)]
public string ProfilePath { get; set; }
public string TmdbUrl { get; set; }

public ICollection<MovieCast> MovieCasts { get; set; }
}