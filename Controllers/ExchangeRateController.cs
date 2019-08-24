using System;
using System.ServiceModel;
using System.Web.Mvc;
using System.Xml;

namespace InventoryNatific.Controllers
{
    public class ExchangeRateController : Controller
    {
        // GET: ExchangeRate
        public ActionResult Index()
        {
            return View();
        }

        public string GetEuroRate()
        {
            try
            {
                MnbApi.MNBArfolyamServiceSoapClient sm = new MnbApi.MNBArfolyamServiceSoapClient();
                var body = new MnbApi.GetCurrentExchangeRatesRequestBody();
                var current = sm.GetCurrentExchangeRates(body);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(current.GetCurrentExchangeRatesResult);
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    for (int i = 0; i < node.ChildNodes.Count; i++)
                    {
                        if (node.ChildNodes[i].Attributes[1].InnerText == "EUR")
                        {
                            return node.ChildNodes[i].InnerText;
                        }
                    }
                }

                return "";
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}