
public interface IArmorItem
{
    int PhysicalDamageReduction { get; }
    int ElementalDamageReduction { get; }
    int StaminIncrease { get; }

    void SetArmorStats(int physical, int elemental, int stamina);
}
