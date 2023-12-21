using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PatikaAkbank.NETCohorts_Homework1
{
    public class ProductModel
    {
        public int Id { get; set; }
        [BindRequired]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
