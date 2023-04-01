using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCompanion : MonoBehaviour
{
    public LayerMask interactionLayer;

    [SerializeField]
    private CompanionMovement companionMovement;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) {
                Collider[] col = Physics.OverlapSphere(hit.point, 1f, interactionLayer);
                if (col.Length > 0) {
                    companionMovement.target = col[0].transform;
                }
            }
        }
        if (Input.GetButtonDown("Fire2")) {
            companionMovement.ResetTarget();
        }
    }
}
