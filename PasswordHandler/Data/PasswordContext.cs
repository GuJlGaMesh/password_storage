using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PasswordHandler.Models;

namespace PasswordHandler.Data
{
    public class PasswordContext : DbContext
    {
        public PasswordContext(DbContextOptions<PasswordContext> options) : base(options)
        {
        }
        public DbSet<Resource> Records { get; set; }
    }
}
