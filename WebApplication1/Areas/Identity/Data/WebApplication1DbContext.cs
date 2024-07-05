using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExpenseTracker_NguyenKimTien_21K4080052.Areas.Identity.Data;

namespace ExpenseTracker_NguyenKimTien_21K4080052.Data;

public class WebApplication1DbContext : IdentityDbContext<WebApplication1User>
{
    public WebApplication1DbContext(DbContextOptions<WebApplication1DbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
