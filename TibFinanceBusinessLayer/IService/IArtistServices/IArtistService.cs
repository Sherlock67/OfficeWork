using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibFinanceDataAccess.Models;

namespace TibFinanceBusinessLayer.IService.IArtistServices
{
    public interface IArtistService
    {
        Artist CreateArtist(Artist artist);
        void UpdateArtist(Artist artist);
        IEnumerable<Artist> GetAllArtist();
        Artist GetModuleById(int artistId);
        Artist DeleteArtist(Artist artist);

        IEnumerable<Artist> GetArtistByName(string name);
    }
}
