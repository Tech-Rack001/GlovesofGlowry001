using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair : MonoBehaviour
{

    public Player playerOne,playerTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Player GetPlayerOne()
    {
        return this.playerOne;
    }

    public Player GetPlayerTwo()
    {
        return this.playerTwo;
    }

}
