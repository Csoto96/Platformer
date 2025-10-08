using UnityEngine;

public class WeaponDeco : IWeapon
{
    protected IWeapon _weapon;
    public WeaponDeco(IWeapon weapon)
    {
        _weapon = weapon;
    }
    public virtual void Fire()
    {
        _weapon.Fire();
    }
}
