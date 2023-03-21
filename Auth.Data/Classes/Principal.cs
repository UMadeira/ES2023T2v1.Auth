namespace Auth.Data.Classes
{
    public abstract class Principal : Item
    {
        public virtual ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();
    }
}
