using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;

    public void DealDemage(float damage) {
        health -= damage;
        if (health < 0) {
            //animacija za umiranje
            DestroyObject();
        }
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }
}
