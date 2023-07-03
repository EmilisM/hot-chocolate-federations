namespace sub_schema_one;

public class User
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }

    public User(string id, string name)
    {
        Id = id;
        Name = name;
    }

    [ReferenceResolver]
    public static Task<User?> GetByIdAsync(string id, UserRepository userRepository)
    {
        return userRepository.GetUserById(id);
    }
}