using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Transform door;
    public Transform doorOpenTarget;
    public float openingDuration = 3f;

    private bool opening = false;
    private Vector3 doorStartPosition;
    private Vector3 doorEndPosition;
    private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    public void OpenDoor() {
        doorStartPosition = door.position;
        doorEndPosition = doorOpenTarget.position;
        opening = true;
        sw.Start();
    }

    private void Update() {
        if (opening) {
            float x = EasingFunctions.EaseInOutSine(sw.ElapsedMilliseconds / (openingDuration * 1000f));
            door.position = doorStartPosition + (doorEndPosition - doorStartPosition) * x;
        }
        if (sw.ElapsedMilliseconds > openingDuration * 1000f) {
            opening = false;
            this.enabled = false;
        }
    }
}
