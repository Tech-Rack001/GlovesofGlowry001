using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public AIController AI;
    // Start is called before the first frame update
    void Start()
    {
        //AI=GameObject.FindGameObjectsWithTag("AI");//;.GetComponent<AIController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="AI")
        {
            AI.ActiveControlls=true;
        }
    }
}
