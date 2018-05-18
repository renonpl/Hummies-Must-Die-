using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	private PlayerHp theP1;
	private Player2Hp theP2;

	public bool isPaused;
	public GameObject PauseMenuCanvas;
	public GameObject gameOver;

	// Use this for initialization
	void Start () {
		theP1 = FindObjectOfType<PlayerHp> ();
		theP2 = FindObjectOfType<Player2Hp>();
	}
	
	// Update is called once per frame
	void Update () {
		if (theP1.playerCurrentHealth <= 0 || theP2.playerCurrentHealth <= 0)
		{
			isPaused = true;
			gameOver.SetActive (true);
		}

		if (isPaused) 
		{
			PauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		}
		else
		{
			PauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			isPaused = !isPaused;
		}
		
	}
	public void Resume()
	{
		isPaused = false;
	}

	public void QuitToMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void Quit()
	{
		Application.Quit ();
	}
		
}
