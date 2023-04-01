using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerInteraction : MonoBehaviour
{
    public UnityEvent Event;

    private bool ready = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Companion") {
            ready = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Companion") {
            ready = false;
        }
    }

    private void Update() {
        if (ready && Input.GetButtonDown("Interact")) {
            Event.Invoke();
        }
    }
}
