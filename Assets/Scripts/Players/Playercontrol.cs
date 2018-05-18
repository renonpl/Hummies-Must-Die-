using UnityEngine;
using System.Collections;

public class Playercontrol : MonoBehaviour {

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

    public string startPoint;
	public GameObject weapon;
	public GameObject theAxe;
	public Transform throwPoint;
	private bool throwing;
	private ThrowingAxe throwAxe;

    public bool canMove;
	public int blockBonus;
	private PlayerStats stat;
	private bool blocking;

    // Use this for initialization
    void Start () {
		stat = FindObjectOfType<PlayerStats>();
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
    void Update() {
        moving = false;
        if(!canMove)
        {
            mybody.velocity = Vector2.zero;
            return;
        }

		if (!attacking && !throwing && !blocking)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                mybody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, mybody.velocity.y);
                transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
                moving = true;
                lastmove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                mybody.velocity = new Vector2(mybody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
                moving = true;
                lastmove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") > -0.5f && Input.GetAxisRaw("Horizontal") < 0.5f)
            {
                mybody.velocity = new Vector2(0, mybody.velocity.y);
            }
            if (Input.GetAxisRaw("Vertical") > -0.5f && Input.GetAxisRaw("Vertical") < 0.5f)
            {
                mybody.velocity = new Vector2(mybody.velocity.x, 0);
            }

			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) < 0.5f || Mathf.Abs (Input.GetAxisRaw ("Vertical")) < 0.5f)
			{
				currentMoveSpeed = moveSpeed;
			}

			if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f)
			{
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			}

            if (Input.GetKeyDown(KeyCode.K))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                mybody.velocity = Vector2.zero;
                anim.SetBool("Attacking", true);
            }

			if (Input.GetKeyDown (KeyCode.L) && stat.currentAmno > 0) 
			{
				weapon.SetActive (false);
				throwing = true;
				mybody.velocity = Vector2.zero;
				anim.SetBool("Throwing", true);
				attackTimeCounter = attackTime;
				GameObject axeClone = (GameObject)Instantiate (theAxe, throwPoint.position, throwPoint.rotation);
				axeClone.transform.localScale = transform.localScale * 0.8f;
				throwAxe = FindObjectOfType<ThrowingAxe>();
				//throwAxe.way = throwPoint.rotation.z;
				throwAxe.direction = lastmove;
				stat.UseAmno ();
			}
			if (Input.GetKeyDown (KeyCode.J))
			{
				attackTimeCounter = attackTime;
				blocking = true;
				mybody.velocity = Vector2.zero;
				anim.SetBool("Blocking", true);
				stat.currentMeleeBonus = blockBonus;
			}
			if (Input.GetKeyDown (KeyCode.M)) 
			{
				stat.UsePotion ();
			}

		}
        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if(attackTimeCounter <= 0)
        {
			stat.currentMeleeBonus = 0;
			weapon.SetActive (true);
			throwing = false;
			blocking = false;
            attacking = false;
            anim.SetBool("Attacking", false);
			anim.SetBool("Throwing", false);
			anim.SetBool("Blocking", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", moving);
        anim.SetFloat("LastMoveX", lastmove.x);
        anim.SetFloat("LastMoveY", lastmove.y);
    }
}
