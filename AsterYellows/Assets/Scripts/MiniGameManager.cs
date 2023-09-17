
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DialogDataTypes;


namespace DialogDataTypes
{
    public class DialogItem
    {
        public Dialog[] dialog;
    }
    public class Dialog
    {
        public string image;
        public string text;
    }
    public class DialogList
    {
        public DialogItem[] dialogList;
    }
}

public class MiniGameManager : MonoBehaviour
{
    
    public float timeSpeed;
    private float prevTimeSpeed;
    
    public TextAsset jsonFile;

    [SerializeField]
    private GameObject textbox;
    private int dialogNum;
    public DialogList dialogList;

    // Start is called before the first frame update
    void Start()
    {
        prevTimeSpeed = timeSpeed;
        dialogNum = 0;

        // Deserialize JSON using JsonUtility
        dialogList = JsonConvert.DeserializeObject<DialogList>(jsonFile.text);
        textbox.GetComponent<Dialogue>().StartDialogue(dialogList.dialogList[0]);
        timeSpeed = 0f;

    }

    public void endDialog()
    {
        dialogNum += 1;
        timeSpeed = prevTimeSpeed;
        if (dialogNum == 1)
        { //wait for first seed
            StartCoroutine(plantCount(1));
            Debug.Log("Passed the coroutine!");


        }
        
        else if (dialogNum == 2)
            StartCoroutine(startWilt());/*
        else if (dialogNum == 3)
            tryWater();
        else if (dialogNum == 4)
            waterAgain();
        else if (dialogNum == 5){
            PlantPhaseController.enableWilt = true;
            getHealingItem();}
        else if (dialogNum == 6)
            speedUpTime();
        else glitchyTime();*/

        //start next dialog


    }
    private void startDialog()
    {
        timeSpeed = 0;
        textbox.GetComponent<Dialogue>().StartDialogue(dialogList.dialogList[dialogNum]);
    }

    private IEnumerator plantCount(int desiredValue)
    {
        while (PlantMouseClick.plantCount != desiredValue)
        {
            //Debug.Log("IEnumberator plantmouseclick is: "+ PlantMouseClick.plantCount);
            yield return null; // Wait for the next frame
        }

        // The static variable has changed to the desired value
        Debug.Log("Static variable has changed to " + desiredValue);
        startDialog();
    }
    private IEnumerator startWilt()
    {
        float timeWatch = 0.0f;
        while (((PlantMouseClick.plantCount < 10) && (timeWatch < 60f)) ||  ((timeWatch > 100f)))
        {
            timeWatch += timeSpeed;
            yield return null; // Wait for the next frame
        }
        /*PlantPhaseController.enableWilt = true;
        Debug.Log("Set wilt to true! waiting...");
        while ((timeWatch < 90f))
        {
            timeWatch += timeSpeed;
            yield return null; // Wait for the next frame
        }*/
        GameObject.Find("Plant(Clone)").GetComponent<PlantPhaseController>().animator.SetFloat("plant_age", 26);

        startDialog();
    }

}
