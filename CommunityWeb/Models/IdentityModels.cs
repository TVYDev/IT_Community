using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using CommunityWeb.Models;

namespace CommunityWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // add custom column here, MUST BE THE SAME AS CUSTOM COLUMN IN MODEL      
        public string ImgUrl { get; set; }

        public ICollection<UserTopicDetail> UserTopicDetails { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<Chat> Chats { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here      OAuth management thing !!
     
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<QuestionTopicDetail> QuestionTopicDetails { get; set; }
        public DbSet<UserTopicDetail> UserTopicDetails { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Chat> Chats { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
                Questions |-----< QuestionTopicDetails >-----| Topics

                     1 : M        QuestionTopicDetails        M : 1
            */
            modelBuilder.Entity<QuestionTopicDetail>()
                .HasRequired(qt => qt.Question)
                .WithMany(q => q.QuestionTopicDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionTopicDetail>()
                .HasRequired(qt => qt.Topic)
                .WithMany(t => t.QuestionTopicDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTopicDetail>()
                .HasRequired(ut => ut.User)
                .WithMany(u => u.UserTopicDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserTopicDetail>()
                .HasRequired(ut => ut.Topic)
                .WithMany(t => t.UserTopicDetails)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vote>()
                .HasRequired(v => v.Answer)
                .WithMany(a => a.Votes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vote>()
                .HasRequired(v => v.User)
                .WithMany(u => u.Votes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserNotification>()
                .HasRequired(un => un.User)
                .WithMany(u => u.UserNotifications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserNotification>()
                .HasRequired(un => un.Notification)
                .WithMany(n => n.UserNotifications)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Answer>()
                .HasRequired(a => a.User)
                .WithMany(u => u.Answers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Answer>()
                .HasRequired(a => a.Question)
                .WithMany(q => q.Answers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.Question)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.Answer)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chat>()
                .HasRequired(c => c.User)
                .WithMany(u => u.Chats)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}