using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomBet : MonoBehaviour
{
    public Slider _customBetSlider;
    public Text _customBet,_smallBetValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float value = _customBetSlider.value * float.Parse(_smallBetValue.text);
        _customBet.text = value.ToString();
    }
}
