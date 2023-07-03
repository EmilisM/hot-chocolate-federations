namespace sub_schema_two;

public class Query
{
    [UsePaging]
    public Task<List<Product>> GetProducts(ProductRepository userRepository) => userRepository.GetProductsAsync();
}