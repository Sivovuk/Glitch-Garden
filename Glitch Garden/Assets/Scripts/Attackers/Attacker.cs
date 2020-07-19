using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
    
    
    private float currSpeed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currSpeed * Time.deltaTime);
        if (!currentTarget) {
            animator.SetBool("Attacking", false);
        }


	}
    

    public void SetSpeed(float speed) {
        currSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage) {
        
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDemage(damage);
            }
        }
    }

    public void Attack(GameObject obj){
        currentTarget = obj;
    }

}
