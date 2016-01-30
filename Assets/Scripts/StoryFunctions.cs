using UnityEngine;
using System.Collections;

public class StoryFunctions : MonoBehaviour {

    public GameObject son;

	public void RemoveSon()
    {
        son.SetActive(false);
    }
}
