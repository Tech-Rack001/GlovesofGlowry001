using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingModule : MonoBehaviour
{
    public float betIncrement;
    public Text bm_name_field;
    public Text bm_totalMoney_field;
    public Text bm_bet_field;
    public Text bm_title_field;
    public GameObject player;
    public float total_bet_value;

    string MONEY_SYMBOL = "$";
    Player player_character;

    void Awake()
    {
        player_character = player.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DisplayValues();
        total_bet_value = player_character.GetPlayerBet();
        Debug.Log(this.player_character.GetPlayerName() + "Has a total bet value of " + total_bet_value.ToString());
    }


    public void IncreaseBet()
    {
        player_character.IncreaseBet(this.betIncrement);
    }

    public void DecreaseBet()
    {
        player_character.DecreaseBet(this.betIncrement);
    }

    public void DisplayValues()
    {
        Debug.Log("Displaying Values for:"+this.player_character.GetPlayerName());
        
        this.bm_bet_field.text = MONEY_SYMBOL + player_character.GetPlayerBet().ToString();
        this.bm_name_field.text = player_character.GetPlayerName();
        this.bm_totalMoney_field.text = MONEY_SYMBOL + player_character.GetPlayerMoney().ToString();
    }

    public Player GetPlayer()
    {
        return this.player_character;
    }

    public float GetBetValue()
    {
        return total_bet_value;
    }
}
