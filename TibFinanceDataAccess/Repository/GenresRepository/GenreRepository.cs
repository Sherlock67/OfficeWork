using System;
using System.Collections.Generic;
using TibFinanceDataAccess.Interface;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess.Repository.GenresRepository
{
    public class GenreRepository : IGenre
    {
        private ApplicationDbContext db;
        public GenreRepository()
        {
           // db = new ApplicationDbContext();
        }
        public Genre Create(Genre entity)
        {

            db = new ApplicationDbContext();
            //var obj = db.B.Add(entity);
            //db.SaveChanges();
            //return obj;
            throw new NotImplementedException();
        }

        public void Delete(Genre entity)
        {
            db = new ApplicationDbContext();
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAll()
        {
            db = new ApplicationDbContext();
            throw new NotImplementedException();
        }

        public Genre GetById(int? Id)
        {
            db = new ApplicationDbContext();
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Genre entity)
        {
            db = new ApplicationDbContext();
            throw new NotImplementedException();
        }
    }
}
