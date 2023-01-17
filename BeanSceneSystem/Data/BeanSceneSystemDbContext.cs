using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BeanSceneSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneSystem.Data
{
    public class BeanSceneSystemDbContext: IdentityDbContext<ApplicationUser>
    {
        public BeanSceneSystemDbContext(DbContextOptions<BeanSceneSystemDbContext> options):base(options)
        {
            
        }

        /// <summary>
        /// This function defines the Database table MemberGuest with the MemberGuest model class.
        /// </summary>
        public DbSet<BeanSceneSystem.Models.MemberGuest> MemberGuest { get; set; } = default!;
        /// <summary>
        /// This function defines the Database table Reservation with the Reservation model class.
        /// </summary>
        public DbSet<BeanSceneSystem.Models.Reservation> Reservation { get; set; } = default!;
        /// <summary>
        /// This function defines the Database table Event with the Event model class.
        /// </summary>
        public DbSet<BeanSceneSystem.Models.Event> Event { get; set; } = default!;
    }
}

