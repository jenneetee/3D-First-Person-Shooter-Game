using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    
    public int maxAmmo = 60;
    private int currentAmmo;
    public float reloadTime = 1f;
    public WeaponSwitching _weaponSwitching;
    public ItemCollector _itemCollector;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    public GameObject GUN;
    public GameObject RPG;

    [SerializeField] AudioSource gunSound;

    void Start()
    {
        currentAmmo = maxAmmo;
        _weaponSwitching = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>();
    }

    void Update()
    {
        //checks if there is no more ammo
        
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            currentAmmo -= 10;
            Shoot();
            Debug.Log("Ammo left:" + currentAmmo/10);
            gunSound.Play();
        }
        else if (currentAmmo <= 0)
        {
            Debug.Log("Collect more ammo!");
        }

        //Unable to figure out a way to update currentAmmo when collecting rpg or gun ammo

    }
    void Shoot()
    {
        muzzleFlash.Play();
        currentAmmo--;

        RaycastHit hit;
         if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyController enemy =  hit.transform.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
    public void CollectAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

}
