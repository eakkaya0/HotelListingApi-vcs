namespace HotelListing.Api.Data;

using System;
using Microsoft.EntityFrameworkCore;

public class HotelListingDbContext:DbContext
{
    public HotelListingDbContext(DbContextOptions options):base(options)
    {

    }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Hotel> Hotels { get; set; }


}
