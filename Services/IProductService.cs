using PatikaAkbank.NETCohorts_Homework1;
using System.Collections.Generic;

public interface IProductService
{
    List<ProductModel> GetProducts();
    ProductModel GetProductById(int id);
    void AddProduct(ProductModel product);
    void UpdateProduct(int id, ProductModel updatedProduct);
    void DeleteProduct(int id);
}