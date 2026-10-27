namespace _0_Framework.Domain
{
    public enum CustomerType
    {
        LEGAL = 1, //حقوقی
        NATURAL = 2 // حقیقی
    }

    public enum OrderSource
    {
        WEBSITE = 1, // سایت
        PHONE = 2 // ثبت تلفنی توسط کارشناس
    }

    public enum OrderStatus
    {
        Draft = 1,
        Registered = 2,
        Confirmed = 3,
        InProgress = 4,
        Completed = 5,
        Cancelled = 6
    }

    public enum SettlementType
    {
        AfterLoading = 1,
        AtDelivery = 2,
        Deferred = 3
    }

    public enum InvoiceType : byte
    {
        Informal = 1, // غیررسمی
        Official = 2  // رسمی
    }
}
