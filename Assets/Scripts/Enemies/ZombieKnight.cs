using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKnight : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D mybody;
	private bool moving;
	private Vector3 moveDirection;
	private Animator anim;
	private Vector2 lastmove;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	private GameObject thePlayer1;
	private GameObject thePlayer2;

	private int whomToAttack;

	public int range;
	public int attackRange;

	// Use this for initialization
	void Start () {
		thePlayer1 = GameObject.Find ("player");
		thePlayer2 = GameObject.Find ("player2");
		anim = GetComponent<Animator>();
		mybody = GetComponent<Rigidbody2D>();
		attacking = false;
		moving = false;

	}

	// Update is called once per frame
	void Update () {
		if (attacking)
		{
			if(attackTimeCounter > 0)
			{
				mybody.velocity = Vector2.zero;
				attackTimeCounter -= Time.deltaTime;
			}
			if(attackTimeCounter <= 0)
			{
				attacking = false;
				anim.SetBool("Attacking", false);
			}
		}
		else
		{
			if(moving)
			{
				switch (whomToAttack) {
				case 0:
					if (Vector2.Distance (thePlayer1.transform.position, mybody.transform.position) < attackRange) {
						attackTimeCounter = attackTime;
						attacking = true;
						mybody.velocity = Vector2.zero;
						anim.SetBool ("Attacking", true);
						break;
					}
					moveDirection = new Vector3 ((thePlayer1.transform.position.x - mybody.transform.position.x) / Mathf.Sqrt ((thePlayer1.transform.position.x - mybody.transform.position.x) * (thePlayer1.transform.position.x - mybody.transform.position.x) + (thePlayer1.transform.position.y - mybody.transform.position.y) * (thePlayer1.transform.position.y - mybody.transform.position.y)) * moveSpeed, (thePlayer1.transform.position.y - mybody.transform.position.y) / Mathf.Sqrt ((thePlayer1.transform.position.x - mybody.transform.position.x) * (thePlayer1.transform.position.x - mybody.transform.position.x) + (thePlayer1.transform.position.y - mybody.transform.position.y) * (thePlayer1.transform.position.y - mybody.transform.position.y)) * moveSpeed, 0);
					mybody.velocity = moveDirection;
					lastmove = moveDirection;
					break;
				case 1:
					if (Vector2.Distance (thePlayer2.transform.position, mybody.transform.position) < attackRange) {
						attackTimeCounter = attackTime;
						attacking = true;
						mybody.velocity = Vector2.zero;
						anim.SetBool ("Attacking", true);
						break;
					}
					moveDirection = new Vector3 ((thePlayer2.transform.position.x - mybody.transform.position.x) / Mathf.Sqrt ((thePlayer2.transform.position.x - mybody.transform.position.x) * (thePlayer2.transform.position.x - mybody.transform.position.x) + (thePlayer2.transform.position.y - mybody.transform.position.y) * (thePlayer2.transform.position.y - mybody.transform.position.y)) * moveSpeed, (thePlayer2.transform.position.y - mybody.transform.position.y) / Mathf.Sqrt ((thePlayer2.transform.position.x - mybody.transform.position.x) * (thePlayer2.transform.position.x - mybody.transform.position.x) + (thePlayer2.transform.position.y - mybody.transform.position.y) * (thePlayer2.transform.position.y - mybody.transform.position.y)) * moveSpeed, 0);
					mybody.velocity = moveDirection;
					lastmove = moveDirection;
					break;
				}
				if (Mathf.Abs (mybody.velocity.x) > 0.5f && Mathf.Abs (mybody.velocity.y) > 0.5f) {
					mybody.velocity = new Vector2 (mybody.velocity.x * 0.7f, mybody.velocity.y * 0.7f);
				}

			} else 
			{
				if (Vector2.Distance(thePlayer1.transform.position, mybody.transform.position) < range)
				{
					moving = true;
					whomToAttack = Random.Range(0,2);
				}
				if (Vector2.Distance(thePlayer2.transform.position, mybody.transform.position) < range)
				{
					whomToAttack = Random.Range(0,2);
					moving = true;	
				}
			}
		}
		anim.SetFloat("MoveX", moveDirection.x);
		anim.SetFloat("MoveY", moveDirection.y);
		anim.SetBool("KnightMoving", moving);
		anim.SetFloat("LastMoveX", lastmove.x);
		anim.SetFloat("LastMoveY", lastmove.y);

	}
}
