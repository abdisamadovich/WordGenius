using EduCenter.Desktop.Helpers;
using System;
using System.CodeDom;

namespace WordGenius.Entities;

public abstract class Auditable: BaseEntity
{
    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }

    public Auditable()
    {
        CreateAt = TimeHelper.GetDateTime();
        UpdateAt = TimeHelper.GetDateTime();
    }
}

