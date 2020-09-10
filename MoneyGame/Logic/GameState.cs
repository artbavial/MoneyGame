using System;
using System.Collections.Generic;

namespace MoneyGame.Logic
{
    public class GameState
    {
        public DateTime Date { get; set; }

        public IList<Event> Events { get; } = new List<Event>();

        public IList<Rate> GoldHistory { get; } = new List<Rate>();
    }

    public class Event
    {
        public Event(DateTime date, string message)
        {
            Date = date;
            Message = message;
        }

        public DateTime Date { get; }

        public string Message { get; }
    }
}
