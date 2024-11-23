// header files
using UnityEngine;
using TMPro;
using System.Collections.Generic;

// tray class
public class Tray : MonoBehaviour
{
    // declare attributes
    public CoinSumDisplay coinSumDisplay;
    private List<double> coinsInTray = new List<double>();
    

    // start
    void Start()
    {
        // initialize coin sum display
        if ( coinSumDisplay != null )
        {
            coinSumDisplay.UpdateDisplay();
        }

        // otherwise, raise warning
        else
        {
            Debug.LogWarning( "CoinSumDisplay not assigned." );
        }
    }

    // method to add coin to tray
    public void AddCoin( double coinValue )
    {
        // create new Coin object
        GameObject testObject = new GameObject( "Coin" );
        Currency newCoinObject = testObject.AddComponent<Currency>();

        // initialize new coin
        newCoinObject.name = "Coin";
        newCoinObject.monetaryValue = coinValue;

        // add coin value to tray
        coinsInTray.Add( coinValue );

        // add coin value to coin sum display
        coinSumDisplay.AddCoin( newCoinObject );

        // update display
        coinSumDisplay.UpdateDisplay();
    }
}