using UnityEngine;

public class Enchantment : WeaponDeco
{
    public Enchantment(IWeapon weapon) : base(weapon) { }
    public override void Fire()
    {
        base.Fire();
        Debug.Log("Magical Fire!");
    }

}
