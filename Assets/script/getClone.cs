using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getClone : MonoBehaviour{

    public GameObject thisClone;
    public int myVal;
    private int dummyButton = 0;
    public timeAndScore getTheScoreScript;
    public fixingMain getFixingMain;

 
    private void Start()
    {
        PlayerPrefs.DeleteKey("dummyButton");
        Debug.Log(getFixingMain.setToArray.Length);
    }

    private void Update()
    {
        dummyButton=PlayerPrefs.GetInt("dummyButton");
        //Debug.Log(dummyButton);
    }

    public void getButtonClick(){
        ButtonClick(myVal);
    }
    public void ButtonClick(int setValueButton){
        Debug.Log(myVal);
        
         if(setValueButton == dummyButton){
            if(dummyButton<getFixingMain.setToArray.Length-1){
                dummyButton++;
                Debug.Log($"new dummy "+dummyButton);
            }else{
                Debug.Log($"dummy stay "+dummyButton);
            }
            
           
            
            thisClone.SetActive(false);
            PlayerPrefs.SetInt("dummyButton", dummyButton);
            PlayerPrefs.Save();
            if(dummyButton==myVal){
                Debug.Log($"All DOne");
                getTheScoreScript.gameEndStopCounts();
            }else{
                Debug.Log($"belum selesai");
            }
            

        }else{
            Debug.Log($"salah");
            PlayerPrefs.DeleteKey("dummyButton");
            SceneManager.LoadScene("mainMenu");
        }
        
    }

}
