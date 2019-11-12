namespace _5.EnttyRelations.Results
{
    using System;

    public class PurchaseResultModel
    {
        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public CarResultModel Car { get; set; }

        public CustomerResultModel Customer { get; set; }
    }
}
