using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingArrow : MonoBehaviour {

	public float arrowSpeed;
	public int damage;
	private int currentDamage;	
	public Transform hitPoint;
	public GameObject bleeding;
	public GameObject damageNumber;

	private Rigidbody2D myBody;
	public Vector2 direction;


	private PlayerStats thePS;
	private Player2Stats thePS2;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		thePS = FindObjectOfType<PlayerStats> ();
		thePS2 = FindObjectOfType<Player2Stats> ();
	}
	
	// Update is called once per frame
	void Update () {

		myBody.velocity = new Vector2 (direction.x, direction.y);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy") {
		} 
		else
		{
		if ((other.gameObject.name == "player"))
        {
			currentDamage = damage - thePS.currentDefence;
			if (currentDamage <= 0)
			{
				currentDamage = 1;
			}

            other.gameObject.GetComponent<PlayerHp>().HurtPlayer(currentDamage);

        }

		if ((other.gameObject.name == "player2"))
		{
			currentDamage = damage - thePS2.currentDefence;
			if (currentDamage <= 0)
			{
				currentDamage = 1;
			}

			other.gameObject.GetComponent<Player2Hp>().HurtPlayer(currentDamage);
		}
			Destroy (gameObject);
		}
	}
}
