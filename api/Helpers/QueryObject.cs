namespace JobApplicationSystem.api.Helpers
{
    public class QueryObject
    {
        public string? JobType { get; set; } = null;
        public string? WorkMode { get; set; } = null;
        public string? Industry { get; set; } = null;
        public string? ExperienceLevel { get; set; } = null;
        public string? JobStatus { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
