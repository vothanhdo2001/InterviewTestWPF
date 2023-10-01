using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace INTERVIEW_TEST
{
    public class XNode : TreeNode
    {
        public XNode() 
        {

        }
        public XNode(string text, string id)
        {
            this.Text = text;
            this.Name = id;
        }

        public XNode ConvertXmlNodeToXNode(XmlNode xmlNode)
        {
            if (xmlNode == null)
                return null;

            var xNode = new XNode(xmlNode.Attributes["text"]?.Value, xmlNode.Attributes["id"]?.Value);

            foreach (XmlNode childXmlNode in xmlNode.ChildNodes)
            {
                var childXNode = ConvertXmlNodeToXNode(childXmlNode);
                if (childXNode != null)
                {
                    xNode.Nodes.Add(childXNode);
                }
            }

            return xNode;
        }


        public XNode LoadXmlFileToXNode(string filePath)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                var rootNode = xmlDoc.DocumentElement;

                if (rootNode != null)
                {
                    return ConvertXmlNodeToXNode(rootNode);
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi ở đây nếu cần
                Console.WriteLine("Lỗi khi đọc tệp XML: " + ex.Message);
            }

            return null;
        }
    }

}
