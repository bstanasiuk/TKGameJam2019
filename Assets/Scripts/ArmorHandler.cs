using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorHandler : MonoBehaviour
{
    [SerializeField] private GameObject _armorPrefab;
    [SerializeField] private Transform _torso;

    private void Awake()
    {
        AttachArmor();
    }

    public void AttachArmor()
    {
        var armor = Instantiate(_armorPrefab, _torso, false);
        GetComponent<PlayerHealth>().Armor = armor;
    }
}
