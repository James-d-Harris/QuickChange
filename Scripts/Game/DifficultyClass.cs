using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
   This difficulty class is meant to define a difficulty in each level of QuickChange 
   by providing set maximum values for key elements that which math operations should 
   be taken on.
*/

public class DifficultyClass : MonoBehaviour
{
    public string levelDifficulty; // String meant to be set to easy, normal, or hard

    // Maximum Values for customer tender and balance of payment of each problem 
    public double balanceMax;
    public double tenderMax;

    // constructor
    public DifficultyClass( DifficultyClass difficulty )
    {
        balanceMax = 0.0;
        tenderMax = 0.0;
    }

    // Start is called before the first frame update
    void Start()
    {
        initializeDifficulty();
    }

    // Update is called once per frame
    void Update()
    {

        // switch/case defines maximum values at each difficulty level
        string updateDifficulty = levelDifficulty;
        switch (updateDifficulty)
        {
            case "easy":
               balanceMax = 99.0;
               tenderMax = 100.0;
               break;
            case "normal":
               balanceMax = 499.0;
               tenderMax = 500.0;
               break;
            case "hard":
               balanceMax = 999.0;
               tenderMax = 1000.0;
               break;
            default:
               Debug.LogError("Invalid Difficulty");
               break;
        }
    }

    public void initializeDifficulty()
    {
        levelDifficulty = "easy";
    }

    public void setDifficulty( string levelSetting )
    {
        levelDifficulty = levelSetting.ToLower();
    }

    public string getDifficulty()
    {
        return levelDifficulty;
    }

    public double getBalanceMax()
    {
        return balanceMax;
    }

    public double getTenderMax()
    {
        return tenderMax;
    }

    public bool validateDifficulty( double balance, double tender )
    {
        // Checks if problem parameters are within correct range
        return balance <= balanceMax && tender <= tenderMax;
    }

    public void increaseDifficulty()
    {
        // Increases each possible difficulty setting by one level
        switch (levelDifficulty)
        {
            case "easy":
               levelDifficulty = "normal";
               break;
            case "normal":
               levelDifficulty = "hard";
               break;
            // Logs errors for invalid logic
            case "hard":
               Debug.Log("Already at Maximum difficulty");
               break;
            default:
               Debug.LogError("Invalid Difficulty");
               break;
        }
    }

    public void decreaseDifficulty()
    {
        // Decreases each possible difficulty setting by one level
        switch (levelDifficulty)
        {
            case "hard":
               levelDifficulty = "normal";
               break;
            case "normal":
               levelDifficulty = "easy";
               break;
            // Logs errors for invalid logic
            case "easy":
               Debug.Log("Already at Minimum difficulty");
               break;
            default:
               Debug.LogError("Invalid Difficulty");
               break;
        }
    }
}
