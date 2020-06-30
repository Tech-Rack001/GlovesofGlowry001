using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    readonly string IMAGE_PATH = "Assets/Person/";
    public int _imageIndex;
    public string _userImageName;
    public float player_totalMoney;
    public float player_bet;
    public string player_name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float GetPlayerMoney()
    {
        return this.player_totalMoney;
    }

    public void SetPlayerMoney(float value)
    {
        this.player_totalMoney = value;
    }

    public float GetPlayerBet()
    {
        return this.player_bet;
    }

    public void SetPlayerBet(float value)
    {
        this.player_bet = value;
    }

    public string GetPlayerName()
    {
        return this.player_name;
    }

    public void SetPlayerName(string value)
    {
        this.player_name = value;
    }

    public void IncreaseBet(float value)
    {
        if (value <= player_totalMoney)
        {
            this.player_bet += value;
            this.player_totalMoney -= value;
        }
        else
        {
            Debug.Log(this.player_name + " Is unable to bet anymore because of insufficient funds.");
        }
    }

    public void DecreaseBet(float value)
    {
        if (value < player_bet)
        {
            this.player_bet -= value;
            this.player_totalMoney += value;
        }
        else
        {
            Debug.Log(this.player_name + " Is unable to decrease the bet any further because negative/zero bets are not allowed.");
        }
    }

    public string GetImagePath()
    {
        return this.IMAGE_PATH + _userImageName;
    }

    public string GetImageName()
    {
        return this._userImageName;
    }

    public int GetImageIndex()
    {
        return this._imageIndex;
    }
}
