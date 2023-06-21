using System.ComponentModel.DataAnnotations;

namespace WordGenius.Entities.Words;

public sealed class Word : Auditable
{
    [MaxLength(50)]
    public string Text { get; set; } = string.Empty;


    [MaxLength(50)]
    public string Translate { get; set; } = string.Empty;


    public string Discription { get; set; } = string.Empty;


    public byte[] Sounds { get; set; }


    public bool Is_Remember { get; set; } = false;

}
