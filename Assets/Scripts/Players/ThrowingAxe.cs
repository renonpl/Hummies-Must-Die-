using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAxe : MonoBehaviour {

	public float axeSpeed;
	public int damage;
	private int currentDamage;
	public Transform hitPoint;
	public GameObject bleeding;
	public GameObject damageNumber;

	private Rigidbody2D myBody;
	private PlayerStats thePS;
	//public float way;
	public Vector2 direction;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D> ();
		thePS = FindObjectOfType<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Direction (way);
		//myBody.velocity = new Vector2(-axeSpeed * transform.localScale.x, 0);
		if (direction.x > 0 && direction.y == 0) 
		{
			myBody.velocity = new Vector2 (axeSpeed * transform.localScale.x, 0);
			transform.Rotate (0, 0, -1 * axeSpeed);
		}
		if (direction.y > 0) {
			myBody.velocity = new Vector2 (0, axeSpeed * transform.localScale.y);
			transform.Rotate (0, 0, -1 * axeSpeed);
		}
		if (direction.x < 0 && direction.y == 0)
		{
			myBody.velocity = new Vector2 (-axeSpeed * transform.localScale.x, 0);
			transform.Rotate (0, 0, -1 * axeSpeed);
		}
		if (direction.y < 0)
		{
			myBody.velocity = new Vector2 (0, -axeSpeed * transform.localScale.x);
			transform.Rotate (0, 0, -1 * axeSpeed);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
		} 
		else
		{
			if (other.gameObject.tag == "Enemy")
			{
				currentDamage = damage + thePS.currentAttack;
				other.gameObject.GetComponent<EnemyHp>().HurtEnemy(currentDamage);
				Instantiate(bleeding, hitPoint.position, hitPoint.rotation);
				var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
				clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
				Destroy (gameObject);
			}
			Destroy (gameObject);
		}
	}

/*	public void Direction(float rotation)
	{
		if(Mathf.Approximately(rotation, 0f))
			myBody.velocity = new Vector2 (axeSpeed * transform.localScale.x, 0);
		if(Mathf.Approximately(rotation, 0.7071068f))
			myBody.velocity = new Vector2 (0, axeSpeed * transform.localScale.y);
		if(Mathf.Approximately(rotation, 1f))
			myBody.velocity = new Vector2 (-axeSpeed * transform.localScale.x, 0);
		if(Mathf.Approximately(rotation, 0.7071068f))
			myBody.velocity = new Vector2 (0, -axeSpeed * transform.localScale.x);
	}*/
}
