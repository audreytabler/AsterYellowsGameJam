
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using DialogDataTypes;
using UnityEngine.SceneManagement;



public class DesktopDialogManager : MonoBehaviour
{
    public TextAsset jsonFile;

    [SerializeField]
    private GameObject textbox;
    private int dialogNum;
    public DialogList dialogList;

    // Start is called before the first frame update
    void Start()
    {
        dialogNum = 0;
        // Deserialize JSON using JsonUtility
        dialogList = JsonConvert.DeserializeObject<DialogList>(jsonFile.text);
        textbox.GetComponent<Dialogue>().StartDialogue(dialogList.dialogList[0]);
    }

    public void endDialog()
    {
        //dialogNum += 1;
        /*if (dialogNum == 1)
        { //wait for first seed
            StartCoroutine(plantCount(1));
        }
        else if (dialogNum == 2)
            StartCoroutine(startWilt());*/
        
        

        //start next dialog


    }
    public void startDialog()
    {
        textbox.GetComponent<Dialogue>().StartDialogue(dialogList.dialogList[dialogNum]);
        dialogNum += 1;
    }

    /*
    private IEnumerator plantCount(int desiredValue)
    {
        while (PlantMouseClick.plantCount != desiredValue)
        {
            //Debug.Log("IEnumberator plantmouseclick is: "+ PlantMouseClick.plantCount);
            yield return null; // Wait for the next frame
        }
        startDialog();
    }*/



  

}
