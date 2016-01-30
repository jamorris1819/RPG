using UnityEngine;
using System.Collections;

public class ForestLogs : MonoBehaviour {

    public DialoguerDialogues dialogue;
    public bool oneTimeEnterTrigger = false;
    public StoryFunctions story;

    private bool inArea = false;
    private Player player;

    void Start()
    {
        player = GameObject.Find("Player1").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inArea = false;
        }
    }

    void Update()
    {
        if (inArea &&  oneTimeEnterTrigger)
        {
            if (!Dialoguer.GetGlobalBoolean(0))
                return;
            oneTimeEnterTrigger = false;
            player.frozen = true;
            Dialoguer.StartDialogue(dialogue, ReleasePlayer);
        }
    }

    void ReleasePlayer()
    {
        story.RemoveSon();
        player.frozen = false;
    }
}
