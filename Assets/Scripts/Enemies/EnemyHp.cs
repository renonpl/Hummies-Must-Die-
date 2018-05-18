using UnityEngine;
using System.Collections;

public class EnemyHp : MonoBehaviour {

    public int enemyMaxHealth;
    public int enemyCurrentHealth;

	private PlayerStats thePlayerStats;
	private Player2Stats thePlayer2Stats;

	public int expToGive;
	public string enemyQuestname;
	private QuestManager theQM;

    // Use this for initialization
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;

		thePlayerStats = FindObjectOfType<PlayerStats>();
		thePlayer2Stats = FindObjectOfType<Player2Stats>();
		theQM = FindObjectOfType<QuestManager> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
			theQM.enemyKilled = enemyQuestname;
            Destroy(gameObject);
			thePlayerStats.AddExperience(expToGive);
			thePlayer2Stats.AddExperience(expToGive);
        }

    }
    public void HurtEnemy(int damage)
    {
        enemyCurrentHealth -= damage;
    }
    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
}

