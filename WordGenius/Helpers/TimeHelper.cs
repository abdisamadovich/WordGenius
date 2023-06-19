using EduCenter.Desktop.Constants;
using System;

namespace EduCenter.Desktop.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstants.UTC);
        return dtTime;
    } 
}
