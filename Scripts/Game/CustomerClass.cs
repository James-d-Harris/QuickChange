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

        // get a random amount of items
        System.Random rand = new System.Random();

        int numItems = rand.Next(1, 11);



        // define what is specified for each level
        switch (customerDifficulty)
        {
            // easy difficulty deals with the simple items and small numbers
            case "easy":
                // create a new instance of small item to use the information
                ItemClass.smallItem smallItemInstance = new ItemClass.smallItem();

                // multiply small item by amount
                totalForItems = smallItemInstance.monetaryValue * numItems;

                // add tax to total
                totalForItems = totalForItems * 1.1;
                break;

            // normal difficulty deals with larger numbers and more items
            case "normal":
                // create a new instance of medium item to use the information
                ItemClass.mediumItem mediumItemInstance = new ItemClass.mediumItem();

                // multiply small item by amount
                totalForItems = mediumItemInstance.monetaryValue * numItems;

                // add tax to total
                totalForItems = totalForItems * 1.1;
                break;

            // hard difficulty deals with the big items and bigger money total
            case "hard":
                // create a new instance of small item to use the information
                ItemClass.largeItem largeItemInstance = new ItemClass.largeItem();

                // multiply small item by amount
                totalForItems = largeItemInstance.monetaryValue * numItems;

                // add tax to total
                totalForItems = totalForItems * 1.1;
                break;
        }

        // give a random amount of money between the amount total for the items and
        // max spending given the level
        customerMoneyGivenToUser = GetRandomDouble(totalForItems + 1.00, customerMaxMoney + 1.00);
    }

    // get a random value between two specified numbers
    public static double GetRandomDouble(double min, double max)
    {
        System.Random random = new System.Random();
        return min + (random.NextDouble() * (max - min));
    }
}