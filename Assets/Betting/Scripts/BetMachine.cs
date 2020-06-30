using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetMachine : MonoBehaviour
{

    public GameObject[] bettingModules;
    int winner;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game has started");  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetermineWinner()
    {
        winner= Random.Range(0, bettingModules.Length);
        Debug.Log("The Winner is:"+bettingModules[winner].GetComponent<BettingModule>().GetPlayer().GetPlayerName());
        GiveMoneyToWinner(winner);
    }

    public void GiveMoneyToWinner(int winner)
    {
        float prize_money = 0;
        for(int i=0; i < bettingModules.Length; i++)
        {
            if (i != winner)
            {
                prize_money += bettingModules[i].GetComponent<BettingModule>().GetBetValue();
                bettingModules[i].GetComponent<BettingModule>().GetPlayer().SetPlayerBet(0);
            }
        }
        bettingModules[winner].GetComponent<BettingModule>().GetPlayer().SetPlayerMoney(bettingModules[winner].GetComponent<BettingModule>().GetPlayer().GetPlayerMoney() + prize_money);
    }
}
