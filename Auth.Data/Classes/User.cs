namespace Auth.Data.Classes
{
    public class User : Principal
    {
        public User( string username = "", string password = "", string email = "" ) 
        { 
            Username = username;
            Password = password;
            Email    = email;
        }

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email    { get; set; } = string.Empty;

        public virtual ICollection<Group> Groups { get; set;} = new HashSet<Group>();
    }
}
