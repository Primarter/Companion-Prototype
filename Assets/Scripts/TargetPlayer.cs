using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TargetPlayer : MonoBehaviour
{
    public float refreshRate = 3f;

    private Transform player;
    private NavMeshAgent agent;
    private bool chasing = false;
    private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    private void Start() {
        var res = GameObject.FindGameObjectWithTag("Player");
        if (res == null) {
            Debug.Log("Couldn't find GameObject with tag \"Player\"");
            return;
        }
        player = res.transform;

        agent = this.GetComponent<NavMeshAgent>();
    }

    public void ChasePlayer() {
        chasing = true;
        sw.Start();
    }

    public void StopChasing() {
        chasing = false;
        agent.isStopped = true;
        sw.Reset();
        sw.Stop();
    }

    private void Update() {
        if (chasing && sw.ElapsedMilliseconds > refreshRate * 1000f) {
            agent.SetDestination(player.position);
            sw.Restart();
        }
    }
}
