using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Role
{
    public int Id { get; set; }
    [MaxLength(2084)]
    public string BackdropUrl { get; set; }
    public decimal Budget{get;set;}
    public DateTime CreatedDate{get;set;}
    [MaxLength(2084)]
    public string imdbUrl { get; set; }
    [MaxLength(64)]
    public string OriginalLanguage { get; set; }

    public string Overview { get; set; }
    public string PosterURL { get; set; }
    public decimal Price{get;set;}
    public DateTime? ReleaseDate{get;set;}
    public decimal Revenue {get;set;}
    public int RunTime {get;set;}
    [MaxLength(512)]
    public string Tagline { get; set; }
    [MaxLength(256)]
    public string Title { get; set; }
    [MaxLength(2084)]
    public string TmdbUrl { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedDate{get;set;}
    
    public ICollection<UserRole> UserRoles{get;set;}
}