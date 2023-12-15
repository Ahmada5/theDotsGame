using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeAndScore : MonoBehaviour{
    public float timeOfGame=0.00f;
    public TMP_Text showTimes, teksEndShow;
    public GameObject endShow;
    bool startTheTimeCount;

    private void Start(){
        endShow.SetActive(false);   
        startTheTimeCount=false;
        updateTheTimes();
    }
    public void startTheTime(){
        startTheTimeCount=true;
    }

    private void Update(){   
        if(startTheTimeCount){
            timeOfGame+=0.01f;
            timeOfGame=Mathf.Round(timeOfGame * 100.0f)/100.0f;
            updateTheTimes();
        }
    }
    private void updateTheTimes(){
        showTimes.text=timeOfGame.ToString("0.00");
    }

    public void gameEndStopCounts(){
        startTheTimeCount=false;
        endShow.SetActive(true);
        teksEndShow.text=timeOfGame.ToString("0.00");
    }
}
