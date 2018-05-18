using UnityEngine;
using System.Collections;

public class HurtPlayer : MonoBehaviour {

    public int damage;
	private int currentDamage;
	public GameObject damageNumber;

	private PlayerStats thePS;
	private Player2Stats thePS2;

	// Use this for initialization
	void Start () {
		thePS = FindObjectOfType<PlayerStats> ();
		thePS2 = FindObjectOfType<Player2Stats> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.name == "player"))
        {
			currentDamage = damage - thePS.currentDefence - thePS.currentMeleeBonus;
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
    }
}
