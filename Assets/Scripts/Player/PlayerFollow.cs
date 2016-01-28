using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerFollow : MonoBehaviour {

    public Transform owner;
    public Transform master;
    public float FOLLOW_DISTANCE = 2f;

    private List<Vector2> positions;
    
	void Start () {
        positions = new List<Vector2>();
	}
	
	void Update () {
        if(!positions.Contains(master.position))                                                // First we need to keep track of where the master is
            positions.Add(master.position);                                                     // We don't want duplicates, otherwise the followers will wait in the same place the same amount of time

        float distance = Vector2.Distance(transform.position, master.position);
        //while(Vector2.Distance(transform.position, positions[0]) > FOLLOW_DISTANCE) { }
        if (distance > FOLLOW_DISTANCE || owner.GetComponent<Player>().inMotion)
        {
            if(distance < FOLLOW_DISTANCE)
                return;
            transform.position = Vector3.Lerp(transform.position, positions[0], 0.075f);          // The follower will move to the next location
            positions.RemoveAt(0);                                                              // This location is now removed
        }
        
    }
}
