using System;
using System.Linq;

namespace MoneyGame.Logic
{
    public class Game
    {
        public const int MaxRatesInHistory = 31;
        private readonly Random random = new Random();

        public Game(Player player, DateTime startDate)
        {
            Player = player;
            State.Date = startDate;
            State.GoldHistory.Add(new Rate(1000, startDate));
        }

        public Player Player { get; }

        public GameState State { get; } = new GameState();

        public void Next()
        {
            State.Date = State.Date.AddDays(1);
            State.GoldHistory.Insert(0, GetGoldRate(State.Date));

            while (State.GoldHistory.Count > MaxRatesInHistory)
            {
                State.GoldHistory.RemoveAt(MaxRatesInHistory);
            }
        }

        private Rate GetGoldRate(DateTime today)
        {
            var currentPrice = State.GoldHistory.FirstOrDefault()?.Value ?? 0;
            return new Rate(currentPrice + currentPrice * (decimal)GetGoldChange(today), today);
        }

        private double GetGoldChange(DateTime today)
        {
            if (IsNewMineFound())
            {
                State.Events.Add(new Event(today, "Новый рудник был открыт! Обвал!"));
                return random.NextDouble() * -0.15;
            }

            return random.NextDouble() * 0.05 - 0.02;
        }

        private bool IsNewMineFound() => IsCase(0.15);

        private bool IsCase(double probability)
            => random.NextDouble() <= probability;
    }
}
