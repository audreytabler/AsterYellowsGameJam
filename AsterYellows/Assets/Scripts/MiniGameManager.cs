
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
        public int image;
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
    private GameObject specialPlant;

    public static bool enableWilt;

    public TextAsset jsonFile;

    [SerializeField]
    private GameObject textbox;
    private int dialogNum;
    public DialogList dialogList;

    // Start is called before the first frame update
    void Start()
    {
        enableWilt = false;
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
        }
        else if (dialogNum == 2)
            StartCoroutine(startWilt());
        else if (dialogNum == 3)
            StartCoroutine(tryWater(30f));
        else if (dialogNum == 4)
            StartCoroutine(tryWater(36f));
        
        else if (dialogNum == 5){
            enableWilt = true;
            Debug.Log("Speeding up time. . .");
            timeSpeed = 0.05f;
            StartCoroutine(wait(200));
            }
        else if (dialogNum == 6)
        {
            Debug.Log("dialogNum 6");
        }
        /*
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
        startDialog();
    }
    private IEnumerator startWilt()
    {
        float timeWatch = 0.0f;
        while (((PlantMouseClick.plantCount < 15) && (timeWatch < 100f)) ||  ((timeWatch > 140f)))
        {
            timeWatch += timeSpeed;
            yield return null; // Wait for the next frame
        }

        specialPlant = GameObject.Find("Plant(Clone)");
        specialPlant.GetComponent<PlantPhaseController>().tick = 26f;

        timeWatch = 0;
        while ((timeWatch < 10f))
        {
            timeWatch += 0.1f;
            yield return null; // Wait for the next frame
        }
        startDialog();

    }
    private IEnumerator tryWater(float num)
    {
        while (specialPlant.GetComponent<PlantPhaseController>().animator.GetFloat("plant_age") <= num) 
        {
            yield return null; // Wait for the next frame
        }
        startDialog();
    }

    private IEnumerator wait(float num)
    {
        float i = 0;
        while (i < num)
        {
            i += 0.05f;
            yield return null; // Wait for the next frame
        }
        startDialog();
    }

}
