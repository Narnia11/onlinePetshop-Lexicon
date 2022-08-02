using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Model.Model;
using Model;

namespace assignment.Models
{
    public class ExDBContext : IdentityDbContext<ApplicationUser>
    {
        public ExDBContext(DbContextOptions<ExDBContext> options)
       : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Media> Medias { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*project*/
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Item>().ToTable("Items");

            // Configure relationships  
            modelBuilder.Entity<Item>()
                .HasOne<Category>(i => i.Category)
                .WithMany(c=>c.Items)
                .HasForeignKey(i => i.Item_Category_id).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Items_Categorys");




            //one to many Relationship
            modelBuilder.Entity<Media>()
                        .HasOne<Category>(m => m.Category)
                        .WithMany(c => c.Medias)
                        .HasForeignKey(m => m.Media_Category_id);

            modelBuilder.Entity<Media>()
            .HasOne<Item>(m => m.Item)
            .WithMany(h => h.Medias)
            .HasForeignKey(m => m.Media_Item_id);

            modelBuilder.Entity<Media>()
            .HasOne<ApplicationUser>(m => m.ApplicationUser)
            .WithMany(a => a.Medias)
            .HasForeignKey(m => m.Media_User_id);


            /*End project*/

        }

    }

}
