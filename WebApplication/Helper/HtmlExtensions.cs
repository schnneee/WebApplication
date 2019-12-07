using WebApplication.Models.ViewModel;

namespace WebApplication.Helper
{
    public static class HtmlExtensions
    {
        public static string GetLedgerTypeName(this LedgerType type)
        {
            switch (type)
            {
                case LedgerType.income:
                    return "收入";

                case LedgerType.expend:
                    return "支出";

                default:
                    return "Undefined";
            }
        }
    }
}