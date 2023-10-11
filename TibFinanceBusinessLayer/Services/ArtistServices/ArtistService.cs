using System;
using System.Collections.Generic;
using System.Linq;
using TibFinanceDataAccess.Interface.Artists;
using TibFinanceDataAccess.Models;
using TibFinanceDataAccess.Repository.ArtistsRepository;
using TibFinanceDataAccess.Repository.RolesRepository;

namespace TibFinanceBusinessLayer.Services.ArtistServices
{
    public class ArtistService
    {
         private IArtist artistRepository;
         public ArtistService() 
         {
            artistRepository = new ArtistRepository();
         }
        public Artist CreateArtist(Artist artist)
        {
            return artistRepository.Create(artist);
            //throw new NotImplementedException();
        }
        public bool DeleteArtist(int id)
        {
            try
            {
              //  var module = artistRepository.GetById(id);
                artistRepository.Delete(id);
                return true;
            }

            catch (Exception ex)
            {
                return false;
                throw ex;

            }
            //throw new NotImplementedException();
        }
        public IEnumerable<Artist> GetAllArtistInfo()
        {
            try
            {
                return artistRepository.GetAll().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<Artist> GetAllArtistByName(string name)
        {
            try
            {
                return artistRepository.SearchByName(name).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Artist GetArtistById(int? artistId)
        {
            return artistRepository.GetById(artistId);
           
        }
        public void UpdateArtist(Artist artist)
        {
            try
            {
                artistRepository.Update(artist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }

    }
}
