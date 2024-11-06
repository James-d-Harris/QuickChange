using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static Currency; // added to use Penny class

/*
This Automated Testing class is meant to test all public class methods with a
definitive outcome
*/

public class AutomatedTesting : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
    }

    // Automated Testing

    // CoinSumDisplay
    /*
    Function Test: AddCoin
    Behavior: Tests if a given sum display is properly adding coin value to the current sum
    Parameters: testDisplay (CoinSumDisplay) testCoin (Currency)
    Return Type: Void
    Issues: Current Sum value within the coin sum display is a private value and is
            inaccessible. We could either make the currentSum public, or create a
            way to retrieve value
    */
    public void testAddCoin( CoinSumDisplay coinDisplay, Currency testCoin )
    {
      CoinSumDisplay testDisplay = new CoinSumDisplay( coinDisplay );
      double result = testDisplay.currentSum + testCoin.monetaryValue;

      // Adds chosen coin monetary value to test display sum
      testDisplay.AddCoin( testCoin );

      // Tests if expected result is reflected in test display sum
      Assert.AreEqual( result, testDisplay.currentSum,
                                "Error: Coin Sum display is not adding coins" );
      testDisplay = NULL;
    }

    // Difficulty
    /*
    Function Test: setDifficulty
    Behavior: Accepts a difficulty level to be set to a given difficutly class,
              and logs errors in case of the difficulty level not being set,
              and if the difficulty level is recording invalid input
    Parameters: testDifficulty (DifficultyClass), testLevel (String)
    Return Type: Void
    */
    public void testSetDifficulty( DifficultyClass difficulty, string testLevel )
    {
      DifficultyClass testDifficulty = new DifficultyClass( difficulty );
      string invalidDifficultyLevel = "";

      // Tests for successful test level setting
      testDifficulty.setDifficulty( testLevel );
      Assert.AreEqual( testDifficulty.levelDifficulty, testLevel,
                                   "Error: Difficulty level was not set" );

      // Tests for if invalid difficulty levels can be set
      testDifficulty.setDifficulty( invalidDifficultyLevel );
      Assert.AreNotEqual( testDifficulty.levelDifficulty, invalidDifficultyLevel,
                     "Error: Difficulty level can be set to invalid settings" );
      testDifficulty = NULL;
    }

    /*
    Function Test: getDifficulty
    Behavior: Tests if the current difficulty level is retrievable from tested
              object
    Parameters: testDifficulty (DifficultyClass)
    Return Type: Void
    */
    public void testGetDifficulty( DifficultyClass difficulty )
    {
      DifficultyClass testDifficulty = new DifficultyClass( difficulty );
      string result = testDifficulty.getDifficulty();

      Assert.AreEqual( result, testDifficulty.levelDifficulty,
                                    "Error: Difficulty level not retrievable" );
      testDifficulty = NULL;
    }

    /*
    Function Test: increaseDifficulty
    Behavior: Re-initializes difficulty object and tests the success of
              increasing difficulty to desired difficulty level
    Parameters: testDifficulty (DifficultyClass), testLevel (string)
    Return Type: Void
    */
    public void testIncreaseDifficulty( DifficultyClass difficulty, string testLevel )
    {
      DifficultyClass testDifficulty = new DifficultyClass( difficulty );
      // Initializes difficulty level to 'easy'
      testDifficulty.initializeDifficulty();

      // Manipulates difficulty level based on testLevel setting
      switch (testLevel.ToLower())
      {
        case "hard":
           testDifficulty.increaseDifficulty();
           testDifficulty.increaseDifficulty();
           break;

        case "normal":
           testDifficulty.increaseDifficulty();
           break;

        default:
            Debug.LogError( "Invalid test difficulty level" );
            break;
      }

      // Determines if testLevel setting matches increased difficulty
      Assert.AreEqual( testLevel, testDifficulty.getDifficulty(),
                       "Error: Difficulty level not increased to test level" );
      testDifficulty = NULL;
    }

    /*
    Function Test: decreaseDifficulty
    Behavior: Re-initializes difficulty level, then sets the difficulty to
              hard. Tests for success of decreasing difficulty level to
              desired difficulty level
    Parameters: testDifficulty (DifficultyClass), testLevel (String)
    Return: Void
    */
    public void testDecreaseDifficulty( DifficultyClass difficulty, string testLevel )
    {
      DifficultyClass testDifficulty = new DifficultyClass( difficulty );

      // Initializes difficulty and then sets difficulty level to 'hard'
      testDifficulty.initializeDifficulty();
      testDifficulty.setDifficulty("hard");

      // Manipulates difficulty level based on testLevel setting
      switch (testLevel.ToLower())
      {
        case "easy":
           testDifficulty.decreaseDifficulty();
           testDifficulty.decreaseDifficulty();
           break;

        case "normal":
           testDifficulty.decreaseDifficulty();
           break;

        default:
           Debug.LogError( "Invalid test difficulty level" );
           break;
      }

      // Determines if testLevel setting matches decreased difficulty
      Assert.AreEqual( testLevel, testDifficulty.getDifficulty(),
                                      "Error: Difficulty level not decreased" );
      testDifficulty = NULL;
    }

    // RegisterClass

    /*
    Function Test: CalculateDrawerBalance
    Behavior: Checks if CalculateDrawerBalance accurately calculates current
              balance in register
    Parameters: registerInstance (Register)
    Return: Void
    */

    public void testCalculateDrawerBalance( Register registerInstance )
    {
      double balanceResult = 0.0;
      int index = 0;

      while( registerInstance.allCurrency[index + 1] != NULL )
      {
        balanceResult += registerInstance.allCurrency[index].monetaryValue;
      }

      Assert.AreEqual( balanceResult, registerInstance.CalculateDrawerBalance(),
                            "Error: Drawer balance is incorrectly calculated" );
    }

    // Student

    /*
    Function Test: addSuccess
    Behavior: Tests if addSuccess properly increments successful levels
    Parameters: student (Student)
    Return: Void
    */
    public void testAddSuccess( Student student )
    {
      Student testStudent = new Student( student );
      int result = testStudent.getSuccessfulLevels() + 1;

      testStudent.addSuccess();

      Assert.AreEqual( result, testStudent.getSuccessfulLevels(),
                                         "Error: Success level was not added" );
      testStudent = NULL;
    }

    /*
    Function Test: addFailure
    Behavior: Tests if addFailure properly increments failed levels
    Parameters: student (Student)
    Return: Void
    */
    public void testAddFailure( Student student )
    {
        Student testStudent = new Student( student );
        int result = testStudent.getFailedLevels() + 1;

        testStudent.addFailure();

        Assert.AreEqual( result, testStudent.getFailedLevels(), "Error: Failed level was not added" );
        testStudent = null;
    }

    /*
    Function Test: adjustDifficulty
    Behavior: Tests if adjustDifficulty properly increments or decrements
              difficulty levels based on student success
    Parameters: student (Student), success (bool)
    Return: Void
    */
    public void testAdjustDifficulty( Student student, bool success )
    {

      Student testStudent = new Student( student );
      string currentDifficultyLevel = testStudent.currentDifficulty.getDifficulty();
      string result;

      // determines whether difficulty level needs to be increased or decreased
      if( success )
      {
        switch ( currentDifficultyLevel )
        {
          case "easy":
             result = "normal";
          case "normal":
             result = "hard";
        }
      }
      else
      {
        switch ( currentDifficultyLevel )
        {
          case "hard":
             result = "normal";
          case "normal":
             result = "easy";
        }
      }

      testStudent.adjustDifficulty( success );
      Assert.AreEqual( result, testStudent.currentDifficulty.getDifficulty(), "Error: Student difficulty not adjusted" );

      testStudent = null;
    }

    // Teacher

    /*
    Function Test: addStudent
    Behavior: Tests if addStudent successfully adds student to list
    Parameters: listOfStudents (List<Student>), student (Student)
    Return: Void
    */
    public void testAddStudent( List<Student> listOfStudents, Student student )
    {
      if( !listOfStudents.contains( student ) )
      {
        Debug.LogError( "Error: Student is not found in list if students" );
      }
    }
}
