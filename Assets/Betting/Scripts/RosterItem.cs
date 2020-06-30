using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RosterItem : MonoBehaviour
{
    #region Resources
    public GameObject _imageResources;
    #endregion
    public Player leftPlayer, rightPlayer;
    public Image leftPlayerImage, rightPlayerImage;
    public Text leftPlayerText, rightPlayerText;
    int leftPlayerIndex, rightPlayerIndex;
    public GameObject bettingPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayValues()
    {

        leftPlayerText.text = leftPlayer.GetPlayerName();
        rightPlayerText.text = rightPlayer.GetPlayerName();
        this.leftPlayerImage.sprite = _imageResources.GetComponent<Images>().GetSprite(leftPlayerIndex);
        this.rightPlayerImage.sprite = _imageResources.GetComponent<Images>().GetSprite(rightPlayerIndex);
    }

    public void SetLeftPlayer(Player player) 
    {
        Debug.Log("Setting Left Player");
        this.leftPlayer = player;
        Debug.Log("Setting Left Player Image");
        this.leftPlayerIndex = player.GetImageIndex();
    }

    public void SetRightPlayer(Player player)
    {
        Debug.Log("Setting Right Player");
        this.rightPlayer = player;
        this.rightPlayerIndex = player.GetImageIndex();
    }

    public void PresentBettingPanel()
    {
        Debug.Log("Roster Item was clicked");
        bettingPanel.GetComponent<BetPanel>().SetPlayers(leftPlayer, rightPlayer);
        bettingPanel.GetComponent<BetPanel>().DisplayBettingPanel();
    }
}
