namespace sub_schema_one;

public class UserRepository
{
    private readonly List<User> _users = new()
    {
        new User("1", "John"),
        new User("2", "Tom")
    };

    public Task<User?> GetUserById(string id)
    {
        return Task.FromResult(_users.FirstOrDefault(x => x.Id == id));
    }

    public Task<List<User>> GetUsers()
    {
        return Task.FromResult(_users);
    }
}