namespace Auth.Data.Classes
{
    public class User : Principal
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email    { get; set; } = string.Empty;

        public virtual ICollection<Group> Groups { get; set;} = new HashSet<Group>();
    }
}
