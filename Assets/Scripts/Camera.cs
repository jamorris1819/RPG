using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

    public Sprite cursor;
    public Transform firstTarget;
    public Transform secondTarget;

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(cursor.texture, Vector2.zero, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 moveTo = new Vector3((firstTarget.position.x + secondTarget.position.x) / 2, (firstTarget.position.y + secondTarget.position.y) / 2, -10);
        transform.position = Vector3.Lerp(transform.position, moveTo, 0.1f);
	}
}
