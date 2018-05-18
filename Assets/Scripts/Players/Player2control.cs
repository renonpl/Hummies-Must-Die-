using UnityEngine;
using System.Collections;

public class Player2control : MonoBehaviour
{

    public float moveSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
    private Animator anim;
    private Rigidbody2D mybody;

    private bool moving;
    private Vector2 lastmove;

    private static bool playerexist;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

    public bool canMove;
	public int blockBonus;
	private Player2Stats stat;
	private bool blocking;

    // Use this for initialization
    void Start()
    {
		stat = FindObjectOfType<Player2Stats>();
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();


        if (!playerexist)
        {
            playerexist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        moving = false;

        if (!canMove)
        {
            mybody.velocity = Vector2.zero;
            return;
        }

		if (!attacking && !blocking) {
			if (Input.GetAxisRaw ("Horizontal2") > 0.5f || Input.GetAxisRaw ("Horizontal2") < -0.5f) {

				mybody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal2") * currentMoveSpeed, mybody.velocity.y);
				transform.Translate (new Vector2 (Input.GetAxisRaw ("Horizontal2") * moveSpeed * Time.deltaTime, 0f));
				moving = true;
				lastmove = new Vector2 (Input.GetAxisRaw ("Horizontal2"), 0f);
			}
			if (Input.GetAxisRaw ("Vertical2") > 0.5f || Input.GetAxisRaw ("Vertical2") < -0.5f) {
				mybody.velocity = new Vector2 (mybody.velocity.x, Input.GetAxisRaw ("Vertical2") * currentMoveSpeed);
				transform.Translate (new Vector2 (0f, Input.GetAxisRaw ("Vertical2") * moveSpeed * Time.deltaTime));
				moving = true;
				lastmove = new Vector2 (0f, Input.GetAxisRaw ("Vertical2"));
			}


			if (Input.GetAxisRaw ("Horizontal2") > -0.5f && Input.GetAxisRaw ("Horizontal2") < 0.5f) {
				mybody.velocity = new Vector2 (0, mybody.velocity.y);
			}
			if (Input.GetAxisRaw ("Vertical2") > -0.5f && Input.GetAxisRaw ("Vertical2") < 0.5f) {
				mybody.velocity = new Vector2 (mybody.velocity.x, 0);
			}
			if (Input.GetKeyDown(KeyCode.G))
			{
				attackTimeCounter = attackTime;
				attacking = true;
				mybody.velocity = Vector2.zero;
				anim.SetBool("Attacking", true);
			}

			if (Input.GetKeyDown (KeyCode.F))
			{
				attackTimeCounter = attackTime;
				blocking = true;
				mybody.velocity = Vector2.zero;
				anim.SetBool("Blocking", true);
				stat.currentMeleeBonus = blockBonus;
			}

			if (Input.GetKeyDown (KeyCode.V)) 
			{
				stat.UsePotion ();
			}

			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal2")) < 0.5f || Mathf.Abs (Input.GetAxisRaw ("Vertical2")) < 0.5f) {
				currentMoveSpeed = moveSpeed;
			}

			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal2")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical2")) > 0.5f) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			}
		}
		if(attackTimeCounter > 0)
		{
			attackTimeCounter -= Time.deltaTime;
		}
		if(attackTimeCounter <= 0)
		{
			attacking = false;
			blocking = false;
			anim.SetBool ("Blocking", false);
			anim.SetBool("Attacking", false);
		}
		

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal2"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical2"));
        anim.SetBool("PlayerMoving", moving);
        anim.SetFloat("LastMoveX", lastmove.x);
        anim.SetFloat("LastMoveY", lastmove.y);
    }
}
