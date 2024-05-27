﻿using System;
using API_Galkin.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Galkin.Context
{
    public class TaskContext : DbContext
    {
        public DBSet<Tasks> Tasks { get; set; }

        public TaskContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1;" +
                "uid=root;" +
                "pwd=;" +
                "database=TaskManager",
                new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
