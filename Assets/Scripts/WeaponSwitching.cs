using TMPro;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject GUN;
    public GameObject RPG;
    public TMP_Text BulletsText;

    private bool isWeapon1Active = true;
    private int _gunBulletsLeft = 6;
    private int _rpgBulletsLeft = 1;
    private Gun gunScript;

    void Start()
    {
        GUN.SetActive(true);
        RPG.SetActive(false);
    }

    public int gunBullets
    {
        get { return _gunBulletsLeft; }
        set
        {
            _gunBulletsLeft = value;

            BulletsText.text = "Bullets: " + gunBullets;
        }
    }
    public int rpgBullets
    {
        get { return _rpgBulletsLeft; }
        set
        {
            _rpgBulletsLeft = value;

            BulletsText.text = "Bullets: " + rpgBullets;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isWeapon1Active = !isWeapon1Active;

            // Toggle the active state of the weapons
            GUN.SetActive(isWeapon1Active);
            RPG.SetActive(!isWeapon1Active);
        }

        if (isWeapon1Active)
        {
            BulletsText.text = "Bullets: " + _gunBulletsLeft;
        }
        if (!isWeapon1Active)
        {
            BulletsText.text = "Bullets: " + _rpgBulletsLeft;
        }

        if(isWeapon1Active && Input.GetButtonDown("Fire1"))
        {
            gunBullets -= 1;
        }
        else if (!isWeapon1Active && Input.GetButtonDown("Fire1"))
        {
            rpgBullets -= 1;
        }

    }
}
