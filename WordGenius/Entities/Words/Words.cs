using System.ComponentModel.DataAnnotations;

namespace WordGenius.Entities.Words;

public sealed class Words : Auditable
{
    [MaxLength(50)]
    public string Word { get; set; } = string.Empty;


    [MaxLength(50)]
    public string Translate { get; set; } = string.Empty;


    public string Discription { get; set; } = string.Empty;


    public int[] Sounds { get; set; }


    public bool Is_Remember { get; set; } = false;

}
