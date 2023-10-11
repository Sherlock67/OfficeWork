using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TibFinanceDataAccess.Models
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public string ArtistName { get; set;}
        public ICollection<Album> Albums { get; set; }
    }
}
