﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeScanner.Models;

namespace ResumeScanner.Data
{
    public class ResumeScannerDBContext : IdentityDbContext<User>
    {
        public ResumeScannerDBContext(DbContextOptions<ResumeScannerDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfile { get; set; }

        public DbSet<Skills> Skills { get; set; }

    }
}
