using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider health1Bar;
    public PlayerHp player1Health;
    public Slider health2Bar;
    public Player2Hp player2Health;
    private static bool UIExist;

	public Text HPText;
	public Text HP2Text;

	private PlayerStats thePS;
	private Player2Stats thePS2;

	public Text levelText;
	public Text level2Text;

	public Text amno;
	public Text potion1;	
	public Text potion2;

	// Use this for initialization
	void Start () {
        health1Bar.maxValue = player1Health.playerMaxHealth;
        health2Bar.maxValue = player2Health.playerMaxHealth;
        if (!UIExist)
        {
            UIExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }else
        {
            Destroy(gameObject);
        }

		thePS = GetComponent<PlayerStats>();
		thePS2 = GetComponent<Player2Stats>();

    }
	
	// Update is called once per frame
	void Update () {
		health1Bar.maxValue = player1Health.playerMaxHealth;
		health2Bar.maxValue = player2Health.playerMaxHealth;
        health1Bar.value = player1Health.playerCurrentHealth;
        health2Bar.value = player2Health.playerCurrentHealth;
		HPText.text = "HP: " + player1Health.playerCurrentHealth + " / " + player1Health.playerMaxHealth;
		HP2Text.text = "HP: " + player2Health.playerCurrentHealth + " / " + player2Health.playerMaxHealth;
		levelText.text = "Lvl: " + thePS.currentLevel;
		level2Text.text = "Lvl: " + thePS2.currentLevel;
		amno.text = "Axes: " + thePS.currentAmno + "/" + thePS.maxAmno;
		potion1.text = "Potions: " + thePS.currentPotion;
		potion2.text = "Potions: " + thePS2.currentPotion;
    }
}
