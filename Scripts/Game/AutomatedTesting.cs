using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

void Start()
{

}

void Update()
{
    testAddCoin();
    testSetDifficulty();
    testGetDifficulty();
    testIncreaseDifficulty();
    testDecreaseDifficulty();
    testAddSuccess();
    testAddFailure();
    testAdjustDifficulty();
}

// Automated Testing

// CoinSumDisplay
public void testAddCoin()
{
    CoinSumDisplay testDisplay = new CoinSumDisplay();
    currency money = new Penny();

    double result = money.monetaryValue + testDisplay.currentSum;

    testDisplay.AddCoin( money );
    
    Assert.AreEqual( result, testDisplay.currentSum, "Error: CoinSumDisplay is not adding coins" );

    testDisplay = null;
    money = null;
}

// Difficulty
public void testSetDifficulty()
{
    string result = "easy";
    DifficultyClass testDifficulty = new DifficultyClass();

    testDifficulty.setDifficulty("easy");

    Assert.AreEqual( result, testDifficulty.getDifficulty(), "Error: Difficulty level was not set" );

    testDifficulty = null;
}

public void testGetDifficulty()
{
    DifficultyClass testDifficulty = new DifficultyClass();
    string result = testDifficulty.levelDifficulty;

    Assert.AreEqual( result, testDifficulty.getDifficulty(), "Error: Difficulty level not retireved" );

    testDifficulty = null;
}

public void testIncreaseDifficulty()
{
    DifficultyClass testDifficulty = new DifficultyClass();
    string result = "hard";

    testDifficulty.initializeDifficulty();
    testDifficulty.increaseDifficulty();
    testDifficulty.increaseDifficulty();
    
    Assert.AreEqual( result, testDifficulty.getDifficulty(), "Error: Difficulty level not increased" );

    testDifficulty = null;
}

public void testDecreaseDifficulty()
{
    DifficultyClass testDifficulty = new DifficultyClass();
    string result = "easy";

    testDifficulty.initializeDifficulty();
    testDifficulty.setDifficulty("hard");
    
    testDifficulty.decreaseDifficulty();
    testDifficulty.decreaseDifficulty();
    
    Assert.AreEqual( result, testDifficulty.getDifficulty(), "Error: Difficulty level not decreased" );

    testDifficulty = null;
}


// Student
public void testAddSuccess()
{
    Student testStudent = new Student();
    int result = 1;

    testStudent.addSuccess();

    Assert.AreEqual( result, testStudent.getSuccessfulLevels(), "Error: Success level was not added" );
    testStudent = null;
}

public void testAddFailure()
{
    Student testStudent = new Student();
    int result = 1;

    testStudent.addFailure();

    Assert.AreEqual( result, testStudent.getFailedLevels(), "Error: Failed level was not added" );
    testStudent = null;
}

public void testAdjustDifficulty()
{
    Student testStudent = new Student();

    string result = "normal";

    testStudent.currentDifficulty.setDifficulty("easy");
    testStudent.adjustDifficulty(true);

    Assert.AreEqual( result, testStudent.currentDifficulty.getDifficulty(), "Error: Student difficulty not adjusted" );
    testStudent = null;
}
