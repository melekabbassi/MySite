using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySiteBL.Entities;

namespace MySiteDAL
{
    internal class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        
        public void Seed()
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    BlogId = 1,
                    url = "http://blogs.packtpub.com/dotnet"
                },
                new Blog
                {
                    BlogId = 2,
                    url = "http://blogs.packtpub.com/dotnetcore"
                }
            );

            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    BlogId = 1,
                    Title = "Dotnet 4.7 Released",
                    Content = "Dotnet 4.7 Released Contents",
                    PublishedDateTime = DateTime.Now
                },
                new Post
                {
                    PostId = 2,
                    BlogId = 1,
                    Title = "Dotnet 4.8 Released",
                    Content = "Dotnet 4.8 Released Contents",
                    PublishedDateTime = DateTime.Now
                },
                new Post
                {
                    PostId = 3,
                    BlogId = 2,
                    Title = "testTitle",
                    Content = "testContent",
                    PublishedDateTime = DateTime.Now
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    CommentId = 1,
                    PostId = 1,
                    Title = "Dotnet 4.7 Released",
                    Content = "Dotnet 4.7 Released Contents",
                    Author = "Packt"
                },
                new Comment
                {
                    CommentId = 2,
                    PostId = 1,
                    Title = "Dotnet 4.8 Released",
                    Content = "Dotnet 4.8 Released Contents",
                    Author = "Packt"
                },
                new Comment
                {
                    CommentId = 3,
                    PostId = 2,
                    Title = "Dotnet 4.7 Released",
                    Content = "Dotnet 4.7 Released Contents",
                    Author = "Packt"
                }
            );
        }
    }
}
