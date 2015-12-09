namespace Forum.Migrations
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Forum.DataContexts.ForumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Forum.DataContexts.ForumDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            ApplicationUserManager userManager = new ApplicationUserManager(userStore);
            ApplicationUser user1 = new ApplicationUser() { Email = "user1@email.com", UserName = "User 1", EmailConfirmed = true };
            ApplicationUser user2 = new ApplicationUser() { Email = "user2@email.com", UserName = "User 2" , EmailConfirmed = true };
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole("Admin"));
            if (userManager.FindByEmail("user1@email.com") == null)
            {
                userManager.Create(user1, "UserPassword12!");
            }

            if (userManager.FindByEmail("user2@email.com") == null)
            {
                userManager.Create(user2, "UserPassword12!");
            }


            Categories cat1 = new Categories() { Name = "Category 1", Threads = new List<Thread>() };
            Categories cat2 = new Categories() { Name = "Category 2", Threads = new List<Thread>() };

            Forums f = new Forums() { Category = cat1 };

            Thread t1 = new Thread() { Category = cat1, User = user1, Date = DateTime.Now.AddDays(-20), Posts = new List<Post>(), Title = "Testing Thread 1" };
            Thread t2 = new Thread() { Category = cat2, User = user1, Date = DateTime.Now.AddDays(-10), Posts = new List<Post>(), Title = "Testing Thread 2" };
            Thread t3 = new Thread() { Category = cat1, User = user2, Date = DateTime.Now.AddDays(-5), Posts = new List<Post>(), Title = "Testing Thread 3" };
            cat1.Threads.Add(t1);
            cat1.Threads.Add(t3);
            cat2.Threads.Add(t2);

            Post p1 = new Post() { Thread = t1, Date = t1.Date.AddHours(0), User = user1, Body = "filler text filler text filler text filler text filler text filler text filler text filler text filler text" };
            Post p2 = new Post() { Thread = t2, Date = t2.Date.AddHours(0), User = user2, Body = "filler text filler text filler text filler text filler text filler text filler text filler text filler text" };
            Post p3 = new Post() { Thread = t3, Date = t3.Date.AddHours(0), User = user1, Body = "filler text filler text filler text filler text filler text filler text filler text filler text filler text" };
            Post p4 = new Post() { Thread = t1, Date = t1.Date.AddHours(1), User = user2, Body = "filler text filler text filler text filler text filler text filler text filler text filler text filler text" };
            Post p5 = new Post() { Thread = t2, Date = t2.Date.AddHours(1), User = user1, Body = "filler text filler text filler text filler text filler text filler text filler text filler text filler text" };

            context.Categories.AddOrUpdate( cat => cat.Name, cat1, cat2);
            context.Threads.AddOrUpdate(thr => thr.Title, t1, t2, t3);
            //context.Forums.Add(f);
            //context.Posts.AddRange(new List<Post> { p1, p2, p3, p4, p5 });
        }
    }
}
