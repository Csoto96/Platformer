using UnityEngine;

public class WeaponMan : MonoBehaviour
{
    private IWeapon weapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        weapon = new Enchantment(new Knife());
        weapon.Fire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
