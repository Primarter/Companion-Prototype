
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody rbody;
    public Transform rotationTransform;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 move, Vector3 onScreenRotationTarget)
    {
        Vector3 newPos = rbody.position + new Vector3(move.x, 0.0f, move.y);
        rbody.MovePosition(newPos);
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (rotationTransform.position);
        float newAngle = -Helpers.AngleBetweenTwoPoints(positionOnScreen, onScreenRotationTarget);
        rotationTransform.rotation = Quaternion.Euler(0f, newAngle, 0f);
    }
}