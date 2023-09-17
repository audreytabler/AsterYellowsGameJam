using UnityEngine;
using DialogDataTypes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image yellowsImage;
    public TextAsset textFile;

    private DialogItem lines;
    public float textSpeed;
    public static bool enableActions { get; private set; }

    private int index;
    private bool isTyping = false;

    

    // Start is called before the first frame update
    void Start()
    {
        int index = 0;
        //textComponent.text = string.Empty;
        //StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isTyping) 
        {
            if (textComponent.text == lines.dialog[index].text) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines.dialog[index].text;
            }
        }
    }
    public void StartDialogue(DialogItem stringArray)
    {
       
        textComponent.text = string.Empty;
        gameObject.SetActive(true);
        lines = stringArray; 
        enableActions = false;
        index =0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        Debug.Log(lines.dialog[index].text);
        isTyping = true;
        foreach (char c in lines.dialog[index].text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping=false;
    }

    void NextLine()
    {
        /*if (lines[index].Equals("!"))
        {

            dialogNum += 1;
            gameObject.SetActive(false);

            enableActions = true;

        }
        else*/ if (index < lines.dialog.Length-1) 
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());

        }
        else
        {
            gameObject.SetActive(false);
            FindObjectOfType<MiniGameManager>().endDialog();

            enableActions = true;

        }
    }

}
