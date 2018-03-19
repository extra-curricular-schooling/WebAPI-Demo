namespace ECS.DTO
{
    /// <summary>
    /// Information regarding a submitted LinkedIn post.
    /// </summary>
    public class LinkedInPostDTO
    {
        public string AccessToken { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubmittedUrl { get; set; }
        public string Code { get; set; }
    }
}
