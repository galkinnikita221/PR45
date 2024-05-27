using API_Galkin.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Galkin.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UsersContext() {
            Database.EnsureCreated();
            Users.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;database=TaskManager", new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}
