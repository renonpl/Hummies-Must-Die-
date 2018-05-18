using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

   	public int damage;
	private int currentDamage;
    public GameObject bleeding;
    public Transform hitPoint;
    public GameObject damageNumber;

	private PlayerStats thePS;

	// Use this for initialization
	void Start () {
		thePS = FindObjectOfType<PlayerStats> ();
	}

    // Update is called once per frame
    void Update() {

    }
     void OnTriggerEnter2D(Collider2D other)
    {   if (other.gameObject.tag == "Enemy")
        {
			currentDamage = damage + thePS.currentAttack;
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyHp>().HurtEnemy(currentDamage);
            Instantiate(bleeding, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
