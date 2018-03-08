using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ITCompanyLocator.BusinessLogicLayer;
using ITCompanyLocatorUI.Models;

namespace ITCompanyLocatorUI.Controllers
{
    public class SearchLocationController : Controller
    {
        // GET: SearchLocation
        public ActionResult GetCompanies()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetLocation(String location)
        {
            //call busines logic method
            CompanyManager c2 = new CompanyManager();
            var companyEntities = c2.GetCompaniesDetails(location);
            //convert to companyDetailModel list 
            var selectedCompanies = new List<CompanyDetailModel>();
            for (int index = 0; index < companyEntities.Names.Count; index++)
            {
                var company = new CompanyDetailModel
                {
                    Name = companyEntities.Names[index],
                    Address = companyEntities.Addresses[index]
                };
                selectedCompanies.Add(company);
            }

            return View(selectedCompanies);
        }
    }
}