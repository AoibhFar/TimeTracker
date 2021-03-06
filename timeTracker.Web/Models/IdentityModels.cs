﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using timeTracker.Domain;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace timeTracker.Web.Models
{
    
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public virtual string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required]
        public virtual string Department { get; set; }
        [Required]
        public virtual string Role { get; set; }
        [Required]
        public virtual string Manager { get; set; }
        public virtual float  Hourlyrate { get; set; }
        public virtual int Holidays { get; set; }
        public virtual int HolidaysTaken { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }
}