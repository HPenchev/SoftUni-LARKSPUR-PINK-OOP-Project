namespace Game.Interfaces
{
    public interface IItem
    {
        int Level { get; set; }
        decimal Price { get; set; }
        int Size { get; set; }
    }
}
