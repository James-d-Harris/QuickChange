using UnityEngine;
using System.Collections;

// currency class
public class Currency : MonoBehaviour
{
	// define attributes
	public string coinName;
	public double monetaryValue;

	// currency constructor
	public Currency( string name, double value )
	{
		// initialize variables
		this.coinName = name;
		this.monetaryValue = value;
	}

	// penny class
	public class Penny : Currency
	{
		public Penny() : base( "Penny", 0.01 ) { }
	}

	// nickel class
	public class Nickel : Currency
	{
		public Nickel() : base( "Nickel", 0.05 ) { }
	}

	// dime class
	public class Dime : Currency
	{
		public Dime() : base( "Dime", 0.1 ) { }
	}

	// quarter class
	public class Quarter : Currency
	{
		public Quarter() : base( "Quarter", 0.25 ) { }
	}

	// one dollar class
	public class OneDollar : Currency
	{
		public OneDollar() : base( "One Dollar", 1.00 ) { }
	}

	// five dollar class
	public class FiveDollar : Currency
	{
		public FiveDollar() : base( "Five Dollar", 5.00 ) { }
	}

	// ten dollar class
	public class TenDollar : Currency
	{
		public TenDollar() : base( "Ten Dollar", 10.00 ) { }
	}
}
