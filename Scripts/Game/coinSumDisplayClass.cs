using UnityEngine;
using UnityEngine.UI;  // Add this for the Text component
using System.Collections;
using Unity.VisualScripting;

public class CoinSumDisplay : MonoBehaviour
{
    // Define attributes
    public Text sumDisplay; // UI element for displaying the sum

    public double currentSum; // To track sum of coins counted

    // constructor
    public CoinSumDisplay( CoinSumDisplay coinDisplay )
    {
        sumDisplay = null;
        currentSum = 0.0;
    }

    // Start method
    void Start()
    {
        // Initialize current sum
        currentSum = 0.0;

        // Update the display
        UpdateDisplay();
    }

    // Method to add coins and bills when they are dragged out
    public void AddCoin(Currency money)
    {
        // Update current sum
        currentSum += money.monetaryValue;

        // Update the display
        UpdateDisplay();
    }


    // Method to remove coins and bills when they are dragged out
    public void RemoveCoin(Currency money)
    {
        // Update current sum
        currentSum -= money.monetaryValue;

        // Update the display
        UpdateDisplay();
    }

    // Update the UI display with the new sum
    private void UpdateDisplay()
    {
        sumDisplay.text = "Total: $" + currentSum.ToString("F2");  // Use .text instead of .Text

    }
}