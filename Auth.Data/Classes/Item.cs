namespace Auth.Data.Classes
{
    public abstract class Item
    {
        public int Id { get; set; }
        public bool Zombie { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
