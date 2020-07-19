using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("collider");
        Attacker isAttacked = other.gameObject.GetComponent<Attacker>();
        if (isAttacked)
        {
            animator.SetTrigger("underAttacked");
            Debug.Log("if");
        }
        return;
    }
    

}
