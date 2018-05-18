using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSwitcher : MonoBehaviour {

	private MusicController musicC;

	public int newTrack;
	public bool switchOnStart;

	Scene scen;


	// Use this for initialization
	void Start () {
		musicC = FindObjectOfType<MusicController> ();
		scen = SceneManager.GetActiveScene ();
	/*	if (switchOnStart) 
		{
			musicC.SwitchTrack (newTrack);
			gameObject.SetActive (false);
		}*/
		if (scen.name == "MainMenu") {
			musicC.SwitchTrack (0);
		} 
		else 
		{
			musicC.SwitchTrack (Random.Range (1, 4));
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

/*	void OnTriggeEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "player")
		{
			musicC.SwitchTrack (newTrack);
			gameObject.SetActive (false);
		}
	}*/
}
