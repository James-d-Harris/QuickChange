using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;

// register class
public class Register: MonoBehaviour 
{
    // define attributes

       // balance of what you start with
    public double startingBalance;

       // what is the balance when the level ends
    public double endingBalance;

       // what the currency of the starting cash is
    public List < Currency > allCurrency;

    // creating the currency prefabs and positions

       // pennies
	public GameObject pennyPrefab;
    public GameObject pennyPos;

       // nickels
    public GameObject nicklePrefab;
    public GameObject nicklePos;

       // dimes
    public GameObject dimePrefab;
    public GameObject dimePos;

       // quarters
    public GameObject quarterPrefab;
    public GameObject quarterPos;

       // one dollars
    public GameObject dollarPrefab;
    public GameObject dollarPos;

       // five dollars
    public GameObject fivePrefab;
    public GameObject fivePos;

       // ten dollars
    public GameObject tenPrefab;
	public GameObject tenPos;
       
    // create the canvas
	public Canvas canvas;

	public Dictionary<string, int> currencyCounts;


  // register constructor
  public Register(double startingBalance) {
    // initialize values
    this.startingBalance = startingBalance;
    endingBalance = startingBalance; // can be set later when needed
    allCurrency = new List < Currency > (); // empty list
  }

  void Start()
  {
    // call to put the amount of each coin/bill
    // into the register and into the scene
	populateRegister();
  }

  // method to count drawer balance
  public double CalculateDrawerBalance() {
    // calculate ending balance based on total monetary value in drawer
    // initialize total monetary value
    double currentValue = 0.0;

    // loop through all currency in the register
    foreach(Currency currency in allCurrency) {
      // check to make sure currency not null
      if (currency != null) {
        // update current value
        currentValue += currency.monetaryValue;
      }
    }

    // return current value
    return currentValue;
  }

  // method to give change from register
  public bool GiveChange(double amount) {
    // ensure register has enough funds to give change
    // functions: CalculateDrawerBalance()
    double currentBalance = CalculateDrawerBalance();

    // check if current balance is less than the amount to give back
    if (currentBalance < amount) {
      // notify user
      // functions: Debug.Log
      Debug.LogError("Error, insufficient funds to give exact change.");

      // return false
      return false;
    }

    // create and initialize variable to track reminaing amount of change
    double remainingAmount = amount;

    // loop up to the end of the length of all curency in register
    for (int index = 0; index < allCurrency.Count && remainingAmount > 0; index++) {
      // check that current index of currency array is not null and remaining balance is greater than 0
      if (allCurrency[index] != null && remainingAmount > 0) {
        // initialize variable to track value of currenta currency in register
        double currencyValue = allCurrency[index].monetaryValue;

        // if remaining amount is greater than value of currency
        if (remainingAmount >= currencyValue) {
          // update remaining amount
          remainingAmount -= currencyValue;

          // remove money from register
          allCurrency[index] = null;
        }
      }
    }

    // check if remaining balance is 0
    if (remainingAmount == 0) {
      // update ending balance
      // functions: UpdateEndingBalance()
      UpdateEndingBalance();

      // return true
      return true;
    }

    // otherwise, exact change cannot be given
    // notify user
    // functions: Debug.Log
    Debug.LogError("Error, insufficient funds to give exact change.");

    // return false
    return false;
  }

  // method to update ending balance
  public void UpdateEndingBalance() {

    // update ending balance with current balance
    // functions: CalculateDrawerBalance()
    endingBalance = CalculateDrawerBalance();
  }


  private void populateRegister() 
  {
    // if there is currency currently in the register,
    // clear it out to start with a blank canvas
	allCurrency.Clear();

	CreateCurrencyInstances(pennyPrefab, pennyPos, "Penny");
	CreateCurrencyInstances(nicklePrefab, nicklePos, "Nickle");
	CreateCurrencyInstances(dimePrefab, dimePos, "Dime");
	CreateCurrencyInstances(quarterPrefab, quarterPos, "Quarter");
	CreateCurrencyInstances(dollarPrefab, dollarPos, "Dollar");
	CreateCurrencyInstances(fivePrefab, fivePos, "Five");
	CreateCurrencyInstances(tenPrefab, tenPos, "Ten");

	Debug.Log("Register succesfully populated");
	Debug.Log(allCurrency);
  }


  private void CreateCurrencyInstances(GameObject prefab, GameObject spawnPos, string currencyType) {
	if( currencyCounts.TryGetValue(currencyType, out int count)) {
		for ( int i = 0; i < count; i++ ) {
			Vector3 randomOffset = new Vector3(
                Random.Range(-0.1f, 0.1f), // Adjust range as needed
                Random.Range(-0.1f, 0.1f),
            	0);

			Vector3 worldPosition = spawnPos.transform.position + randomOffset;
			GameObject currencyObject = Instantiate(prefab, worldPosition, prefab.transform.rotation);

			Currency currencyInstance = currencyObject.GetComponent<Currency>();

			if( currencyInstance != null ) {
				allCurrency.Add(currencyInstance);

				Debug.Log(currencyType + " number " + i.ToString() + " has been instantiated succesfully");
			}
		}
	}
  }
}