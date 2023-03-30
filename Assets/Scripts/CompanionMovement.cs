using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float rotationSpeed = 1f;

    private void FixedUpdate() {
        this.transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.fixedDeltaTime);
        this.transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationSpeed * Time.fixedDeltaTime);
    }
}
