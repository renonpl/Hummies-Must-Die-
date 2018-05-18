using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

	public string exitPoint;

	private Playercontrol thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<Playercontrol> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "player")
        {
			SceneManager.LoadScene(levelToLoad);
			thePlayer.startPoint = exitPoint;
        }
    }
}
