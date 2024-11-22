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
    public Register register;

    // Current customer information for level
    public customerInfo customer;

    // Calculates the current solution between the customers tender and item total (done in start method)
    public double currentSolution;

    // Array of feedback messages to be displayed when solution is checked
    public string[] studentFeedBack = new string[]
    {
      "Not enough change",
      "Too much change",
      "Great Job!"
    };

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
        currentSolution = customer.customerMoneyGivenToUser - customer.totalForItems;
    }

  void checkSolutionFeedback()
  {
    // Current Sum dragged out by the student
    double coinSum = register.CoinSumDisplay.currentSum;

    // Text component of coinDisplay on register
    Text messageDisplay = register.CoinSumDisplay.sumDisplay;

    // tests if student has dragged out too little change, or too much, correct amount otherwise
    if (coinSum < currentSolution)
    {
      // Co-routine for not enough change
      StartCoroutine(addFiveSecFeedback(messageDisplay, coinSum, studentFeedBack[0], 5));
    }
    else if (coinSum > currentSolution)
    {
      // co-routine for too much change
      StartCoroutine(addFiveSecFeedback(messageDisplay, coinSum, studentFeedBack[1], 5));
    }
    else
    {
      // co-routine for the correct amount of change
        StartCoroutine(addFiveSecFeedback(messageDisplay, coinSum, studentFeedBack[2], 5));
    }
  }

  IEnumerator addFiveSecFeedback( Text display, double currentCoinSum, string feedback, float duration )
  {
    // Displays feedback on coin sum display
    display.text = feedback;

    // Waits for 5 seconds
    yield return new WaitForSeconds(duration);

    // continues displaying coin sum
    display.text = currentCoinSum;
  }
}
