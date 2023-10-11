using System.ComponentModel.DataAnnotations;

namespace TibFinanceDataAccess.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumTitle { get; set; }  
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
