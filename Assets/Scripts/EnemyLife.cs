using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int maxHealth = 1;

    [System.NonSerialized]
    public int currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger");
        if (other.tag == "Companion") {
            currentHealth -= 1;
        }
    }

    private void Update() {
        if (currentHealth <= 0) {
            Destroy(this.gameObject);
        }
    }
}
