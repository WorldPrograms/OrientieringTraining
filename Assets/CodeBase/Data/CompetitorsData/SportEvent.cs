using System;
using System.Collections.Generic;

namespace CodeBase.Data
{
    public class SportEvent
    {
        public SportEvent(string eventName = null)
        {
            DateTimeCreate = DateTime.Now;
            if (eventName != null)
                EventName = eventName;
            else
                EventName = DateTimeCreate.ToString();
        }

        public string EventName { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeStart { get; set; }
        public List<Group> CompetitorsAgeGroups { get; set; }

        public void AdNewCompetitorsAgeGroup(string ageGroup)
        {
            Group competitorsAgeGroupOnEvent = new Group(ageGroup);
            CompetitorsAgeGroups.Add(competitorsAgeGroupOnEvent);
        }
    }
}