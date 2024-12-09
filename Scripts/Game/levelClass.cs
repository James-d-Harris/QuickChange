using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelClass : MonoBehaviour
{
    // Create a generalized level string
    public string levelDifficulty;

    // Use the Difficulty Class
    public DifficultyClass difficultyLevel;

    // Deal with setup of the register
    public Register registerCurrency;

    void Start()
    {
        // Initialization of beginning, sets to easy
        difficultyLevel.Start();

        // If the level was set correctly change the generalized level
        if ( difficultyLevel != null )
        {
            levelDifficulty = difficultyLevel.levelDifficulty;
        }

        // Based on the difficulty, populate the register accordingly
        switch (levelDifficulty)
        {
            case "easy":
                registerCurrency.currencyCounts = new Dictionary<string, int>()
                {
                    {"Penny", 50 },
                    {"Nickel",  20 },
                    {"Dime", 15 },
                    {"Quarter", 10 },
                    {"Dollar", 20 },
                    {"Five", 10 },
                    {"Ten", 2 }
                };
                break;

            case "normal":
                registerCurrency.currencyCounts = new Dictionary<string, int>()
                {
                    {"Penny", 100 },
                    {"Nickel",  100 },
                    {"Dime", 50 },
                    {"Quarter", 40 },
                    {"Dollar", 100 },
                    {"Five", 40 },
                    {"Ten", 20 }
                };
                break;

            case "hard":
                registerCurrency.currencyCounts = new Dictionary<string, int>()
                {
                    {"Penny", 200 },
                    {"Nickel",  200 },
                    {"Dime", 100 },
                    {"Quarter", 80 },
                    {"Dollar", 200 },
                    {"Five", 100 },
                    {"Ten", 50 }
                };
                break;
        }
    }
}
