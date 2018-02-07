using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

using UnityEngine;

public class GameData
{
    private GameData()
    {
        fullDirectory = Application.persistentDataPath + fileName;
    }
    private static GameData instance;
    public static GameData GetInstance()
    {
        if (instance == null)
            instance = new GameData();
        return instance;
    }
    private string fullDirectory;
    private string fileName = "\\GameData";

    public bool CheckData()
    {
        return File.Exists(fullDirectory);
    }

    private List<Event> listEvent;
    private List<Item> listItem;

    public void AddEvent(Event e)
    {
        listEvent.Add(e);
    }
    public List<Event> GetEvent(string eventID)
    {
        try
        {
            return listEvent.Where(@event => @event.EventID == eventID).ToList();
        }
        catch
        {
            return new List<Event>();
        }
    }
    public void AddItem(Item item)
    {
        try
        {
            List<Item> similarItems = listItem.Where(it => it.ItemID == item.ItemID).ToList();
            if (similarItems == null || similarItems.Count == 0)
            {
                listItem.Add(item);
            }
            else
            {
                similarItems[0].Quantity += item.Quantity;
            }
        }
        catch { }
    }
    public Item GetItem(string itemID)
    {
        return listItem.Single(item => item.ItemID == itemID);
    }
    public bool UseItem(string itemID, int quantity)
    {
        try
        {
            Item used = listItem.Single(item => item.ItemID == itemID);
            if (used != null)
            {
                if (quantity > used.Quantity)
                    return false;
                used.Quantity -= quantity;
            }
            if (used.Quantity == 0)
            {
                listItem.Remove(used);
            }
            return true;
        }
        catch
        {
            return false;
        }
       
    }

    public void SaveData()
    {
        if (File.Exists(fullDirectory))
        {
            File.Delete(fullDirectory);
        }
        XmlWriter writer = XmlWriter.Create(fullDirectory);

        writer.WriteStartDocument();

        writer.WriteStartElement("Items");
        foreach(Item item in listItem)
        {
            writer.WriteStartElement("Item");
            writer.WriteAttributeString("id", item.ItemID);
            writer.WriteAttributeString("quantity", item.Quantity.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();

        writer.WriteStartElement("Events");
        foreach (Event @event in listEvent)
        {
            writer.WriteStartElement("Event");
            writer.WriteAttributeString("id", @event.EventID);
            writer.WriteAttributeString("state", @event.EventState.ToString());
            writer.WriteEndElement();
        }
        writer.WriteEndElement();

        writer.WriteEndDocument();

        writer.Flush();
        writer.Close();
    }

    public void LoadData()
    {
        XmlDocument document = new XmlDocument();
        document.LoadXml(File.ReadAllText(fullDirectory));

        XmlNodeList xmlListItems = document.GetElementsByTagName("Item");
        XmlNodeList xmlListEvents = document.GetElementsByTagName("Event");

        listItem = new List<Item>();
        listEvent = new List<Event>();

        foreach (XmlNode nodeItem in xmlListItems)
        {
            listItem.Add(new Item(nodeItem.Attributes["id"].Value, int.Parse(nodeItem.Attributes["quantity"].Value)));
        }

        foreach (XmlNode nodeEvent in xmlListEvents)
        {
            listEvent.Add(new Event(nodeEvent.Attributes["id"].Value, (EventState)Enum.Parse(typeof(EventState), nodeEvent.Attributes["state"].Value)));
        }

        
    }

}