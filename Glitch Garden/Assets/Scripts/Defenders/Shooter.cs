using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject parentProjectile;
    private Animator animator;
    private Spawner myLaneSpawner;

    void Start(){
        animator = GameObject.FindObjectOfType<Animator>();

        //Create parent if necessary
        parentProjectile = GameObject.Find("Projectiles");
        if (!parentProjectile) {
            parentProjectile = new GameObject("Projectiles");
          
        }

        SetMyLaneSpawner();
    }

    void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("Attacking", true);
        }
        else {
            animator.SetBool("Attacking", false);
        }
    }

    void SetMyLaneSpawner() {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray) {
            if (spawner.transform.position.y == transform.position.y) {
                myLaneSpawner = spawner;
                return;
            }
            
        }

        Debug.LogError("Cant find spawner in the lane");
    }

    bool IsAttackerAheadInLane() {
        if (myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        foreach (Transform attackers in myLaneSpawner.transform){
            if (attackers.transform.position.x > transform.position.x) {
                return true;
            }
        }

        //Attackers in lane but behind us
        return false;
    }

    private void Fire() {
        GameObject newProjectile =  Instantiate(projectile);
        newProjectile.transform.parent = parentProjectile.transform;
        newProjectile.transform.position = gun.transform.position;
    }

}
