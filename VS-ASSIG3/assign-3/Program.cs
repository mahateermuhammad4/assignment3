using System;
using System.Xml;

class Program
{
    static void Main()
    {
        CreateXmlFile();
        ReadXmlFile("GPS.xml");
    }

    static void CreateXmlFile()
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t"
        };

        using (XmlWriter writer = XmlWriter.Create("GPS.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("GPS_Log");

            writer.WriteStartElement("Position");
            writer.WriteAttributeString("DateTime", "1/26/2017 5:08:59 PM");
            writer.WriteElementString("x", "65.8973342");
            writer.WriteElementString("y", "72.3452346");

            writer.WriteStartElement("SatteliteInfo");
            writer.WriteElementString("Speed", "40");
            writer.WriteElementString("NoSatt", "7");
            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.WriteStartElement("Image");
            writer.WriteAttributeString("Resolution", "1024x800");
            writer.WriteElementString("Path", @"\images\1.jpg");
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        Console.WriteLine("XML file created successfully.");
    }

    static void ReadXmlFile(string filePath)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);

        Console.WriteLine("Contents of the XML file:");
        string xmlContent = xmlDoc.OuterXml;

        foreach (string line in xmlContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
        {
            Console.WriteLine(line);
        }
    }
}