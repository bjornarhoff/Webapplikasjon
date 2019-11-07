using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VyKService.Models
{
    public static class DbSeed
    {
        public static void DbInit(IServiceScope serviceScope)
        {

            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DB>();
            dbContext.Database.EnsureCreated();
            if (!dbContext.QA.Any())
            {
                var faq = new QA[]
                {
                    new QA
                    {
                        Question = "Hvordan kjøper jeg billett?",
                        Answer = "Kontakt Sven"
                    },
                    new QA
                    {
                        Question = "Hvordan kjøper jeg billett?",
                        Answer = "Kontakt Cato"
                    },
                    new QA
                    {
                        Question = "Hvordan kjøper jeg billett?",
                        Answer = "Kontakt meg"
                    }
                };
                foreach (var a in faq)
                {
                    dbContext.QA.Add(a);
                    dbContext.SaveChanges();
                }
            }
        }
    }

}


