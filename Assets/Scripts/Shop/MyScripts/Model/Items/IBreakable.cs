public interface IBreakable 
{
    int Durability { get; }

    void Deteriorate();

    void SetDurability(int d);
}
