using AppointmentScheduling.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Data
{
    public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser> // como herda do identity db context em vez do db context
                                                                 // ele ira criar na primeira migration as tabelas responsaveis pela manipulaçao de autenticaçao
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
