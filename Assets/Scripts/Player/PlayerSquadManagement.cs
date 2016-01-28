using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSquadManagement : MonoBehaviour {

    public List<Transform> players;

	void Start () {
	    for(int i = 0; i < players.Count; i++)
        {
            int j = i;
            //if(i > 0)


            players[i].GetComponent<PlayerFollow>().master = players[i - 1];
        }
	}
	
	void Update () {
	
	}
}
