using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Transform hand;

    [SerializeField] private GameObject[] weaponPref;

    private void Awake()
    {
        AttachWeapon();
    }

    public void AttachWeapon()
    {
        var randomWeaponIndex = Random.Range(0, weaponPref.Length);
        var weapon = Instantiate(weaponPref[randomWeaponIndex], hand, false);
        weapon.layer = gameObject.layer;
    }
}