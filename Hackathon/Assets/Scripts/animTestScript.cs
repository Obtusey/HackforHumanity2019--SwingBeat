using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animTestScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            anim.SetTrigger("startRotate");
            Debug.Log("space pressed");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "hand_left" || other.gameObject.name == "hand_right")
        {
            Debug.Log("collision");
        }
    }
}
