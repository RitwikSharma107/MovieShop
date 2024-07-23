using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Model.Response;

public class MovieResponseModel
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? BackdropUrl { get; set; }
    public decimal? Budget { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? ImdbUrl { get; set; }
    [Column(TypeName = "nvarchar(64)")]
    public string? OriginalLanguage { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string? Overview { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? PosterUrl { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public decimal? Revenue { get; set; }
    public int? RunTime { get; set; }
    [Column(TypeName = "nvarchar(512)")]
    public string? Tagline { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string? Title { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? TmdbUrl { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    
    // Property added to get casts from CastResponseModel
    public ICollection<CastResponseModel>? Casts { get; set; }
    
    // Property added to get genres from GenreResponseModel
    public ICollection<GenreResponseModel>? Genres { get; set; }
}