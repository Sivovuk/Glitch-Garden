using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other){
        
        GameObject obj = other.gameObject;

        if (!obj.GetComponent<Defenders>()) {
            return;
        }

        if (obj.GetComponent<Stone>()){
            anim.SetTrigger("JumoTrigger");
        }
        else {
            anim.SetBool("Attacking", true);
            attacker.Attack(obj);
        }
        
    }

    
}
