using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    Transform hand;
    [SerializeField]
    GameObject weaponPref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttachWeapon();
        }
    }

    public void AttachWeapon()
    {
        GameObject newWeapon = Instantiate(weaponPref);
        Vector3 anglesRotation = newWeapon.transform.localEulerAngles;
        Vector3 position = newWeapon.transform.position;
        newWeapon.transform.SetParent(hand);
       
        newWeapon.transform.localEulerAngles = anglesRotation;
        newWeapon.transform.localPosition = position;
    }

}
