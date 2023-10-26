using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BlogApp.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Blog>().HasData(

                new Blog
                {
                    Id = 1,
                    Title = "Berkay ilk blog",
                    ImageUrl = "https://avatars.githubusercontent.com/u/137995940?v=4",
                    Description = "İlk bloguma hoş geldiniz",
                    SeoUrl = "ilk-blog-baslıyoruz",
                    ShortDescription = "İlk blog ve site amaçlarından bahsedilecektir. "
                },
                new Blog
                {
                    Id = 2,
                    Title = "Yavuz Selim Kahraman ile yazılım dünyasına hoşgeldiniz ",
                    ImageUrl = "https://avatars.githubusercontent.com/u/44233634?v=4",
                    Description = "merhaba ben Yavuz selim kahraman.",
                    SeoUrl = "ysk-first-blog",
                    ShortDescription = "yazılım dünyasına hepiniz hoşgeldiniz. "
                });


            modelBuilder.Entity<Comment>().HasData(

         new Comment
         {
             Id = 1,
              BlogId = 1,
               Content = "İlk yorum master yorum ",
               WriterName = "Berkay Akar",
               
         },
           new Comment
           {
               Id = 2,
               BlogId = 1,
               Content = "ikinci yorum master yorum ",
               WriterName = "Ahmet akar",

           },

           new Comment
           {
               Id = 3,
               BlogId = 1,
               ParentId = 1,
               Content = "ikinci yorum master yorum ",
               WriterName = "Ahmet akar",

           }

         );






            //modelBuilder.Entity<Comment>(comment =>
            //{
            //    comment.HasKey(c => c.Id);
            //    comment.HasIndex(c => c.ParentId);

            //    comment.HasOne(c => c.Parent)
            //           .WithMany(c => c.Child)
            //           .HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.Cascade);


            //});
        }


        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
