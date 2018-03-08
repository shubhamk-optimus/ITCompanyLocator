using System.Collections.Generic;

namespace ITCompanyLocator.BusinessLogicLayer
{
    /// <summary>
    /// Class to store company's parsed information
    /// </summary>
    public class CompanyInformation
    {
        public List<string> Names { get; set; }
        public List<string> Addresses { get; set; }
    }
}
