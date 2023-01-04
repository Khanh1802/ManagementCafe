namespace ManagerCafe.Commons
{
    public class PaginationDto
    {
        public int MaxResultCount { get; set; } 
        public int SkipCount { get; set; } 
        public int CurrentPage { get; set; }
    }
}
