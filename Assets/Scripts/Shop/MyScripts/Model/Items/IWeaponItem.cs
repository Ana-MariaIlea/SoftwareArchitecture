public interface IWeaponItem
{
    int PhysicalAttack { get; }
    int ElementalAttack { get; }
    int DamageReducedWhenBock { get; }

    void SetWeaponStats(int physical, int elemental, int block);
}
