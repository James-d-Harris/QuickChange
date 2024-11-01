using System.Collections.Generic;
using UnityEngine;

public class Student
{
    // Static attribute for current difficulty
    public static DifficultyClass currentDifficulty;

    // Instance attributes for student progress
    private int successfulLevels;
    private int failedLevels;
    // private Level userLevel;

    // Constructor
    public Student(/*Level startingLevel*/)
    {
        successfulLevels = 0;
        failedLevels = 0;
        // userLevel = startingLevel;
    }

    // Method to get the number of successful levels
    public int getSuccessfulLevels()
    {
        return successfulLevels;
    }

    // Method to get the number of failed levels
    public int getFailedLevels()
    {
        return failedLevels;
    }

    // Method to add a successful level and adjust difficulty
    public void addSuccess()
    {
        successfulLevels++;
        adjustDifficulty(true);
    }

    // Method to add a failed level and adjust difficulty
    public void addFailure()
    {
        failedLevels++;
        adjustDifficulty(false);
    }

    // Adjust the difficulty based on performance
    public void adjustDifficulty(bool success)
    {
        if (success)
        {
            currentDifficulty.increaseDifficulty();
        }
        else
        {
            currentDifficulty.decreaseDifficulty();
        }
    }

    // Method to start a level (implementation depends on game logic)
    public void startLevel()
    {
        Debug.Log("Starting Level");
    }
}
