using System;
using WebApplication.Models.ViewModel;

namespace WebApplication.Helper
{
    public static class EnumHelper
    {
        public static LedgerType TryParseLedgerType(this int type)
        {
            return Enum.IsDefined(typeof(LedgerType), type)
                ? (LedgerType)type
                : LedgerType.Undefined;
        }
    }
}