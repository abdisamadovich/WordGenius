namespace EduCenter.Desktop.Utils;

public class PagenationParams
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public PagenationParams(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public PagenationParams()
    {
    }
}
