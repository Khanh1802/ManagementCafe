namespace ManagerCafe.Commons
{
    public class PaginationDto
    {
        public int MaxResultCount { get; set; } = 10;

        public int SkipCount { get; set; } = 0;
    }
}
