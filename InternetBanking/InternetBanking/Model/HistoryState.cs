using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternetBanking.Model
{
    public class HistoryState
    {
        private int id;
        private DateTime date;
        private int userId;
        private decimal differenceAmount;
        private string currency;

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int UserId { get => userId; set => userId = value; }
        public decimal DifferenceAmount { get => differenceAmount; set => differenceAmount = value; }
        public string Currency { get => currency; set => currency = value; }

        public HistoryState() { }

        public HistoryState(int id, DateTime date, int userId, decimal differenceAmount, string currency)
        {
            Id = id;
            Date = date;
            UserId = userId;
            DifferenceAmount = differenceAmount;
            Currency = currency;
        }
    }
}
