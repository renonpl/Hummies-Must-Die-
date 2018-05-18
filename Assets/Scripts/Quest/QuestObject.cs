using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

	public int questNumber;

	public QuestManager theQM;
	public int ExpToGive;
	public string startText;
	public string endText;
	public Player2Stats Player2;
	public PlayerStats Player1;

	public bool isItemQuest;
	public string targetItem;

	public bool isEnemyQuest;
	public string targetEnemy;
	public int enemiesToKill;
	private int enemyKillCount;

	public bool chainQuest;
	public int nextQuestNumber;

	void Start () {

	}


	void Update () 
	{
		if (isItemQuest) 
		{
			if (theQM.itemCollected == targetItem) 
			{
				theQM.itemCollected = null;
				EndQuest ();
			}
		}
		if (isEnemyQuest) 
		{
			if (theQM.enemyKilled == targetEnemy) 
			{
				theQM.enemyKilled = null;
				enemyKillCount++;
			}
			if (enemyKillCount >= enemiesToKill) 
			{
				EndQuest ();
			}
		}
	}
	public void StartQuest()
	{
		theQM.ShowQuestText (startText);
	}
	public void EndQuest()
	{
		Player2.AddExperience(ExpToGive);
		Player1.AddExperience (ExpToGive);
		theQM.ShowQuestText (endText);
		if (chainQuest) 
		{
			theQM.quests[nextQuestNumber].gameObject.SetActive (true);
			theQM.quests[nextQuestNumber].StartQuest();
		}
		theQM.questCompleted [questNumber] = true;
		gameObject.SetActive (false);
	}
}
