using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

// customer information
public class customerInfo : MonoBehaviour
{
    // call to difficulty class
    private DifficultyClass difficultyClass;
    public string customerDifficulty;

    // max amount of money a customer can spend
    public double customerMaxMoney;

    // amount of money total items costs
    public double totalForItems;

    // amount of money a customer gives to the user
    public double customerMoneyGivenToUser;

    /* 
     * start is called to store the information of the customer
     * and to have the details of the difficulty stored and used
     * for calculations
    */
    void Start()
    {
        // retrieve the difficulty from the scene
        difficultyClass = FindObjectOfType<DifficultyClass>();

        // set the difficulty and max amount to current level
        customerDifficulty = difficultyClass.levelDifficulty;
        customerMaxMoney = difficultyClass.balanceMax;

        // define what is specified for each level
        switch (customerDifficulty)
        {
            // easy difficulty deals with the simple items and small numbers
            case "easy":
                // get a random amount of items

                // multiply small item by amount

                // add tax to total
                break;

            // normal difficulty deals with larger numbers and more items
            case "normal":
                // get a random amount of items

                // multiply medium item by amount

                // add tax to total
                break;

            // hard difficulty deals with the big items and bigger money total
            case "hard":
                // get a random amount of items

                // multiply large item by amount

                // add tax to total
                break;
        }

        // give a random amount of money between the amount total for the items and
        // max spending given the level
        customerMoneyGivenToUser = GetRandomDouble(1.00, customerMaxMoney + 1.00);
    }

    // get a random value between two specified numbers
    public static double GetRandomDouble(double min, double max)
    {
        System.Random random = new System.Random();
        return min + (random.NextDouble() * (max - min));
    }
}