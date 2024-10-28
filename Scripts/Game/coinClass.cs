using UnityEngine;
using System.Collections;

// currency class
public class Currency : MonoBehaviour
{
	// define attributes
	public string currencyName;
	public double monetaryValue;
	Vector3 mousePosition;
	public float moveSpeed = 0.1f;
	RaycastHit2D rb;
	public bool isDragging = false;
    public Transform tableArea;
    public float snapThreshold = .05f;

	// update method
	public void Update()
	{
		// check if left mouse button is clicked and over object
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			// get mouse position in world space
			mousePosition = Input.mousePosition;

			// move mouse to that position
			mousePosition = Camera.main.ScreenToWorldPoint( mousePosition );

			// check if mouse if over object using raycast
			rb = Physics2D.Raycast( mousePosition, Vector2.zero );

			// ensure mouse has hit a collider 
			if ( rb.collider != null && rb.collider.gameObject == gameObject )
			{
				// set isDragging to true
				isDragging = true;
			}
		}

		// check if left mouse button has been released
		if ( Input.GetMouseButtonUp( 0 ) )
		{
			// set isDragging to false
			isDragging = false;

            // snap to collider
            SnapToTable();
		}

		// if dragging is true, move object with mouse
		if ( isDragging )
		{
			// update mouse position
			mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );

			// ensure z component is negative (2D game)
			mousePosition.z = 0;

			// set object position to mouse position to ensure that it follows the cursor
			transform.position = Vector3.Lerp( transform.position, mousePosition, moveSpeed );
		}
	}

    public void SnapToTable()
    {
        // check distance to the table area
        if ( Vector3.Distance( transform.position, tableArea.position ) < snapThreshold )
        {
            // snap to the table's position
            transform.position = tableArea.position;
        }
    }

	// penny class
	public class Penny : Currency
	{
        // initialize using Start function
		void Start()
        {
            currencyName = "Penny";
            monetaryValue = 0.01;
        }
	}

	// nickel class
	public class Nickel : Currency
	{
		 // initialize using Start function
		void Start()
        {
            currencyName = "Nickel";
            monetaryValue = 0.05;
        }
	}

	// dime class
	public class Dime : Currency
	{
		 // initialize using Start function
		void Start()
        {
            currencyName = "Dime";
            monetaryValue = 0.1;
        }
	}

	// quarter class
	public class Quarter : Currency
	{
		 // initialize using Start function
		void Start()
        {
            currencyName = "Quarter";
            monetaryValue = 0.25;
        }
	}

	// one dollar class
	public class OneDollar : Currency
	{
		 // initialize using Start function
		void Start()
        {
            currencyName = "One Dollar";
            monetaryValue = 1.00;
        }
	}

	// five dollar class
	public class FiveDollar : Currency
	{
		 // initialize using Start function
		void Start()
        {
            currencyName = "Five Dollar";
            monetaryValue = 5.00;
        }
	}

	// ten dollar class
	public class TenDollar : Currency
	{
		 // initialize using Start function
		void Start()
        {
            currencyName = "Ten Dollar";
            monetaryValue = 10.00;
        }
	}
}
