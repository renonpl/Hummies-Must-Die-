using UnityEngine;
using System.Collections;

public class Player2Hp : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
	}

	// Update is called once per frame
	void Update () {
		if(playerCurrentHealth <= 0)
		{
			gameObject.SetActive(false);
		}
	}
	public void HurtPlayer(int damage)
	{
		playerCurrentHealth -= damage;
	}
	public void HealPlayer(int heal)
	{
		playerCurrentHealth += heal;
		if (playerCurrentHealth > playerMaxHealth) 
		{
			playerCurrentHealth = playerMaxHealth;
		}
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}
}
