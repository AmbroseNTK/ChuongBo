using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

using UnityEngine;


public class Setting
{
    private Setting()
    {
        fullDirectory = Application.persistentDataPath + fileName;
    }
    private static Setting instance;
    public static Setting GetInstance()
    {
        if (instance == null)
            instance = new Setting();
        return instance;
    }

    private string fileName = "\\setting";
    private string fullDirectory;
    private FileStream fileSetting;
    private XmlWriter writer;

    public bool enableSound = true;
    public string language = "vi";

    public void SaveSetting()
    {
        if (File.Exists(fullDirectory))
        {
            File.Delete(fullDirectory);
        }
        fileSetting = File.Open(fullDirectory, FileMode.OpenOrCreate);

        writer = XmlWriter.Create(fileSetting);
        if (writer.WriteState == WriteState.Closed)
            writer = XmlWriter.Create(fileSetting);
        writer.Settings.Indent = true;
        writer.WriteStartDocument();
        writer.WriteStartElement("Setting");
        writer.WriteElementString("Sound", enableSound.ToString());
        writer.WriteElementString("Language", language);
        writer.WriteEndDocument();
        writer.Flush();
        writer.Close();
    }
    public void LoadSetting()
    {
        Close();
        if (File.Exists(fullDirectory))
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(File.ReadAllText(fullDirectory));
            enableSound = Boolean.Parse(document.GetElementsByTagName("Sound")[0].InnerText);
            language = document.GetElementsByTagName("Language")[0].InnerText;
        }
    }
  
    public void Close()
    {
        try
        {
            writer.Close();
            fileSetting.Close();
        }
        catch { }
    }
}