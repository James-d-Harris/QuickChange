using System.Collections.Generic;
using UnityEngine;

public class Teacher : Student
{
    // Teacher-specific attributes
    private List<Student> students;
    private bool studentView;

    // Constructor
    public Teacher(/*Level startingLevel) : base(startingLevel)*/)
    {
        students = new List<Student>();
        studentView = false;
    }

    // Method to access a student's progress
    public void accessStudentProgress(Student student)
    {
        Debug.Log("Progress for student: Successes - " + student.getSuccessfulLevels() + ", Failures - " + student.getFailedLevels());
    }

    // Method to get the list of students
    public List<Student> getStudents()
    {
        return students;
    }

    // Method to add a new student
    public void addStudent(Student student)
    {
        students.Add(student);
    }

    // Method to edit a student's information
    public void editStudent(Student student)
    {
        Debug.Log("Editing student.");
    }

    // Method to enter or exit student view
    public void enterStudentView()
    {
        studentView = !studentView;
        Debug.Log(studentView ? "Entering student view..." : "Exiting student view...");
    }

    // Adjust difficulty for a student manually
    // public void adjustStudentDifficulty(Student student, Difficulty newDifficulty)
    // {
    //     Debug.Log("Adjusting difficulty for student");
    //     Student.currentDifficulty = newDifficulty;
    // }
}
