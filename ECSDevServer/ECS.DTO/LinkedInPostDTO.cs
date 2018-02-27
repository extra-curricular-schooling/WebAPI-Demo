namespace ECS.DTO
{
    /// <summary>
    /// Information regarding a submitted LinkedIn post.
    /// </summary>
    public class LinkedInPostDTO
    {
        public string comment { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string submittedurl { get; set; }
        public string code { get; set; }
    }
}
