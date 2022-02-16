namespace SimpleWebAPI.Dto
{
    public class VideoGameModelDto
    {
        public string Name { get; set; }
        public string DevelopmentStudio { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}
