namespace DependencyInjection
{
    internal class User
    {
        public User(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}
