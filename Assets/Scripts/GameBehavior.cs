using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public TMP_Text HealthText;
    public TMP_Text KillsText;
    public GameObject WinText;
    public GameObject LoseText;

    //Player's default lives
    private int _playerHP = 3;
    //counts the enemies that are still alive
    public int _killsCount = 0;
    public bool hitHouse = false;

    public float delayBeforeQuit = 2.0f;

    void Start()
    {
        HealthText.text += _playerHP;
        WinText.SetActive(false);
        LoseText.SetActive(false);
        
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;

            HealthText.text = "Health: " + HP;
        }
    }

    public int kills
    {
        get { return _killsCount; }
        set
        {
            _killsCount = value;

            KillsText.text = "Kills: " + _killsCount;
        }
    }
    void Update()
    {
        if ((kills == 2) && hitHouse==true)
        {
            WinText.SetActive(true);
        }
        if (HP <= 0)
        {
            Debug.Log("GAME OVER");
            LoseText.SetActive (true);
            Time.timeScale = 0;
            Application.Quit();
        }
    }
    IEnumerator QuitGameWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeQuit);

        // Quit the game
        Application.Quit();
    }

}
