using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectDefender;

    private Buttons[] buttonArray;
    private Text costText;
    
	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Buttons>();

        costText = GetComponentInChildren<Text>();
        if (!costText) {
            Debug.LogWarning(name + "No cost text!");
        }

        costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnMouseDown(){
        foreach (Buttons thisButton in buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectDefender = defenderPrefab;
    }

}
