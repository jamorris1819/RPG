using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour {

    private bool visible = false;
    private bool windowVisible = false;
    private new string name;
    private string message;
    private string[] choices;
    private bool hasChoices;

    // UI variables
    public GameObject textPanel;
    public GameObject namePanel;
    public GameObject choicesPanel4;
    public GameObject choicesPanel3;
    public GameObject choicesPanel2;
    public GameObject continuePanel;
    public GameObject buttons;
    public Text dialogueTitle;
    public Text dialogueText;
    public Button[] options;
    public Button continueButton;

	void Awake () {
        Dialoguer.Initialize();
    }
	
    void Start()
    {
        Dialoguer.events.onStarted += onStarted;
        Dialoguer.events.onEnded += onEnded;
        Dialoguer.events.onInstantlyEnded += onInstantlyEnded;
        Dialoguer.events.onTextPhase += onTextPhase;
        Dialoguer.events.onWindowClose += onWindowClose;
        continueButton.onClick.AddListener(ContinueClick);

        //Dialoguer.StartDialogue(DialoguerDialogues.FOREST_TUTORIAL_1);
    }

    private void onStarted()
    {
        visible = true;
    }

    private void onEnded()
    {
        visible = false;
        name = "";
    }

    private void onInstantlyEnded()
    {
        visible = true;
        windowVisible = false;
    }

    private void onTextPhase(DialoguerTextData data)
    {
        foreach (Button button in options)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }
        if(!string.IsNullOrEmpty(data.name))
            name = data.name;
        message = data.text;
        choices = data.choices;
        // We want to resize the choices box depending on how many we have - we're only using the last 2 buttons, so that we don't have to rescale them
        if (data.windowType == DialoguerTextPhaseType.Text)
            choices = new string[1] { "Continue" };
        if(choices.Length == 1)
        {
            // We already have the ui set out for this
        }
        else if (choices.Length == 2)
        {
            options[2].GetComponentInChildren<Text>().text = choices[0];
            options[2].gameObject.SetActive(true);
            options[2].onClick.AddListener(Option1Click);
            options[3].GetComponentInChildren<Text>().text = choices[1];
            options[3].gameObject.SetActive(true);
            options[3].onClick.AddListener(Option2Click);
        }
        else if (choices.Length == 3)
        {
            options[1].GetComponentInChildren<Text>().text = choices[0];
            options[1].gameObject.SetActive(true);
            options[1].onClick.AddListener(Option1Click);
            options[2].GetComponentInChildren<Text>().text = choices[1];
            options[2].gameObject.SetActive(true);
            options[2].onClick.AddListener(Option2Click);
            options[3].GetComponentInChildren<Text>().text = choices[2];
            options[3].gameObject.SetActive(true);
            options[3].onClick.AddListener(Option3Click);
        }
        else
        {
            for (int i = 0; i < choices.Length; i++)
            {
                options[i].GetComponentInChildren<Text>().text = choices[i];
                options[i].gameObject.SetActive(true);
            }

            options[0].onClick.AddListener(Option1Click);
            options[1].onClick.AddListener(Option2Click);
            options[2].onClick.AddListener(Option3Click);
            options[3].onClick.AddListener(Option4Click);
        }
        dialogueText.text = message;
        dialogueTitle.text = name;
        windowVisible = true;
    }

    private void onWindowClose()
    {
        windowVisible = false;
    }

    private void ContinueClick()
    {
        Dialoguer.ContinueDialogue();
    }

    private void Option1Click()
    {
        Dialoguer.ContinueDialogue(0);
    }

    private void Option2Click()
    {
        Dialoguer.ContinueDialogue(1);
    }

    private void Option3Click()
    {
        Dialoguer.ContinueDialogue(2);
    }

    private void Option4Click()
    {
        Dialoguer.ContinueDialogue(3);
    }

    void Update () {
        bool display = (visible) && (visible == windowVisible);
        textPanel.gameObject.SetActive(display);
        namePanel.gameObject.SetActive(display && name != "");
        continuePanel.gameObject.SetActive(display && choices.Length == 1);
        choicesPanel2.gameObject.SetActive(display && choices.Length == 2);
        choicesPanel3.gameObject.SetActive(display && choices.Length == 3);
        choicesPanel4.gameObject.SetActive(display && choices.Length == 4);
        buttons.SetActive(display);
    }
}
