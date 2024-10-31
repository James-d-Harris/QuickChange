using UnityEngine;
using System.Collections;

// currency class
public class Currency : MonoBehaviour
{
	// Define attributes
	public string currencyName;
	public double monetaryValue;
    public Transform tableArea;
    public float snapThreshold = 0.05f;

	
	private float moveSpeed = 0.1f;
	private bool isDragging = false;
	Vector3 mousePosition;

	// Update method
	private void Update()
	{
		// Check if left mouse button is clicked and over the object
		if (Input.GetMouseButtonDown(0))
		{
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = 0; // Ensure z component is set to zero for 2D

			// Raycast to check if the object was clicked
			RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject == gameObject)
			{
				isDragging = true;
				Debug.Log("Dragging started for " + currencyName);
			}
		}

		// Check if left mouse button is released
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;
			SnapToTable();
			Debug.Log("Dragging stopped for " + currencyName);
		}

		// Move object with mouse while dragging
		if (isDragging)
		{
			// Update mouse position and convert to world space
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePosition.z = 0; // Ensure z component is zero for 2D

			// Move the object to follow the mouse smoothly
			transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
		}
	}

    // Snap the object to the table area if close enough
    public void SnapToTable()
    {
        if (tableArea != null && Vector3.Distance(transform.position, tableArea.position) < snapThreshold)
        {
            transform.position = tableArea.position;
            Debug.Log("Snapped to table area");
        }
    }

	public Currency( string name, double value )
	{
		// initialize variables
		this.currencyName = name;
		this.monetaryValue = value;
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
