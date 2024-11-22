using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;

// register class
public class Register: MonoBehaviour {
  // define attributes
  public CoinSumDisplay coinSumDisplay;
  public double startingBalance;
  public double endingBalance;
  public List < Currency > allCurrency;

	public GameObject pennyPrefab;
	public GameObject nicklePrefab;
	public GameObject dimePrefab;
	public GameObject quarterPrefab;
	public GameObject dollarPrefab;
	public GameObject fivePrefab;
	public GameObject tenPrefab;

	public GameObject pennyPos;
	public GameObject nicklePos;
	public GameObject dimePos;
	public GameObject quarterPos;
	public GameObject dollarPos;
	public GameObject fivePos;
	public GameObject tenPos;

  public GameObject snapPoint;

	public Canvas canvas;

	private Dictionary<string, int> currencyCounts;


  // register constructor
  public Register(double startingBalance) {
    // initialize values
    this.startingBalance = startingBalance;
    endingBalance = startingBalance; // can be set later when needed
    allCurrency = new List < Currency > (); // empty list
  }

  void Start(){

	currencyCounts = new Dictionary<string, int>() {
		{"Penny", 20},
		{"Nickle", 15},
		{"Dime", 10},
		{"Quarter", 8},
		{"Dollar", 5},
		{"Five", 3},
		{"Ten", 2}
	};


	populateRegister();

  UpdateEndingBalance(); // refresh total balance

  coinSumDisplay.UpdateDisplay(); // update UI
  }

  // add currency and update display
  public void AddCurrency( Currency currency )
  {
      if ( currency != null )
      {
          allCurrency.Add( currency );
          coinSumDisplay.AddCoin( currency ); // updates individual coin addition
          UpdateEndingBalance(); // update total balance
      }
  }

  // remove currency and update display
  public void RemoveCurrency( Currency currency )
  {
      if ( currency != null && allCurrency.Contains( currency ) )
      {
          allCurrency.Remove( currency );
          coinSumDisplay.RemoveCoin( currency ); // update individual coin removal
          UpdateEndingBalance(); // refresh total balance
      }
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
    double endingBalance = CalculateDrawerBalance();

    // display value
    coinSumDisplay.currentSum = endingBalance;

    // refresh UI
    coinSumDisplay.UpdateDisplay();
  }


  private void populateRegister() {
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
        currencyInstance.tableArea = snapPoint.transform;
				allCurrency.Add(currencyInstance);

				Debug.Log(currencyType + " number " + i.ToString() + " has been instantiated succesfully");
			}
		}
	}
  }
}