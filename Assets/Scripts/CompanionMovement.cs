using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    public Transform defaultTarget;
    public float speed = 1f;
    public float rotationSpeed = 1f;

    private Transform target;
    private bool away = false;

    private void Start() {
        target = new GameObject("Companion Target").transform;
        ResetTarget();
    }

    private void FixedUpdate() {
        if (away) {
            this.transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationSpeed * Time.fixedDeltaTime);
        } else {
            this.transform.position = Vector3.Lerp(transform.position, defaultTarget.position, speed * Time.fixedDeltaTime);
            this.transform.rotation = Quaternion.Lerp(transform.rotation, defaultTarget.rotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    public void ResetTarget() {
        away = false;
        target.position = defaultTarget.position;
        target.rotation = defaultTarget.rotation;
    }

    public void SetTargetPosition(Vector3 position) {
        away = true;
        target.position = position;
    }

    public void SetTargetRotation(Quaternion rotation) {
        target.rotation = rotation;
    }
}
