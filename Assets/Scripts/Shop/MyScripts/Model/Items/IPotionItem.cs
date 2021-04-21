public interface IPotionItem 
{
    int HealthChange { get; }
    int StaminaChange { get; }
    int EffectTime { get; }

    void SetPotionStats(int health, int stamina, int time);
}
