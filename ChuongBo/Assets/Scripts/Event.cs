using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Event : IEventAction
{
    private string eventID;
    private string eventName;
    private Conversation firstConversation;
    private EventType eventType;
    private EventState eventState;

    public string EventID
    {
        get
        {
            return eventID;
        }

        set
        {
            eventID = value;
        }
    }

    public string EventName
    {
        get
        {
            return eventName;
        }

        set
        {
            eventName = value;
        }
    }

    public Conversation FirstConversation
    {
        get
        {
            return firstConversation;
        }

        set
        {
            firstConversation = value;
        }
    }

    public EventType EventType
    {
        get
        {
            return eventType;
        }

        set
        {
            eventType = value;
        }
    }

    public EventState EventState
    {
        get
        {
            return eventState;
        }

        set
        {
            eventState = value;
        }
    }

    public Event()
    {
        EventID = "";
        EventName = "";
        FirstConversation = null;
        eventType = EventType.Once;
        eventState = EventState.Progressing;
    }

    public Event(string eventID, string eventName, Conversation firstConversation, EventType eventType, EventState eventState)
    {
        this.EventID = eventID;
        this.EventName = eventName;
        this.FirstConversation = firstConversation;
        this.EventType = eventType;
        this.EventState = eventState;
    }
    public Event(string eventID, EventState eventState)
    {
        this.EventID = eventID;
        this.EventState = eventState;
    }

    public bool require()
    {
        throw new NotImplementedException();
    }

    public List<Item> reward()
    {
        throw new NotImplementedException();
    }

    public List<Event> getNextEvent()
    {
        throw new NotImplementedException();
    }
}