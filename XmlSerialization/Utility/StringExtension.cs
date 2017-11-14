using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Xml;
using System.Xml.Linq;

namespace XmlSerialization.Utility
{
    static class StringExtension
    {


        public static JObject ToJson(this string content)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(content))
                {
                    return new JObject();
                }
                // a json-formatted string
                else if (content.Trim().StartsWith("{"))
                {
                    return JObject.Parse(content);
                }
                // a single value is returned
                else
                {
                    return new JObject(new JProperty("response", content));
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException(content, ex);
            }
        }

        public static JObject XmlAJson(this string xml, bool document = false)
        {
            JObject data = null;

            if (document)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                data = JsonConvert.SerializeXmlNode(doc).ToJson();

            }
            else
            {
                XDocument doc = XDocument.Load(xml);

                data = JsonConvert.SerializeXmlNode(doc.ToXmlDocument()).ToJson();
            }
            return data;
        }


        #region Convertir de XmlDocument - XDocument y Viceversa

        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        } 
        #endregion
    }
}
