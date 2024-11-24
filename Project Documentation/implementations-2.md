# Implementations-2
*Group [03] - QuickChange*\
*Date: November 24, 2024*\
*Group Members: Tre Kelley, James Harris, Tate Whittaker, Sean Weston, Dazzion Porter*

## 1. Introduction

## 2. Implemented Requirements
**Requirement:**

**Issue:** 

**Pull Request:** 

**Implemented By:** 

**Approved By:** 

**Screenshot:** (if applicable)

## 3. Testing
### Unit Testing
**Test Framework:** Unity Testing Framework

**GitHub Link:** 

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

**GitHub Link:** 

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

## 6. Lessons Learned
