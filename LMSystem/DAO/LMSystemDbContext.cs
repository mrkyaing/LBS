using LMSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace LMSystem.DAO
{
    public class LMSystemDbContext:IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public LMSystemDbContext(DbContextOptions<LMSystemDbContext>options):base(options) { }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }
        public DbSet<MemberEntity> Members { get; set; }
        public DbSet<LibrarianEntity> Librarians { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<IssueBookEntity>IssueBooks { get; set; }    
    }
}
