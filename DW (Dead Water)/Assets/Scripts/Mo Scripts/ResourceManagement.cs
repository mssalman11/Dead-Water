using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceManagement : MonoBehaviour
{
    public static ResourceManagement Instance {  get; private set; }

    public bool nextMove;

    public int totalCoins;

    public GameObject charSelectUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentChar = SelectedChar.NONE;
    }

    public void addCoins(int c)
    {
        totalCoins += c;
    }

    public void removeCoins(int c) 
    { 
        totalCoins -= c;
    }

    private int totalCoinNumber()
    {
        return totalCoins;
    }

    //For when the battle ends
    public void isBattleOver()
    {
        if (BattleSystem.isEnemyDead)
        {
            nextMove = true;
        }
    }

    //These are the codes of the character selection. Each character will be represented by an enum.
    //Each enum will represent the character that the player selects.
    public enum SelectedChar
    {
        NONE,
        MICHIGAN,
        RAINIER,
        COLBALT
    }

    public SelectedChar currentChar;

    //Selects Michigan
    public void OnMichiganSelect()
    {
        currentChar = SelectedChar.MICHIGAN;
        Time.timeScale = 1;
        charSelectUI.SetActive(false);
    }
    //Selects Rainier
    public void OnRainierSelect()
    {
        currentChar = SelectedChar.RAINIER;
        Time.timeScale = 1;
        charSelectUI.SetActive(false);
    }
    //Selects Colbalt
    public void OnColbaltSelect()
    {
        currentChar = SelectedChar.COLBALT;
        Time.timeScale = 1;
        charSelectUI.SetActive(false);
    }

    //Spawns a temporary Menu before the game starts.
    public void CharSelection()
    {
        charSelectUI.SetActive(true);
        Time.timeScale = 0;
    }
}
