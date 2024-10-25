using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level0Test");
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadCharacterMenu()
    {
        SceneManager.LoadScene("Characters_Leland");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenus");
    }
}
