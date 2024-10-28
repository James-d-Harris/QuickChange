# Implementations
*Group [03] - QuickChange*\
*Date: October 27, 2024*\
*Group Members: Dazzion Porter, James Harris, Sean Weston, Tate Whittaker, Tre Kelley*

## 1. Introduction
QuickChange is an educational game that teaches kids how to count money in the most accurate and efficient way by introducing the student to a real world learning environment.

QuickChange will allow students and teachers to create respective personal accounts. The student account will store student's progress, while the teacher account will be responsible for tracking the progress of each student. The content of this game will teach students how to count change by generating random values to be operated on in each level. The difficulty of each problem will rise or fall (automatically or at teachers discretion) depending on the students performance in the prior level. In order to enhance the learning experience, students will be provided with feedback on each problem, and have the ability of altering QuickChange's styling to accommodate visual disabilities. All student and teacher accounts will be retrievable with valid username and password

The gameplay of QuickChange will consist of having students interact with npc customers. Each customer will generate it's own randomized item and value of currency to be used in each problem. Students will then be navigated to the register, where they will calculate the difference between the customer tender and owed balance. The student will then distribute change by dragging out different types of currency out of the register such as coins and bills. The value pulled out of register will appear on the coin sum display and be used to check work and provide feedback.

**GitHub Link:** https://github.com/James-d-Harris/QuickChange

## 2. Implemented Requirements

**Requirement:** ***As a user, I want to be able to login so that I can save my progress as I play the game.***

**Issue:** https://github.com/James-d-Harris/QuickChange/issues/55

**Pull Request:** https://github.com/James-d-Harris/QuickChange/pull/54

**Implemented By:** James Harris

**Approved By:** Dazzion Porter

**Screenshot:** (if applicable)

**Requirement:** ***As a student, I want to be able to use real world currency and work in an environment that is applicable to everyday life so that I can learn how to use money for in-person transaction.***

**Issue:** https://github.com/James-d-Harris/QuickChange/issues/56, https://github.com/James-d-Harris/QuickChange/issues/57, and https://github.com/James-d-Harris/QuickChange/issues/62

**Pull Request:** https://github.com/James-d-Harris/QuickChange/pull/61, https://github.com/James-d-Harris/QuickChange/pull/63, https://github.com/James-d-Harris/QuickChange/pull/65, https://github.com/James-d-Harris/QuickChange/pull/66, and https://github.com/James-d-Harris/QuickChange/pull/69

**Implemented By:** Tate Whittaker and Tre Kelley

**Approved By:** Dazzion Porter

**Screenshot:** (if applicable)

**Requirement:** ***As a teacher, I want to be able to increase or decrease the difficulty of the levels so that my students can learn appropriately.***

**Issue:** https://github.com/James-d-Harris/QuickChange/issues/73

**Pull Request:** https://github.com/James-d-Harris/QuickChange/pull/59 and https://github.com/James-d-Harris/QuickChange/pull/60

**Implemented By:** Dazzion Porter

**Approved By:** Tate Whittaker

**Screenshot:** (if applicable)

**Requirement:** ***As a teacher, I want to be there to be different customers and items for my students to interact with so that they are interested in the game, and therefore learning about money.***

**Issue:** https://github.com/James-d-Harris/QuickChange/issues/74

**Pull Request:** https://github.com/James-d-Harris/QuickChange/pull/59 and https://github.com/James-d-Harris/QuickChange/pull/60

**Implemented By:** Sean Weston

**Approved By:** Dazzion Porter

**Screenshot:** (if applicable)

## 3. Tests

## 4. Adopted Technologies
- Unity: The game engine used for QuickChange, manages game logic and visuals including the controls and content within each level.
- MongoDB: Stores saved information regarding all student and teacher accounts. Keeps track of students progress and current difficulty level, that is then to be reported to students associated instructor;\.
  
## 5. Learning/Training
The training for learning our adopted technologies consists of a mix of group collaboration and individual research with resources such as YouTube and other online forums. As for Unity, there are built-in tutorial for how to create 2D games.

## 6. Deployment

## 7. Licensing

## 8. README File

## 9. Look & Feel 

For our user interface, we used Photoshop and Unity to create assets (images) that our users can interact with. We decided to recreate a real world environment, in this case a grocery store. Our users will sit behind a counter and interact with customers, the items they want to buy, and a register to check them out and give them change. Here are some images:

![image](https://github.com/James-d-Harris/QuickChange/blob/D4-Implementations/images/UnityUIStoreScene.png)

![image](https://github.com/James-d-Harris/QuickChange/blob/D4-Implementations/images/gamePenny.png)

![image](https://github.com/James-d-Harris/QuickChange/blob/D4-Implementations/images/tenDollar.png)

## 10. Lessons Learned

During this first release we learned how to create assets inside the Unity Engine, how to write code in C#, and how to implement a login API system using MongoDB. Going forward, we will continue to work on refining the UI for our users and we hope to add more levels so that users can experience different environments and real world money situations.

## 11. Demo