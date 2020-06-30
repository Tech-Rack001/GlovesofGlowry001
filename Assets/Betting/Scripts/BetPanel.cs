using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetPanel : MonoBehaviour
{
    #region Resources
    public GameObject _imageResources;
    public Transform _playerPairs;
    #endregion
    public Player leftPlayer, rightPlayer;
    public Text leftPlayerNameText, rightPlayerNameText,_confirmationBetValue,_customBetValue,
        leftPlayerTMValue,rightPlayerTMValue;
    public Image leftPlayerImage, rightPlayerImage;
    public Slider _customBetSlider;
    public Text _smallButtonValue, _mediumButtonValue, _largeButtonValue;

    readonly float smallBet = 250.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        #region Set First set of Players
        SetPlayers(_playerPairs.GetChild(0).GetComponent<Pair>().GetPlayerOne(), _playerPairs.GetChild(0).GetComponent<Pair>().GetPlayerTwo());
        DisplayBettingPanel();
        #endregion
        SetBettingButtonValuesAndSlider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayBettingPanel()
    {
        #region Set Names
        this.leftPlayerNameText.text = leftPlayer.GetPlayerName();
        this.rightPlayerNameText.text = rightPlayer.GetPlayerName();
        #endregion

        #region Set Player Total Money
        this.leftPlayerTMValue.text = leftPlayer.GetPlayerMoney().ToString();
        this.rightPlayerTMValue.text = rightPlayer.GetPlayerMoney().ToString();
        #endregion

        #region Set Player Image
        this.leftPlayerImage.sprite = _imageResources.GetComponent<Images>().GetSprite(leftPlayer.GetImageIndex());
        this.rightPlayerImage.sprite = _imageResources.GetComponent<Images>().GetSprite(rightPlayer.GetImageIndex());
        #endregion
    }

    public void SetPlayers(Player leftPlayer, Player rightPlayer)
    {
        this.leftPlayer = leftPlayer;
        this.rightPlayer = rightPlayer;
    }

    void SetBettingButtonValuesAndSlider()
    {
        _smallButtonValue.text = smallBet.ToString();

        float tempMedium = smallBet * 4;
        _mediumButtonValue.text = tempMedium.ToString();

        float tempLarge = tempMedium * 5;
        _largeButtonValue.text = tempLarge.ToString();

        #region Slider Values
        _customBetSlider.minValue = smallBet/smallBet;
        _customBetSlider.maxValue = tempLarge/smallBet;
        #endregion
    }

    public float GetSmallBet()
    {
        return this.smallBet;
    }
}
