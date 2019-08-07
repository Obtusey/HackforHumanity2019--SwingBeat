using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerColider : MonoBehaviour
{
    void /// <summary>
    /// OnControllerColliderHit is called when the controller hits a
    /// collider while performing a Move.
    /// </summary>
    /// <param name="hit">The ControllerColliderHit data associated with this collision.</param>
    OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if(body == null || body.isKinematic)
        {
            return;
        }
        if(body.gameObject.name == "ManuallyRiggedFigure")
        {
            Debug.Log("controller collision");
        }
    }
}
