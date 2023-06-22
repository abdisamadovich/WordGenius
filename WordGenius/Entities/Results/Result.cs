using System;

namespace WordGenius.Entities.Results;

public class Result: BaseEntity
{
    public long WordsId { get; set; }


    public DateTime Step1 { get; set; }


    public DateTime Step2 { get; set; }


    public DateTime Step3 { get; set; }

}
