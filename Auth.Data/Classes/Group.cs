namespace Auth.Data.Classes
{
    public class Group : Principal
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual Group? Parent { get; set; }
        public virtual ICollection<Group> Children { get; set;} = new List<Group>();

        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}
