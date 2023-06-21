namespace WordGenius.Entities.Sentences;

public class Sentence: BaseEntity
{
    public long WordsId { get; set; }

    public string SentenceText { get; set; } = string.Empty;
}
