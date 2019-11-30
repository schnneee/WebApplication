using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModel
{
    public class LedgerViewModel
    {
        public LedgerType Type { get; set; }

        public DateTime Date { get; set; }

        public decimal Money { get; set; }
    }

    public enum LedgerType
    {
        income = 1,
        expend = 0
    }
}