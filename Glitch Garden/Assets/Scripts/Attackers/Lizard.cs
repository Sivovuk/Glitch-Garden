using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{

    private Animator anim;
    private Attacker attacker;

    void Start()
    {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {

        GameObject obj = other.gameObject;

        if (!obj.GetComponent<Defenders>())
        {
            return;
        }
        
        anim.SetBool("Attacking", true);
        attacker.Attack(obj);
        
    }


}
