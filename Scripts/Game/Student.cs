using System.Collections.Generic;
using UnityEngine;

public class Student
{
    // Static property for current difficulty (shared across all students)
    public static DifficultyClass currentDifficulty { get; set; }

    // Instance attributes for student details and progress
    public string Username { get; private set; }
    public string Password { get; private set; }
    public int GradeLevel { get; private set; }
    public int PermissionLevel;
    public int SuccessfulLevels;
    public int FailedLevels;

    // Constructor to initialize a new student

    public Student()
    {
        Username = string.Empty;
        Password = string.Empty;
        GradeLevel = 0;
        PermissionLevel = 0;
        SuccessfulLevels = 0;
        FailedLevels = 0;
    }
    public Student(string username, string password, int gradeLevel, int permissionLevel)
    {
        Username = username;
        Password = password;
        GradeLevel = gradeLevel;
        this.PermissionLevel = permissionLevel;
        SuccessfulLevels = 0; // Defaults for a new student
        FailedLevels = 0;
    }

    // Constructor to initialize from an existing student's data
    public Student(string username, int gradeLevel, int permissionLevel, int successfulLevels, int failedLevels)
    {
        Username = username;
        GradeLevel = gradeLevel;
        this.PermissionLevel = permissionLevel;
        this.SuccessfulLevels = successfulLevels;
        this.FailedLevels = failedLevels;
    }

    public Student(Student other)
    {
        if (other == null)
        {
            Debug.LogWarning("Cannot create a student from a null reference.");
            return;
        }

        Username = other.Username;
        Password = other.Password;
        GradeLevel = other.GradeLevel;
        PermissionLevel = other.PermissionLevel;
        SuccessfulLevels = other.SuccessfulLevels;
        FailedLevels = other.FailedLevels;
    }

    public int getSuccessfulLevels() => SuccessfulLevels;

    public int getFailedLevels() => FailedLevels;

    // Increment successful levels and adjust difficulty
    public void addSuccess()
    {
        SuccessfulLevels++;
        adjustDifficulty(true);
    }

    // Increment failed levels and adjust difficulty
    public void addFailure()
    {
        FailedLevels++;
        adjustDifficulty(false);
    }

    // Adjust the difficulty based on performance
    public void adjustDifficulty(bool success)
    {
        if (currentDifficulty != null)
        {
            if (success)
            {
                // CurrentDifficulty.IncreaseDifficulty();
            }
            else
            {
                // CurrentDifficulty.DecreaseDifficulty();
            }
        }
        else
        {
            Debug.LogWarning("CurrentDifficulty is not set. Difficulty adjustment skipped.");
        }
    }

    // Get permission level
    public int GetPermissionLevel() => PermissionLevel;

    // Set permission level
    public void SetPermissionLevel(int level) => PermissionLevel = level;

    // Dummy method to simulate starting a level
    public void StartLevel()
    {
        Debug.Log("Starting Level...");
        // Placeholder for level-specific logic
    }
}
