using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fixingMain : MonoBehaviour{
    public GameObject areaObject, areaCoverFirst, getPrefabsDummy;
    public TMP_Text getTextArray;
    public TMP_InputField getAmountNumbers;
    private GameObject[] prefabsToRandom;
    public GameObject[] setToArray; //objectRandom
    private RectTransform getRectArea;
    List<Vector2> previousObject = new List<Vector2>();
    List<GameObject> createObjectToRandom = new List<GameObject>();
    public timeAndScore getTimeAndScore;

    void Start(){
        prefabsToRandom = new GameObject[0];
        Debug.Log(getPrefabsDummy);
    }

    public void getValueAmountNumber(){
        string inputNumberString = getAmountNumbers.GetComponent<TMP_InputField>().text;
        int.TryParse(inputNumberString, out int inputNumber);
        areaCoverFirst.SetActive(false);

        prefabsToRandom = new GameObject[inputNumber];
        for(int i=0;i<inputNumber;i++){
            getTextArray.text=(i+1).ToString();
            
            prefabsToRandom[i]=Instantiate(getPrefabsDummy, GameObject.FindGameObjectWithTag("cloneIsHere").transform);
            
            createObjectToRandom.Add(prefabsToRandom[i]);

            getClone getClonethis = prefabsToRandom[i].GetComponent<getClone>();
            if (getClonethis != null){
                getClonethis.myVal = i;
            }
        }
        setToArray=createObjectToRandom.ToArray();
        randomObject(setToArray);   

        getTimeAndScore.startTheTime();
    }

    public void randomObject(GameObject[] x){
        getPrefabsDummy.SetActive(false);
        getRectArea = areaObject.GetComponent<RectTransform>();

        float canvasHeight = getRectArea.rect.height * getRectArea.lossyScale.x;
        float canvasWidth = getRectArea.rect.width * getRectArea.lossyScale.y;
        
        for (int i = 0; i < x.Length; i++){
            Vector2 randomPosition;
            do{
                float randomX = Random.Range(-canvasWidth / 2.0f, canvasWidth / 2.0f);
                float randomY = Random.Range(-canvasHeight / 2.0f, canvasHeight / 2.0f);
                randomPosition = new Vector2(randomX, randomY);
            } while (!IsPositionValid(randomPosition, previousObject));

            previousObject.Add(randomPosition);
            x[i].transform.position = randomPosition;
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
}