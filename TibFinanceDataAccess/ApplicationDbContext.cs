﻿using System.Data.Entity;
using TibFinanceDataAccess.Models;

namespace TibFinanceDataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
                
        }
        public DbSet<Course> Course { get; set; }   
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserLogin> Logins { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role>Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist>Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<UserPermission> MenuPermissions { get; set; }
    }
}