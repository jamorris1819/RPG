using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float PLAYER_WALK_SPEED = 8f;
    public float PLAYER_RUN_SPEED = 12f;

    public bool inMotion;
    public bool frozen = false;

    private Rigidbody2D rbody;
    
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (frozen)
        {
            rbody.velocity = Vector2.zero;
            return;
        }
        Vector3 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        inMotion = direction != Vector3.zero;
        rbody.velocity = direction * ((Input.GetKey(KeyCode.LeftShift)) ? PLAYER_RUN_SPEED : PLAYER_WALK_SPEED);
	}
}
