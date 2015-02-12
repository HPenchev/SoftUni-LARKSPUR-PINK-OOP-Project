namespace Game.Interfaces
{
    public interface IItem
    {
        string Id { get; set; }
        int Level { get; set; }
        decimal Price { get; set; }
        int Size { get; set; }
    }
}
