using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendCompanion : MonoBehaviour
{
    public LayerMask interactionLayer;
    public LayerMask nonCompanionLayer;

    [SerializeField]
    private CompanionMovement companionMovement;

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity)) {
                companionMovement.SetTargetPosition(hit.point);
                Collider[] col = Physics.OverlapSphere(hit.point, 1f, interactionLayer);
                if (col.Length > 0) {
                    companionMovement.SetTargetPosition(col[0].transform.position);
                }
            }
        }
        Debug.DrawRay(Camera.main.transform.position, (companionMovement.transform.position - Camera.main.transform.position).normalized, Color.red);
        if (Input.GetButtonDown("Fire2")) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position,
                (companionMovement.transform.position - Camera.main.transform.position).normalized,
                out hit,
                Mathf.Infinity, nonCompanionLayer))
            {
                if (hit.transform.tag == "Companion") {
                    companionMovement.ResetTarget();
                }
            };
        }
    }
}
