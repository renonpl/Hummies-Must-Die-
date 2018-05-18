using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

    private Playercontrol thePlayer;
    private Player2control thePlayer2;
    private CameraControl theCamera;

	public string pointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Playercontrol>();

		if (thePlayer.startPoint == pointName)
		{

			thePlayer.transform.position = transform.position;

            thePlayer2 = FindObjectOfType<Player2control> ();
			thePlayer2.transform.position = transform.position;

			theCamera = FindObjectOfType<CameraControl> ();
			theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
