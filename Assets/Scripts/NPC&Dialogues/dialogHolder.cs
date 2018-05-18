using System.Collections;
using UnityEngine;

public class dialogHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMan;

    public string[] dialogueLines;


	void Start () {

        dMan = FindObjectOfType<DialogueManager>();

	}
	

	void Update () {

	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "player" || other.gameObject.name == "player2")
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
               //  dMan.ShowBox(dialogue);

                if(!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }

                if(transform.parent.GetComponent<NpcMovement>() !=null)
                {
                    transform.parent.GetComponent<NpcMovement>().canMove = false;
                }
            }
        }
    }
}
