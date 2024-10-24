using UnityEngine;
using System.Collections;

public class CoinSumDisplay : MonoBehaviour
{
    // define attributes
    public Text sumDisplay; // UI element
    private double currentSum // to track sum of coins counted

    // start method
    void Start()
    {
        // initialize current sum
        currentSum = 0.0;

        // update the display
        UpdateDisplay();
    }

    // method to add coins and bills when they are dragged out
    public void AddCoin ( Currency money )
    {
        // update current sum
        currentSum += money.monetaryValue;

        // update the display
        UpdateDisplay();
    }

    // update the UI display with the nwe sum
    private void UpdateDisplay()
    {
        sumDisplay.Text = "Total: $" + currentSum.ToString( "F2" );
    }
}