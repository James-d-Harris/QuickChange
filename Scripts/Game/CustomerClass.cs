using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class customerInfo : MonoBehaviour
{
    private DifficultyClass difficultyClass;
    public string customerDifficulty;
    public double customerMaxMoney;
    public double customerMoneyGiven;

    void Start()
    {
        difficultyClass = FindObjectOfType<DifficultyClass>();

        customerDifficulty = difficultyClass.levelDifficulty;
        customerMaxMoney = difficultyClass.balanceMax;

        switch (customerDifficulty)
        {
            case "easy":
                
                break;
            case "normal":
                
                break;
            case "hard":
                
                break;
        }

        customerMoneyGiven = GetRandomDouble(1.00, customerMaxMoney + 1.00);
    }

    public static double GetRandomDouble(double min, double max)
    {
        System.Random random = new System.Random();
        return min + (random.NextDouble() * (max - min));
    }
}