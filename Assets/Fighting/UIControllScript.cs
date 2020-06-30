using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllScript : MonoBehaviour
{
    [Serializable]
    public class UIObject
    {
        [Range(0,1)]
        public float health;
        public Image healthImage;
        [Range(0, 1)]
        public float stamina;
        public Image staminaImage;
        public string name;
        public Text nameLabel;
    };

    public static UIControllScript instance;

    public UIObject player;
    public UIObject opponent;

    public string timer;
    public Text timerText;
    public string round;
    public Text roundText;

    


    private void Start()
    {
        player.healthImage.fillAmount = player.health = 1;
        player.staminaImage.fillAmount = player.stamina = 1;
        player.nameLabel.text = player.name;

        opponent.healthImage.fillAmount = opponent.health;
        opponent.staminaImage.fillAmount = opponent.stamina;
        opponent.nameLabel.text = opponent.name;

        timerText.text = timer;
        roundText.text = round;
    }

    public UIObject getPlayerInfo()
    {
        return player;
    }
    public void setPlayerInfo(UIObject data)
    {
        player = data;
    }

    public UIObject getOpponentInfo()
    {
        return opponent;
    }
    public void setOpponentInfo(UIObject data)
    {
        opponent = data;
    }

}
