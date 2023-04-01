using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<TargetPlayer> enemies;

    private void Start() {
        enemies = new List<TargetPlayer>(GetComponentsInChildren<TargetPlayer>());
    }

    public void TriggerEnemies() {
        foreach(var en in enemies) {
            en.ChasePlayer();
        }
    }

    public void StopEnemies() {
        foreach(var en in enemies) {
            en.StopChasing();
        }
    }
}
