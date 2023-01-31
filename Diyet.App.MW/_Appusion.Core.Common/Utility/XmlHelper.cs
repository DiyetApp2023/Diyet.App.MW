using Appusion.Core.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Appusion.Core.Common.Utility
{
    /// <summary>
    /// XmlHelper
    /// </summary>
    internal class XmlHelper
    {
        /// <summary>
        /// GetParsedXmlContent
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public static string GetParsedXmlContent(string xmlContent)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlContent);
            var xmlResult = xmlDocument.SelectNodes("//faultstring").Count > 0 ?
               xmlDocument.SelectNodes("//faultstring")[0].InnerText :
               "Base XML Response Error";
            return xmlResult;
        }
    }
}