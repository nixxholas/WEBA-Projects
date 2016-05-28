using Microsoft.AspNet.Builder;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace WEBA_EF_CaseStudy1.Models
{
    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder app)
        {
            var db = app.ApplicationServices.GetService<ApplicationDbContext>();
            try {
                db.Database.Migrate();


                Company companyA, companyB = null;
                Company companyC, companyD = null;
                Company companyE, companyF = null;
                Company companyG, companyH = null;
                Company companyI, companyJ = null;

                //Begin of if block which checkes whethere there are any company records
                //in the Companies entity which represents the Company table in the database
                if (db.Companies.Any() == false)
                {
                    companyA = new Company()
                    {
                        CompanyName = "COMPANY A",
                        Address = "COMPANY A ADDRESS",
                        PostalCode = "888881"
                    };
                    db.Companies.Add(companyA);
                    companyB = new Company()
                    {
                        CompanyName = "COMPANY B",
                        Address = "COMPANY B ADDRESS",
                        PostalCode = "888882"
                    };
                    db.Companies.Add(companyB);
                    companyC = new Company()
                    {
                        CompanyName = "COMPANY C",
                        Address = "COMPANY C ADDRESS",
                        PostalCode = "888883"
                    };
                    db.Companies.Add(companyC);
                    companyD = new Company()
                    {
                        CompanyName = "COMPANY D",
                        Address = "COMPANY D ADDRESS",
                        PostalCode = "888884"
                    };
                    db.Companies.Add(companyD);
                    companyE = new Company()
                    {
                        CompanyName = "COMPANY E",
                        Address = "COMPANY E ADDRESS",
                        PostalCode = "888885"
                    };
                    db.Companies.Add(companyE);
                    companyF = new Company()
                    {
                        CompanyName = "COMPANY F",
                        Address = "COMPANY F ADDRESS",
                        PostalCode = "888886"
                    };
                    db.Companies.Add(companyF);
                    companyG = new Company()
                    {
                        CompanyName = "COMPANY G",
                        Address = "COMPANY G ADDRESS",
                        PostalCode = "888887"
                    };
                    db.Companies.Add(companyG);
                    companyH = new Company()
                    {
                        CompanyName = "COMPANY H",
                        Address = "COMPANY H ADDRESS",
                        PostalCode = "888888"
                    };
                    db.Companies.Add(companyH);
                    companyI = new Company()
                    {
                        CompanyName = "COMPANY I",
                        Address = "COMPANY I ADDRESS",
                        PostalCode = "888889"
                    };
                    db.Companies.Add(companyI);
                    companyJ = new Company()
                    {
                        CompanyName = "COMPANY J",
                        Address = "COMPANY J ADDRESS",
                        PostalCode = "888810"
                    };
                    db.Companies.Add(companyJ);
                }

                db.SaveChanges();
            }
            catch
            {
                return;
            }
            return;
        }
    }
}
