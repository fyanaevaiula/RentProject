using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using MvcRentApp.Models;
using System.Security.Cryptography;

namespace MvcRentApp.Data

{
    public class RentContext : DbContext
    {
        public RentContext(DbContextOptions<RentContext> options) : base(options)
        { }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
