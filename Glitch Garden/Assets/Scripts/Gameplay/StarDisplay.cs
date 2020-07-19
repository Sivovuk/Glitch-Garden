using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text startext;
    public int stars = 100;
    public enum Status {SUCCESS, FAILURE};
    
	void Start () {
        startext = GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddStars(int amount){
            stars += amount;
            UpdateDisplay();
    }

    public Status UseStars(int amount) {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
        
    }

    public void UpdateDisplay() {
        startext.text = stars.ToString();
    }
}
