using System.Collections.Generic;
using System.Xml;
using ITCompanyLocator.DataAccessLayer;

namespace ITCompanyLocator.BusinessLogicLayer
{
    public class CompanyManager
    {
        /// <summary>
        /// Validating User Input and passing location to get api response
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public CompanyInformation GetCompaniesDetails(string location)
        {
            //Verifying Location (empty,null)
            //Data acess method call
            CallAPIEntity callApiObject = new CallAPIEntity();
            string response = callApiObject.GetResponseFromGoogleApi(location);
            return XmlParse(response);
        }


        /// <summary>
		/// method for XMLParsing
		/// </summary>
		/// <param name="responseString"></param>
		private CompanyInformation XmlParse(string responseString)
        {
            XmlDocument responseDocument = new XmlDocument();

            responseDocument.LoadXml(responseString);

            XmlNodeList nameList = responseDocument.GetElementsByTagName("name");
            XmlNodeList addressList = responseDocument.GetElementsByTagName("formatted_address");
            var companyInformation = new CompanyInformation
            {
                Names = new List<string>(),
                Addresses = new List<string>()
            };

            foreach (XmlNode CompName in nameList)
            {
                companyInformation.Names.Add(CompName.InnerText);
            }

            foreach (XmlNode CompAddress in addressList)
            {
                companyInformation.Addresses.Add(CompAddress.InnerText);
            }
            return companyInformation;
        }

    }
}
