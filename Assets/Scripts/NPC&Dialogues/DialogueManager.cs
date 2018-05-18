using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine;

    private Playercontrol thePlayer;
    private Player2control thePlayer2;

	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<Playercontrol>();
        thePlayer2 = FindObjectOfType<Player2control>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            // dBox.SetActive(false);
            // dialogActive = false;
            currentLine++;
        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
            thePlayer.canMove = true;
            thePlayer2.canMove = true;
        }

        dText.text = dialogLines [currentLine];

    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
        thePlayer2.canMove = false;
    }

}
