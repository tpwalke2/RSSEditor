using System;
using System.Collections.Generic;
using System.Xml;

namespace Avanteware.RSSEdit {
  public class RSSFileSaveLoad : IRSSFileSaveLoad {

    public void Save(IRSSFile rssFile, string filename) {
      XmlDocument doc = new XmlDocument();
      // contains elements that don't need to be stored long term
      XmlNode tempElem;

      doc.AppendChild(doc.CreateProcessingInstruction("xml", "version=\"1.0\""));
      XmlElement rssElem = doc.CreateElement("rss");
      rssElem.SetAttribute("version", "2.0");
      
      XmlElement chanElem = doc.CreateElement("channel");

      // feed properties
      tempElem = doc.CreateElement("title");
      tempElem.InnerText = rssFile.Title;
      chanElem.AppendChild(tempElem);

      tempElem = doc.CreateElement("description");
      tempElem.InnerText = rssFile.Description;
      chanElem.AppendChild(tempElem);

      tempElem = doc.CreateElement("link");
      tempElem.InnerText = rssFile.Link;
      chanElem.AppendChild(tempElem);

      tempElem = doc.CreateElement("generator");
      tempElem.InnerText = "Avanteware RSSEdit";
      chanElem.AppendChild(tempElem);

      tempElem = doc.CreateElement("language");
      tempElem.InnerText = "en-us";
      chanElem.AppendChild(tempElem);

      tempElem = doc.CreateElement("lastBuildDate");
      DateTime dt = DateTime.UtcNow;
      tempElem.InnerText = dt.ToString("ddd, dd MMM yyyy HH:mm:ss") + " GMT";
      chanElem.AppendChild(tempElem);

      // feed items
      foreach (RSSItem item in rssFile.Items) {
        chanElem.AppendChild(RSSItemToXML(doc, item));
      }

      rssElem.AppendChild(chanElem);
      doc.AppendChild(rssElem);

      doc.Save(filename);
    }

    private XmlElement RSSItemToXML(XmlDocument doc, RSSItem item) {
      XmlElement itemElem = doc.CreateElement("item");

      XmlElement tempElem = doc.CreateElement("title");
      tempElem.InnerText = item.Title;
      itemElem.AppendChild(tempElem);

      tempElem = doc.CreateElement("description");
      tempElem.InnerText = item.Description;
      itemElem.AppendChild(tempElem);

      tempElem = doc.CreateElement("link");
      tempElem.InnerText = item.Link;
      itemElem.AppendChild(tempElem);

      return itemElem;
    }

    public RSSFile Load(string filename) {
      XmlDocument doc = new XmlDocument();

      // temporary storage
      XmlNodeList tempList;

      RSSFile result = new RSSFile();
      doc = new XmlDocument();
      doc.Load(filename);
      
      tempList = doc.GetElementsByTagName("rss");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      XmlElement rssElem = (XmlElement)tempList.Item(0);

      tempList = rssElem.GetElementsByTagName("channel");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      XmlElement chanElem = (XmlElement)tempList.Item(0);

      tempList = chanElem.GetElementsByTagName("title");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      result.Title = tempList.Item(0).InnerText;

      tempList = chanElem.GetElementsByTagName("description");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      result.Description = tempList.Item(0).InnerText;

      tempList = chanElem.GetElementsByTagName("link");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      result.Link = tempList.Item(0).InnerText;

      tempList = chanElem.GetElementsByTagName("item");
      foreach (XmlNode itemElem in tempList) {
        result.Items.Add(RSSItemFromXML((XmlElement)itemElem));
      }

      return result;
    }

    private RSSItem RSSItemFromXML(XmlElement itemElem) {
      RSSItem result = new RSSItem();

      XmlNodeList tempList = itemElem.GetElementsByTagName("title");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      result.Title = tempList.Item(0).InnerText;

      tempList = itemElem.GetElementsByTagName("description");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      result.Description = tempList.Item(0).InnerText;

      tempList = itemElem.GetElementsByTagName("link");
      if (tempList.Count == 0) { throw new XmlException("Invalid format"); }
      result.Link = tempList.Item(0).InnerText;

      return result;
    }
  }
}
