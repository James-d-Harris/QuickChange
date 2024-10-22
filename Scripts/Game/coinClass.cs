/*
Work in progress, check with James code in GitHub
*/

using UnityEngine;
using System.Collections;

// currency class
public class Currency : MonoBehaviour
{
	// penny class
	public class Penny
	{
		// define attributes
		public string name;
		public double monetaryValue;

		// penny constructor
		public Penny()
		{
			// initialize attributes
			name = "Penny";
			monetaryValue = .01;
		}
	}

	// nickel class
	public class Nickel
	{
		// define attributes
		public string name;
		public double monetaryValue;

		// nickel constructor
		public Nickel()
		{
			// initialize attributes
			name = "Nickel";
			monetaryValue = .05;
		}
	}

	// dime class
	public class Dime
	{
		// define attributes
		public string name;
		public double monetaryValue;

		// dime constructor
		public Dime()
		{
			// initialize attributes
			name = "Dime";
			monetaryValue = .1;
		}
	}

	// quarter class
	public class Quarter
	{
		// define attributes
		public string name;
		public double monetaryValue;

		// quarter constructor
		public Quarter()
		{
			// initialize attributes
			name = "Quarter";
			monetaryValue = .25;
		}
	}

	// dollar class
	public class OneDollar
	{
		// define attributes
		public string name;
		public double monetaryValue;

		// dollar constructor
		public OneDollar()
		{
			// initialize attributes
			name = "One Dollar";
			monetaryValue = 1.00;
		}
	}

		// five dollar class
	public class FiveDollar
	{
		// define attributes
		public string name;
		public double monetaryValue;

		// five dollar constructor
		public FiveDollar()
		{
			// initialize attributes
			name = "Five Dollar";
			monetaryValue = 5.00;
		}
	}

		// ten dollar class
	public class TenDollar
	{
		// define attributes
		public string name;
		public double monetaryValue;

		// ten dollar constructor
		public TenDollar()
		{
			// initialize attributes
			name = "Ten Dollar";
			monetaryValue = 10.00;
		}
	}

	// method to create currency
	public object createCurrency( string currencyType )
	{
		// switch statement to detect currencyType
		switch ( currencyType )
		{
			// penny CASE
			case "Penny":
				return new Penny();

			// nickel CASE
			case "Nickel":
				return new Nickel();

			// dime CASE
			case "Dime":
				return new Dime();

			// quarter CASE
			case "Quarter":
				return new Quarter();

			// one dollar CASE
			case "OneDollar":
				return new OneDollar();

			// five dollar CASE
			case "FiveDollar":
				return new FiveDollar();

			// ten dollar case
			case "TenDollar":
				return new TenDollar():

			// default CASE ( unknown )
			default:
				Debug.Log( "Uknown currenty type." );
				return null;
		}
	}
}
