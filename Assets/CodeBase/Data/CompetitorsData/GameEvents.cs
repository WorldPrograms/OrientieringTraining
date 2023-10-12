using System.Collections.Generic;

namespace CodeBase.Data
{
    public class GameEvents
    {
        public List<SportEvent> Events { get; set; } = new List<SportEvent>();

        public void AddNewEvent(string eventName = null)
        {
            SportEvent newSportEvent = new SportEvent(eventName);
            Events.Add(newSportEvent);
        }
    }
}