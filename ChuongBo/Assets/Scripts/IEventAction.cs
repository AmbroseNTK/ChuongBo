using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


interface IEventAction
{
    /// <summary>
    /// Check all conditional so that apply this Event
    /// </summary>
    /// <returns></returns>
    bool require();
    /// <summary>
    /// Give players some gift if they pass this event
    /// </summary>
    /// <returns></returns>
    List<Item> reward();
    /// <summary>
    /// Give next events
    /// </summary>
    /// <returns></returns>
    List<Event> getNextEvent();
}
