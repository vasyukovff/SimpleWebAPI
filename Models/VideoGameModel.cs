using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebAPI.Models
{
    [Table("video_games", Schema = "games")]
    public class VideoGameModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("development_studio")]
        public string DevelopmentStudio { get; set; }

        [Column("genres", TypeName = "jsonb")]
        public IEnumerable<string> Genres { get; set; }
    }
}
