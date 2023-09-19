using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlitchyMode : MonoBehaviour
{
    public ShaderEffect_BleedingColors bleedingColors;
    public ShaderEffect_CorruptedVram corruptedVram;
    public ShaderEffect_Unsync unsync;
    public Camera cam;
    public GameObject textbox;
    public GameObject yellows;
    public GameObject bgAudioObject;
    public AudioSource glitchyNoise;
    //private Random RandGenerator;

    // Start is called before the first frame update
    private void Start()
    {
        cam.transform.position = SetZ(cam.transform.position, -10);
        corruptedVram.enabled = false;
        bleedingColors.enabled = false;
        yellows.SetActive(false);


    }
    public void GlitchyTime()
    {
        bgAudioObject.SetActive(false);
        corruptedVram.enabled = true;
        bleedingColors.enabled = true;
        StartCoroutine(startGlitches());
     
    }

    IEnumerator startGlitches()
    {
        glitchyNoise.Play();
        for (int i = 0; i < 20; i++)
        {
            corruptedVram.shift -= 0.2f;
           // bleedingColors.intensity += 0.5f;
            bleedingColors.shift += 0.2f;
            unsync.speed -= 0.4f;
            yield return null;
        }
        for (int i = 0; i < 20; i++)
        {
            corruptedVram.shift += 0.4f;
            //bleedingColors.intensity -= 0.5f;
            bleedingColors.shift -= 0.4f;
            unsync.speed += 0.8f;
            yield return null;
        }
        for (int i = 0; i < 20; i++)
        {
            corruptedVram.shift -= 0.2f;
            //bleedingColors.intensity -= 0.5f;
            bleedingColors.shift += 0.2f;
            unsync.speed -= 0.4f;
            yield return null;
        }
        cam.transform.position = SetZ(cam.transform.position, 10);
        textbox.SetActive(false);
        yellows.SetActive(true);
        for (int i = 0; i < 20; i++)
        {
            corruptedVram.shift -= 0.2f;
            // bleedingColors.intensity += 0.5f;
            bleedingColors.shift += 0.2f;
            unsync.speed -= 0.4f;
            yield return null;
        }
        for (int i = 0; i < 20; i++)
        {
            corruptedVram.shift += 0.4f;
            //bleedingColors.intensity -= 0.5f;
            bleedingColors.shift -= 0.4f;
            unsync.speed += 0.8f;
            yield return null;
        }
        for (int i = 0; i < 20; i++)
        {
            corruptedVram.shift -= 0.2f;
            //bleedingColors.intensity -= 0.5f;
            bleedingColors.shift += 0.2f;
            unsync.speed -= 0.4f;
            yield return null;
        }
        cam.transform.position = SetZ(cam.transform.position, 11);

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadSceneAsync("Desktop");
        SceneManager.UnloadSceneAsync("MiniGame");


    }

    Vector3 SetZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    }

}
