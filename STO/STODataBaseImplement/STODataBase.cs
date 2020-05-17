using Microsoft.EntityFrameworkCore;
using STODataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace STODataBaseImplement
{
    public class STODataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-iguana\SQLEXPRESS;
                Initial Catalog=STODataBase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Part> Part { set; get; }
        public virtual DbSet<Work> Work { set; get; }
        public virtual DbSet<WorkParts> WorkParts { set; get; }
    }
}
