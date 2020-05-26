using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPIProject.Models
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext():base("Prod")
        {

        }
        public virtual DbSet<Product> Products { get; set; }
    }
}