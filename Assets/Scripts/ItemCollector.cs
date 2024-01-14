using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private WeaponSwitching _weaponSwitching;

    private Gun _gunScript1;

    private void Start()
    {
        _weaponSwitching = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>();
        _gunScript1 = GameObject.Find("GUN").GetComponent<Gun>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            Destroy(other.gameObject);
            _gunScript1.CollectAmmo(2);
            //only updates the text but not the actual ammo
            _weaponSwitching.gunBullets += 2;
        }
        if (other.gameObject.CompareTag("RpgAmmo"))
        {
            Destroy(other.gameObject);
            _weaponSwitching.rpgBullets += 1;
        }
    }
}
