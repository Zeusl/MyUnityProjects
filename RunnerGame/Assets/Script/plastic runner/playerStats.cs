using UnityEngine;
using System.Collections;

public class playerStats : MonoBehaviour {
	public int health = 3;

	public void TakeDamage(int damage){
		this.health = this.health - damage;
	}
}
