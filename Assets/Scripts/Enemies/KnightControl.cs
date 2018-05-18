using UnityEngine;
using System.Collections;

public class KnightControl : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D mybody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    private Animator anim;
    private Vector2 lastmove;

    public float waitToReload;
   // private bool reloading;
    private GameObject thePlayer;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
        moving = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            mybody.velocity = moveDirection;

            if (timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            mybody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeBetweenMoveCounter = timeBetweenMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0);
                lastmove = moveDirection;
            }
        }
        anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);
        anim.SetBool("KnightMoving", moving);
        anim.SetFloat("LastMoveX", lastmove.x);
        anim.SetFloat("LastMoveY", lastmove.y);

      /*  if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0f)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }*/

    }
    void OnCollisionEnter2D(Collision2D other)
     {
        /* if ((other.gameObject.name == "player") || (other.gameObject.name == "player2"))
         {
             //Destroy(other.gameObject);
             other.gameObject.SetActive(false);
             reloading = true;
             thePlayer = other.gameObject;
         }*/
    }
}