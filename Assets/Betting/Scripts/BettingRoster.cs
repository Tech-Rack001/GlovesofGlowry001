using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingRoster : MonoBehaviour
{

    public GameObject _playerPairs;
    public GameObject _rosterItem;
    public GameObject _roster;

    void Awake()
    {
        DisplayRoster();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("This is the amount of player pair:" + _playerPairs.transform.childCount);
    }

    void DisplayRoster()
    {
        _rosterItem.SetActive(true);
        foreach(Transform pair in _playerPairs.transform)
        {
            Debug.Log("Making a roster item");
            GameObject _tempRosterItem = Instantiate(_rosterItem,new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            _tempRosterItem.GetComponent<RosterItem>().SetLeftPlayer(pair.GetComponent<Pair>().GetPlayerOne());
            _tempRosterItem.GetComponent<RosterItem>().SetRightPlayer(pair.GetComponent<Pair>().GetPlayerTwo());
            _tempRosterItem.GetComponent<RosterItem>().DisplayValues();
            _tempRosterItem.transform.parent = _roster.transform;
        }
        _rosterItem.SetActive(false);
    }
}
