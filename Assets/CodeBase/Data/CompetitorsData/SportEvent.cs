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
        public List<CompetitorsAgeGroupOnEvent> CompetitorsAgeGroups { get; set; }

        public void AdNewCompetitorsAgeGroup(string ageGroupType, string customGroupName = null)
        {
            CompetitorsAgeGroupOnEvent competitorsAgeGroupOnEvent = new CompetitorsAgeGroupOnEvent(ageGroupType,customGroupName);
            CompetitorsAgeGroups.Add(competitorsAgeGroupOnEvent);
        }
    }
}