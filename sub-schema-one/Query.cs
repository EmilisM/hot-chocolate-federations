namespace sub_schema_one;

public class Query
{
    public Task<User?> Me(UserRepository userRepository) => userRepository.GetUserById("1");

    [UsePaging]
    public Task<List<User>> GetUsers(UserRepository userRepository) => userRepository.GetUsers();
}