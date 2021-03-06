﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Data
{
    public class Bookstorecontext:IdentityDbContext
    {
        public Bookstorecontext(DbContextOptions<Bookstorecontext> options):base(options)
        {

        }
        public DbSet<Books> book { get; set; }
        public DbSet<Language> Language { get; set; }

        public DbSet<Bookgallery> Bookgallery { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=Bookstore;Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
