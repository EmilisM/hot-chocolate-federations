namespace sub_schema_two;

public class Product
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }
    public string Type { get; set; }

    [GraphQLIgnore]
    public string UserId { get; set; }

    public Task<User> GetUser()
    {
        return Task.FromResult(new User(UserId));
    }

    public Product(string id, string name, string type, string userId)
    {
        Id = id;
        Name = name;
        Type = type;
        UserId = userId;
    }

    [ReferenceResolver]
    public static Task<Product?> GetByIdAsync(string id, ProductRepository userRepository)
    {
        return userRepository.GetProductByIdAsync(id);
    }
}