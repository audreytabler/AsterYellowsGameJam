using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image yellowsImage;

    public string[] lines;
    public float textSpeed;
    public static bool enableActions { get; private set; }

    private int index;
    private bool isTyping = false;
    private int dialogNum;
    

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !isTyping) 
        {
            if (textComponent.text == lines[index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    void StartDialogue()
    {
        enableActions = false;
        index =0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping=false;
    }

    void NextLine()
    {
        if (lines[index][0] == '!')
        {
            Debug.Log("Lines sub 0 is !");
            gameObject.SetActive(false);

            enableActions = true;

        }
        else if (index < lines.Length-1) 
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());

        }
        else
        {
            gameObject.SetActive(false);
            
        }
    }
}
