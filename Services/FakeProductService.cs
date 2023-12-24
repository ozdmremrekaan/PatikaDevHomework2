using PatikaAkbank.NETCohorts_Homework1;
using System.Collections.Generic;

public class FakeProductService : IProductService
{
    private static List<ProductModel> _products = new List<ProductModel>
    {
        new ProductModel { Id = 1, Name = "Product 1", Price = 19.99m },
        new ProductModel { Id = 2, Name = "Product 2", Price = 29.99m }
    };

    public List<ProductModel> GetProducts()
    {
        return _products;
    }

    public ProductModel GetProductById(int id)
    {
        return _products.Find(p => p.Id == id);
    }

    public void AddProduct(ProductModel product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
    }

    public void UpdateProduct(int id, ProductModel updatedProduct)
    {
        var existingProduct = _products.Find(p => p.Id == id);

        if (existingProduct != null)
        {
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = _products.Find(p => p.Id == id);

        if (product != null)
        {
            _products.Remove(product);
        }
    }
}
