using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;

public class AcceptanceTesting : MonoBehaviour
{
  /*
  Name: validateRegisterPopulation
  Tests For: validates if register is populating change into register UI
  Parameters: N/A
  Return: void
  */
  void validateRegisterPopulation()
  {
    // stores balance of register after being populated with change
    double populatedBalance;
    // Initial value for register balance
    double emptyRegisterBalance = 0.0;

    // Test register object initialized
    Register testRegister = new Register( emptyRegisterBalance );

    // populates test register with change
    testRegister.populateRegister();

    // Records populated balance
    populatedBalance = testRegister.CalculateDrawerBalance();

    // Log error if register is still empty
    Assert.AreNotEqual( populatedBalance, emptyRegisterBalance, "Error: Register was not populated with change" );
  }

  /*
  Name: checkMaxBoundaries
  Tests For: If customer values are higher than its specified difficulty maximum
  Parameters: N/A
  Return: void
  
  void checkMaxBoundaries()
  {
    // Initializes test level object
    levelClass testLevel;

    // Defines customer balances and tender
    double currentCustomerBalance = testLevel.customer.totalForItems;
    double currentCustomerTender = testLevel.customer.customerMoneyGivenToUser;

    // Defines max values for customer balance and tender
    double maxCustomerBalance = testLevel.levelDifficulty.balanceMax;
    double maxCustomerTender = testLevel.levelDifficulty.tenderMax;

    // Checks for if customer balance is out of bounds
    if( !(currentCustomerBalance < maxCustomerBalance) )
    {
      Debug.LogError("Error: Customer balance out of level difficulty bounds");
    }
    // Checks for if customer tender is out of bounds
    if( !(currentCustomerTender < maxCustomerTender) )
    {
      Debug.LogError("Error: Customer tender out of level difficulty bounds");
    }
  }
*/

  /*
  Name: checkLevelAnswer
  Tests For: If user calculated correct answer
  Parameters: testLevel (levelClass)
  Return: void
  
  void checkLevelAnswer( levelClass testLevel )
  {
    // defines change back solution in a given level
    double changeBackSolution  = testLevel.customer.customerMoneyGivenToUser - testLevel.customer.totalForItems;
    // stores the solution given by the student
    double studentSolution = testLevel.register.CoinSumDisplay.currentSum;

    // Checks user answer in preparation to check feedback
    Assert.AreEqual( studentSolution, changeBackSolution, "Error: Solution incorrectly calculated" );

    // Checks level feedback
    checkLevelFeedback( testLevel, studentSolution, changeBackSolution );
  }
  */
  /*
  Name: checkLevelFeedback
  Tests For: Tests if proper feed back has been given based on student calculated solution
  Parameters: testLevel (levelClass), studentSolution (double), levelSolution (double)
  Return: void
  
  void checkLevelFeedback( levelClass testLevel, double studentSolution, double levelSolution )
  {
    // Stores index of an array that stores feedback messages
    int feedbackIndex;

    // tests if student solution is incorrect
    if( studentSolution < changeBackSolution )
    {
      // Sets feedback index based on student success ( Not enough change )
      feedbackIndex = 0;
    }
    else if( studentSolution > changeBackSolution )
    {
      // Sets feedback index based on student success ( Too much change )
      feedbackIndex = 1;
    }
    // tests is student solution is correct
    else
    {
      // Sets feedback index based on student success ( exact amount of change )
      feedbackIndex = 2;
    }

    // Asserts that feedback has been given
    Assert.AreEqual(testLevel.register.CoinSumDisplay.sumDisplay, testLevel.studentFeedBack[feedbackIndex], "Error: Feedback not given");
  }
  */
  /*
  Name: checkUserInput
  Tests For: listens for user input
  Parameters: N/A
  Return: void
  */
  void checkUserInput()
  {
    // defines 30 second wait time to detect user input
    float waitTimeOutSec = 30f;

    // Starts co-routine for logging recorded input
    StartCoroutine( logRecordedInput( waitTimeOutSec ) );
  }

  /*
  Name: logRecordedInput
  Tests For: Records and reports user input
  Parameters: numOfSeconds (float)
  Return: null (yielded)
  */
  IEnumerator logRecordedInput( float numOfSeconds )
  {
    // recorded input flag
    bool recordedInput = false;
    // timer for user input
    float timer = 0;

    // Loops for a given amount of seconds
    while( timer < numOfSeconds )
    {
      // tests for user input
      if( Input.GetMouseButtonDown(0) )
      {
        // reports user input
        Debug.Log("User Input detected");
        // sets recorded input flag
        recordedInput = true;
      }

      // increments timer
      timer += Time.deltaTime;
      yield return null;
    }

    // tests for recorded input failure
    if ( !recordedInput )
    {
      Assert.AreEqual( true, recordedInput, "Error: User input not detected" );
    }
  }
}
