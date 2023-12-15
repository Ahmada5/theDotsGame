using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainGameDot : MonoBehaviour{
    public GameObject areaObject;
    public GameObject[] objectRandom;
    private RectTransform getRectArea;
    List<Vector2> previousObject = new List<Vector2>();
    private int dummyButton = 1;

   

    void Start(){
        randomObject();
        
    }

    public void randomObject(){
        getRectArea = areaObject.GetComponent<RectTransform>();

        float canvasHeight = getRectArea.rect.height * getRectArea.lossyScale.x;
        float canvasWidth = getRectArea.rect.width * getRectArea.lossyScale.y;

        
        for (int i = 0; i < objectRandom.Length; i++){
            Vector2 randomPosition;
            do{
                float randomX = Random.Range(-canvasWidth / 2.0f, canvasWidth / 2.0f);
                float randomY = Random.Range(-canvasHeight / 2.0f, canvasHeight / 2.0f);
                randomPosition = new Vector2(randomX, randomY);
            } while (!IsPositionValid(randomPosition, previousObject));

            previousObject.Add(randomPosition);
            objectRandom[i].transform.position = randomPosition;
        }       
    }
    bool IsPositionValid(Vector2 position, List<Vector2> previousPositions){
        foreach (Vector2 prevPosition in previousPositions){
            float distance = Vector2.Distance(position, prevPosition);
            if (distance < 2.0f){
                return false; // Position is too close to a previous position
            }
        }
    return true; // Position is valid
    }
    public void ButtonClick(int index){
        if(index == dummyButton){
            dummyButton++;
            Debug.Log($"ok"+", new dummy = "+dummyButton+" ,Array= "+objectRandom.Length);
            objectRandom[index-1].SetActive(false);          
            if(dummyButton-1==objectRandom.Length){
                Debug.Log($"all done");
            }
        }else{
            Debug.Log($"salah");
        }
    }
  
}



    // public void randomObject(){
    //     getRectArea = areaObject.GetComponent<RectTransform>();

    //     float canvasHeight = getRectArea.rect.height * getRectArea.lossyScale.x;
    //     float canvasWidth = getRectArea.rect.width * getRectArea.lossyScale.y;

    //     Debug.Log("area "+canvasHeight+" "+canvasWidth);
        
    //     foreach (GameObject obj in objectRandom){
    //         float ramdomX = Random.Range(-canvasWidth/2, canvasWidth/2);
    //         float ramdomY = Random.Range(-canvasHeight/2, canvasHeight/2);
            
    //         Vector2 randomPosition = new Vector2(ramdomX,ramdomY);
   
    //         obj.transform.position = randomPosition;   
    //     }
    // }