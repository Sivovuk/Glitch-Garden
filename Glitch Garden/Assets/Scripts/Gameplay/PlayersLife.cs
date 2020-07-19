using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersLife : MonoBehaviour {

    private int hitCounts = 3;
    private static int numberOfHouses = 5;

    public GameObject houseLifes;
    public GameObject[] fire;

    void OnTriggerEnter2D(Collider2D other){

        Attacker attacker = other.GetComponent<Attacker>();

        if (attacker && hitCounts > 0)
        {
            fire[hitCounts].SetActive(true);
            hitCounts--;
            Destroy(other.gameObject);
        }
        else if(attacker && hitCounts <= 0) {
            numberOfHouses--;
            houseLifes.GetComponentInChildren<Text>().text = numberOfHouses.ToString();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
