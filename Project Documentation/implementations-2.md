# Implementations-2
*Group [03] - QuickChange*\
*Date: November 24, 2024*\
*Group Members: Tre Kelley, James Harris, Tate Whittaker, Sean Weston, Dazzion Porter*

## 1. Introduction

QuickChange is an educational game that teaches kids how to count money in the most accurate and efficient way by introducing the student to a real world learning environment.

The main features of our game include a: 

- Login scene that allows students to login and store their game data.
- Teacher login scene that allows admin to view their progress.
- A store scene that includes a register, customers, and items to purchase. Here is where students can interact with money and customers to get a feel for a real world learning environment.

[GitHub Project Link](https://github.com/James-d-Harris/QuickChange/tree/main)

## 2. Implemented Requirements
**Requirement:** Register UI to display amount of current change in register.

**Issue:** [GitHub Issue #89](https://github.com/James-d-Harris/QuickChange/issues/89)

**Pull Request:** [GitHub Pull Request #126](https://github.com/James-d-Harris/QuickChange/pull/126)

**Implemented By:** Tate Whittaker

**Approved By:** Tre Kelley

**Screenshot:** ![image](https://github.com/James-d-Harris/QuickChange/blob/d6-work/images/unityregisterUIscreenshot.png)


**Requirement:** Customer asset to allow for interactivity with user.

**Issue:** [GitHub Issue #131](https://github.com/James-d-Harris/QuickChange/issues/131)

**Pull Request:** [GitHub Pull Request #132](https://github.com/James-d-Harris/QuickChange/pull/132)

**Implemented By:** Tate Whittaker

**Approved By:** Tre Kelley

**Screenshot:** ![image](https://github.com/James-d-Harris/QuickChange/blob/d6-work/images/unityCustomerAssetScreenshot.png)


**Requirement:** Teacher view for student results.

**Issue:** [GitHub Issue #128](https://github.com/James-d-Harris/QuickChange/issues/128)

**Pull Request:** [GitHub Pull Request #125](https://github.com/James-d-Harris/QuickChange/pull/125)

**Implemented By:** James Harris

**Approved By:** Trey Kelley

**Screenshot:** ![image](https://github.com/James-d-Harris/QuickChange/blob/d6-work/images/unityTeacherView.png)


**Requirement:** Acceptance testing for C# classes.

**Issue:** [GitHub Issue #129](https://github.com/James-d-Harris/QuickChange/issues/129)

**Pull Request:** [GitHub Pull Request #127](https://github.com/James-d-Harris/QuickChange/pull/127)

**Implemented By:** Dazzion Porter

**Approved By:** Trey Kelley

**Screenshot:** N/A


**Requirement:** Introduce Level class that will be used to control most of the game.

**Issue:** [GitHub Issue #130](https://github.com/James-d-Harris/QuickChange/issues/130)

**Pull Request:** [GitHub Pull Request #115](https://github.com/James-d-Harris/QuickChange/pull/115)

**Implemented By:** Sean Weston

**Approved By:** Tre Kelley

**Screenshot:** N/A

## 3. Testing
### Unit Testing
**Test Framework:** Unity Testing Framework

**GitHub Link:** https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Editor/UnitTesting.cs

**TestCase Example:** testCalculateDrawerBalance

This unit test verifies the behavior of a method from the register class. Ensures that the correct register balance is being calculated in a given instance.

```
public void testCalculateDrawerBalance( Register registerInstance )
    {
      double balanceResult = 0.0;
      int index = 0;

      while( registerInstance.allCurrency[index + 1] != null )
      {
        balanceResult += registerInstance.allCurrency[index].monetaryValue;
      }

      Assert.AreEqual( balanceResult, registerInstance.CalculateDrawerBalance(),
                            "Error: Drawer balance is incorrectly calculated" );
    }
```

### Acceptance Testing
**Test Framework:** Unity Testing Framework

**GitHub Link:** https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Editor/AcceptanceTesting.cs

**TestCase Example:** checkUserInput

This acceptance test initiates a co-routine, which consists of a 30 second timer that checks for user input and if its being recorded.

```
void checkUserInput()
  {
    // defines 30 second wait time to detect user input
    float waitTimeOutSec = 30f;

    // Starts co-routine for logging recorded input
    StartCoroutine( logRecordedInput( waitTimeOutSec ) );
  }
```

Below is the _IEnumerator_ that listens for user input over given amount of time. When user input detected, it its logged to the console. If user input is never detected, an error is logged.

```
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
      timer += time.deltaTime;
      yield return null;
    }

    // tests for recorded input failure
    if ( !recordedInput )
    {
      Assert.AreEqual( true, recordedInput, "Error: User input not detected" );
    }
  }
```

## 4. Demo

## 5. Code Quality

As a team, we decided that the best way to manage out code quality was to use a C# Linter. Since we had worked with command line linters in CS 386 a few weeks prior, we wanted to work with something similar for C#. We landed on dotnet-format, a command line tool to check and fix code style and formatting issues.

The dotnet-format linter follows the common C# code conventions as posted here: [C# Code Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). 

Some practices we adopted to improve the code quality were:

1. Followed the offical C# code conventions provided by Microsoft.
2. Implemented mandatory peer reviews for all pull requests before any merging can be done.
3. Used Debug.Log statements to ensure adequate coverage of edge cases.
4. Wrote extensive comments when necessary, mainly including TODO tasks.
5. Committing changes often instead of all at one.


## 6. Lessons Learned

Looking back on this deliverable and second release of implementations, we as a team learned more about client-server architecture and how to use external tools to create games (i.e., Unity Game Engine, MongoDB). 

Moving forward, if we were to continue developing this product we would want to add more game levels that correspond to the student's grade level (i.e., difficulty), have multiple customer interactions per level, and have some sort of feedback for each level that shows completness, accuracy, etc. for the students.
