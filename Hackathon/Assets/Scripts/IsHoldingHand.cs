using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHoldingHand : MonoBehaviour
{
    void Start()
    {
        GlobalVariables.holdingHand = false;
        //Debug.Log("start holdingHand = " + GlobalVariables.holdingHand);
    }

    void OnTriggerStay(Collider other) {
        GlobalVariables.holdingHand = true;
        //Debug.Log("stay holdingHand = " + GlobalVariables.holdingHand);
    }

    void OnTriggerExit(Collider other) {
        GlobalVariables.holdingHand = false;
        //Debug.Log("exit holdingHand = " + GlobalVariables.holdingHand);
    }
}
