using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using book_store.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace book_store.Data
{
    public class book_storeContext : DbContext
    {
        public book_storeContext (DbContextOptions<book_storeContext> options)
            : base(options)
        {
        }

        public DbSet<book_store.Models.book> book { get; set; } = default!;

        public DbSet<book_store.Models.usersaccounts>? usersaccounts { get; set; }

        public DbSet<book_store.Models.orders>? orders { get; set; }
        public DbSet<book_store.Models.report>? report { get; set; }
    }
}
