using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int instructionID = 0;

    [SerializeField]
    private GameObject instruct1, instruct2, instruct3, instruct4;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level0Test");
    }

    public void nextButt()
    {
        instructionID++;
    }
    public void prevButt()
    {
        instructionID--;
    }

    private void Update()
    {
        switch (instructionID)
        {
            case 1:
                instruct1.SetActive(true); instruct2.SetActive(false); instruct3.SetActive(false); instruct4.SetActive(false);
                break;
            case 2:
                instruct1.SetActive(false); instruct2.SetActive(true); instruct3.SetActive(false); instruct4.SetActive(false);
                break;
            case 3:
                instruct1.SetActive(false); instruct2.SetActive(false); instruct3.SetActive(true); instruct4.SetActive(false);
                break;
            case 4:
                instruct1.SetActive(false); instruct2.SetActive(false); instruct3.SetActive(false); instruct4.SetActive(true);
                break;
            default:
                if (instructionID >= 5)
                {
                    instructionID = 4;
                }
                else if (instructionID < 0)
                {
                    instructionID = 1;
                }
                break;
        }
    }

    public void turnoffall()
    {
        instruct1.SetActive(false); instruct2.SetActive(false); instruct3.SetActive(false); instruct4.SetActive(false);
        instructionID = 0;
    }

}
