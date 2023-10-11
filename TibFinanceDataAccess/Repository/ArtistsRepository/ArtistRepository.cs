using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TibFinanceDataAccess.Interface.Artists;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository.ArtistsRepository
{
    public class ArtistRepository : IArtist
    {
        private ApplicationDbContext db;
        public ArtistRepository()
        {
            
        }
        public Artist Create(Artist entity)
        {
            db = new ApplicationDbContext();
            var obj = db.Artists.Add(entity);
            db.SaveChanges();
            return obj;
          
        }

        public void Delete(int id)
        {
            db = new ApplicationDbContext();
            var entity = db.Artists.Where(x=>x.ArtistId == id).FirstOrDefault();
            if(entity != null)
            {
                db.Artists.Remove(entity);
                db.SaveChanges();
            }
          
        }

        public IEnumerable<Artist> GetAll()
        {
            try
            {
                this.db = new ApplicationDbContext();
                return db.Artists.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
          //  db = new ApplicationDbContext();
            
        }

        public Artist GetById(int? Id)
        {
          
            this.db = new ApplicationDbContext();
            return db.Artists.Where(x => x.ArtistId == Id).SingleOrDefault();
            //throw new NotImplementedException();
        }

        public IEnumerable<Artist> SearchByName(string name)
        {
            this.db = new ApplicationDbContext();
            return (from artist in db.Artists where artist.ArtistName == name select artist).ToList();

            //throw new NotImplementedException();
        }

        public void Update(Artist entity)
        {
            db = new ApplicationDbContext();
            db.Artists.AddOrUpdate(entity);
            db.SaveChanges();
        }
    }
}
