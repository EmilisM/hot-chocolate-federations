namespace sub_schema_two;

[ExtendServiceType]
public class User
{
    [Key]
    [External]
    public string Id { get; set; }

    public User(string id)
    {
        Id = id;
    }

    [UsePaging]
    public Task<IEnumerable<Product>> GetProducts(ProductRepository productRepository)
    {
        return productRepository.GetProductsByUserIdAsync(Id);
    }

    [ReferenceResolver]
    public static Task<User> GetByIdAsync(string id)
    {
        return Task.FromResult(new User(id));
    }
}