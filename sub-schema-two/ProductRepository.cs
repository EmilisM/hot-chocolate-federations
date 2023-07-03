namespace sub_schema_two;

public class ProductRepository
{
    private readonly List<Product> _products = new()
    {
        new Product("1", "Table", "Furniture", "1"),
        new Product("2", "Chair", "Furniture", "2")
    };

    public Task<Product?> GetProductByIdAsync(string id)
    {
        return Task.FromResult(_products.FirstOrDefault(x => x.Id == id));
    }

    public Task<IEnumerable<Product>> GetProductsByUserIdAsync(string userId)
    {
        return Task.FromResult(_products.Where(x => x.UserId == userId));
    }

    public Task<List<Product>> GetProductsAsync()
    {
        return Task.FromResult(_products);
    }
}