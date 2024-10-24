using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// register class
public class Register : MonoBehaviour
{
	// define attributes
	public double startingBalance;
	public double endingBalance;
	public List<Currency> allCurrency;

	// register constructor
	public Register( double startingBalance )
	{
		// initialize values
		this.startingBalance = startingBalance;
		endingBalance = startingBalance; // can be set later when needed
		allCurrency = new List<Currency>(); // empty list
	}

	// method to count drawer balance
	public double CalculateDrawerBalance()
	{
		// calculate ending balance based on total monetary value in drawer
			// initialize total monetary value
		double currentValue = 0.0;

		// loop through all currency in the register
		foreach ( Currency currency in allCurrency )
		{
			// check to make sure currency not null
			if ( currency != null )
			{
				// update current value
				currentValue += currency.monetaryValue;
			}
		}

		// return current value
		return currentValue; 
	}

	// method to give change from register
	public bool GiveChange( double amount )
	{
		// ensure register has enough funds to give change
			// functions: CalculateDrawerBalance()
		double currentBalance = CalculateDrawerBalance();

		// check if current balance is less than the amount to give back
		if ( currentBalance < amount )
		{
			// notify user
				// functions: Debug.Log
			Debug.LogError( "Error, insufficient funds to give exact change." );

			// return false
			return false;
		}

		// create and initialize variable to track reminaing amount of change
		double remainingAmount = amount;

		// loop up to the end of the length of all curency in register
		for ( int index = 0; index < allCurrency.Count && remainingAmount > 0; index++ )
		{
			// check that current index of currency array is not null and remaining balance is greater than 0
			if ( allCurrency[ index ] != null && remainingAmount > 0 )
			{
				// initialize variable to track value of currenta currency in register
				double currencyValue = allCurrency[ index ].monetaryValue;

				// if remaining amount is greater than value of currency
				if ( remainingAmount >= currencyValue )
				{
					// update remaining amount
					remainingAmount -= currencyValue;

					// remove money from register
					allCurrency[ index ] = null;
				}
			}
		}

		// check if remaining balance is 0
		if ( remainingAmount == 0 )
		{
			// update ending balance
				// functions: UpdateEndingBalance()
			UpdateEndingBalance();

			// return true
			return true;
		}

		// otherwise, exact change cannot be given
			// notify user
				// functions: Debug.Log
		Debug.LogError( "Error, insufficient funds to give exact change." );

		// return false
		return false;
	}

	// method to update ending balance
	public void UpdateEndingBalance()
	{

		// update ending balance with current balance
			// functions: CalculateDrawerBalance()
		endingBalance = CalculateDrawerBalance();
	}
}

