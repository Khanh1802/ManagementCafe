namespace ManagerCafe.Commons
{
    public class CommonPageDto<T> : PaginationDto where T : class
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public int TakeCount { get; set; }
        public bool HasReversePage { get; set; }
        public bool HasNextPage { get; set; }
        public List<T> Data { get; set; }
        public int TotalPage { get; set; }
        public CommonPageDto()
        {

        }
        public CommonPageDto(int total, PaginationDto pagination, List<T> data)
        {
            Total = total;
            MaxResultCount = pagination.MaxResultCount;
            SkipCount = pagination.SkipCount;
            if (SkipCount > 0)
            {
                CurrentPage = (int)Math.Ceiling((double)(total / SkipCount)) + 1;
            }
            else
            {
                CurrentPage = 1;
            }
            TotalPage = (int)Math.Ceiling((double)Total / MaxResultCount);
            HasReversePage = CurrentPage > 1;
            HasNextPage = CurrentPage < TotalPage;
            Data = data;
        }
    }
}
