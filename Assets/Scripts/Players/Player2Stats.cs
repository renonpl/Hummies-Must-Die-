using UnityEngine;
using System.Collections;

public class Player2Stats : MonoBehaviour {

	public int currentLevel;

	public int currentExp;

	public int[] toLevelUp;

	public int[] HPLevels;
	public int[] attackLevels;
	public int[] defenceLevels;

	public int currentHP;
	public int currentAttack;
	public int currentDefence;
	public int currentMeleeBonus;

	public int maxPotion;
	public int currentPotion;
	public int potionEfficiency;

	private Player2Hp thePlayerHealth;

	// Use this for initialization
	void Start () {
		currentPotion = maxPotion - 2;
		currentMeleeBonus = 0;
		currentHP = HPLevels [1];
		currentAttack = attackLevels [1];
		currentDefence = defenceLevels [1];

		thePlayerHealth = FindObjectOfType<Player2Hp> ();
}
	
	// Update is called once per frame
	void Update () {

		if(currentExp >= toLevelUp[currentLevel])
		{
			LevelUp ();
		}
	
	}

	public void AddExperience(int experienceToAdd)
	{
		currentExp += experienceToAdd;
	}

	public void LevelUp()
	{
		currentLevel++;
		currentHP = HPLevels [currentLevel];
		currentAttack = attackLevels [currentLevel];
		currentDefence = defenceLevels [currentLevel];

		thePlayerHealth.playerMaxHealth = currentHP;
		thePlayerHealth.playerCurrentHealth += currentHP - HPLevels [currentLevel - 1];
	}


	public void UsePotion()
	{
		if (currentPotion == 0) 
		{
			return;
		}
		currentPotion--;
		thePlayerHealth.HealPlayer (potionEfficiency);
	}

}
