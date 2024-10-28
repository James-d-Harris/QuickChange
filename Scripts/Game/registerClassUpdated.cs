using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;

// register class
public class Register: MonoBehaviour {
  // define attributes
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

	public Collider2D pennyCollider;
	public Collider2D nickleCollider;
	public Collider2D dimeCollider;
	public Collider2D quarterCollider;
	public Collider2D dollarCollider;
	public Collider2D fiveCollider;
	public Collider2D tenCollider;

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


  private void populateRegister() {
	allCurrency.Clear();

	CreateCurrencyInstances(pennyPrefab, pennyCollider, "Penny");
	CreateCurrencyInstances(nicklePrefab, nickleCollider, "Nickle");
	CreateCurrencyInstances(dimePrefab, dimeCollider, "Dime");
	CreateCurrencyInstances(quarterPrefab, quarterCollider, "Quarter");
	CreateCurrencyInstances(dollarPrefab, dollarCollider, "Dollar");
	CreateCurrencyInstances(fivePrefab, fiveCollider, "Five");
	CreateCurrencyInstances(tenPrefab, tenCollider, "Ten");

	Debug.Log("Register succesfully populated");
  }


  private void CreateCurrencyInstances(GameObject prefab, Collider2D collider, string currencyType) {
	if( currencyCounts.TryGetValue(currencyType, out int count)){
		for ( int i = 0; i < count; i++ ) {
			Vector3 worldPosition = GetRandomPositionInCollider(collider);
			GameObject currencyObject = Instantiate(prefab, worldPosition, prefab.transform.rotation);

			RectTransform rectTransform = currencyObject.GetComponent<RectTransform>();
			if( rectTransform != null ) {
				Vector2 canvasPosition;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(
					canvas.GetComponent<RectTransform>(),
					Camera.main.WorldToScreenPoint(worldPosition),
					canvas.worldCamera,
					out canvasPosition
				);

				rectTransform.anchoredPosition = canvasPosition;
				rectTransform.localScale = Vector3.one;
			}

			Currency currencyInstance = currencyObject.GetComponent<Currency>();

			if( currencyInstance != null ) {
				allCurrency.Add(currencyInstance);

				Debug.Log(currencyType + " number " + i.ToString() + " has been instantiated succesfully");
			}
		}
	}
  }

  private Vector3 GetRandomPositionInCollider(Collider2D collider) {
	Bounds bounds = collider.bounds;
	float randomX = Random.Range(bounds.min.x, bounds.max.x);
	float randomY = Random.Range(bounds.min.y, bounds.max.y);
	return new Vector3(randomX, randomY, 0);
  }
}