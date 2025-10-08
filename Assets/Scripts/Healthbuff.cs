using UnityEngine;
[CreateAssetMenu(menuName = "Powerups/Health_powerup")]
public class Healthbuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Health>().Heal(amount);
    }
}
