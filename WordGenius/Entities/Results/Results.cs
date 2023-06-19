using System;

namespace WordGenius.Entities.Results;

internal class Results: BaseEntity
{
    public long WordsId { get; set; }


    public DateTime Step1 { get; set; }


    public DateTime Step2 { get; set; }


    public DateTime Step3 { get; set; }

}
