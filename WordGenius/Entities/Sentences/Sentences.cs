namespace WordGenius.Entities.Sentences;

internal class Sentences: BaseEntity
{
    public long WordsId { get; set; }

    public string Sentence { get; set; } = string.Empty;
}
