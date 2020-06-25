using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameBehavior : MonoBehaviour
{
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;

    public bool showWinScreen = false;

    public bool showLossScreen = false;
    private int _itemsCollected = 0;
    public int Items
    {
        get { return _itemsCollected; }
        set {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if (_itemsCollected >= maxItems)
            {
                ChangeWinOrLoseMessage("You've found all the items!", true);
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
        
    }

    private int _playerLives = 3;

    public int Lives
    {
        get { return _playerLives; }
        set {
            _playerLives = value;
            Debug.LogFormat("Lives: {0}", _playerLives);
            if(_playerLives <= 0)
            {
                ChangeWinOrLoseMessage("You want another life with that?", false);
            }
            else
            {
                labelText = "Ouch... that's got hurt.";
            }

            }
        

    }
    void ChangeWinOrLoseMessage(string labelText,bool isWin)
    {
        this.labelText = labelText;
        if (isWin)
        {
            showWinScreen = true;
        }
        else
        {
            showLossScreen = true;
        }
        Time.timeScale = 0f;
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(20,20,150,25),"Player Health:"+_playerLives);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width/2 - 100,Screen.height/2 - 50,200,100),"YOU WON!"))
            {
                RestartLevel();
            }
        }
        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                RestartLevel();
            }
        }
    }
}
