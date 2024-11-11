# Project Design
*Group [03] - QuickChange*\
*Date: November 5, 2024*\
*Group Members: Dazzion Porter, James Harris, Sean Weston, Tate Whittaker, Tre Kelley*

## 1. Introduction
In today's increasingly digital world, the skill of handling physical money is at risk of diminishing, particularly among elementary students. This decline could impact critical skills such as math proficiency, pattern recognition, and practical problem-solving. **QuickChange** is designed as an interactive educational game that reintroduces children to the value and use of money, bridging this gap. Unlike other learning platforms such as Khan Academy and ABC Mouse, QuickChange immerses students in practical, real-world scenarios, guiding them through hands-on exercises in counting and managing change.

QuickChange provides account-based progress tracking for both students and teachers. Each student account securely records progress, adapting the game’s difficulty based on performance, while teacher accounts allow instructors to monitor and adjust lesson content as needed. QuickChange generates randomized currency problems and interactive NPC customer encounters, challenging students to calculate and return change using a virtual register with various denominations of coins and bills. The system is accessible to all students, with customizable styling to accommodate visual disabilities, and feedback is provided after each problem to reinforce learning.


## 2. Architecture
![image](https://github.com/user-attachments/assets/a399180b-c8a1-4c40-9bcd-28b3860218a7)

Rationale:
- Student and Teacher classes will both be able to login, create accounts, and play game levels by accessing the **Main Screen Layer**.
- Teacher classes will have access to **Administrator Layer's** packages that allow for tracking student progress and managing student accounts.
- The **Game Management Layer** has packages for initializing game levels, setting game level difficulty, operation of system automated testing, and stores account info in Database.
- The **Game Management Layer** uses the **Game Logic Layer**, which contains packages correlating to the actual **Level Interface** in each level and important classes that the **Level Logic** is computed from.
   
## 3. Class Diagram

![image](https://github.com/James-d-Harris/QuickChange/blob/main/images/D5UMLClassDiagram.png) 

## 4. Sequence Diagram
![image](https://github.com/James-d-Harris/QuickChange/blob/main/images/use%20case%205%20play%20level.drawio.png)

### use case 5 "Play Level" 
- **Primary Actor:** Student
  - **Trigger:** The student decides to play a level
  - **Precondition:** The student is logged in student mode in a learning environment.
  - **Postcondition:** The student completes the level
  - **Main Success Scenario:**
    1. Student starts playing a level
    2. Student uses in game info to learn how to play level
    3. Student completes transactions with customers
    4. Student correctly completes transactions with customers and thus the level is completed successfully
  - **Alternate Scenarios**:

  1a. Student completes transactions with customers
    1. Transactions are generally incorrect and student fails level


## 5. Design Patterns
**Design Pattern 1:** Currency Class (Composite Design)
  ![image](https://github.com/user-attachments/assets/574e99b5-c2d5-4a81-aa95-ebf4286892ab)

  **Corresponding Classes**
- Currency: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs
- Penny: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs
- Nickel: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs
- Dime: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs
- Quarter: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs
- OneDollar: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs
- FiveDollar: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs
- TenDollar: https://github.com/James-d-Harris/QuickChange/blob/main/Scripts/Game/coinClass.cs

**Design Pattern 2:** Register Class (Observer Pattern)

  ![image](https://github.com/James-d-Harris/QuickChange/blob/main/images/D5UMLObserver.png)


  **Corresponding Classes**
- Currency: https://github.com/James-d-Harris/QuickChange/blob/D5-design/Scripts/Game/coinClass.cs
- Register: https://github.com/James-d-Harris/QuickChange/blob/D5-design/Scripts/Game/registerClass.cs
- CoinSumDisplay: https://github.com/James-d-Harris/QuickChange/blob/D5-design/Scripts/Game/coinSumDisplayClass.cs

## 6. Design Principles
QuickChange’s design follows key principles of **user-centered design** and **scalability**.

- **User-Centered Design**: The interface is structured around ease of use for young students, with intuitive drag-and-drop mechanics to simulate handling money. For example, students interact with virtual customers who provide a purchase amount, and they must accurately calculate the required change. This design prioritizes usability by focusing on tasks that mimic real-world scenarios in a simple, visually engaging environment. Moreover, customizable visual settings support inclusivity, accommodating students with various visual needs.

- **Scalability**: QuickChange is built to scale across different skill levels, making it adaptable for students of various math proficiencies. The system can automatically adjust difficulty levels based on each student's progress, creating a personalized learning experience. For example, as a student improves, QuickChange generates increasingly challenging problems, enhancing skill progression without requiring manual intervention from teachers. Additionally, the underlying account system allows the game to support numerous users, ensuring it can be used effectively in both individual and classroom settings.
