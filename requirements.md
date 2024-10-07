# Requirements
*Group [03] - QuickChange*\
*Date: September 26, 2024*\
*Group Members: Dazzion Porter, James Harris, Sean Weston, Tate Whittaker, Tre Kelley*

## 1. Positioning

### 1.1 Problem Statement
The problem of confusion when it comes to understanding the value of money affects elementary school kids; The impacts of which include lack of math proficiency and the development of counting skills, critical thinking, and the ability of recognizing patterns

### 1.2 Product Position Statement
For kids that have trouble counting change or for elementary schools and online learning platforms that want to access a hands-on learning environment for counting change, QuickChange is an educational game that teaches kids the value of money. Unlike other learning platforms like Kahn Academy and ABC Mouse, our product engages students with a user experience centered around practical and real world scenarios.

### 1.3 Value Proposition and Customer Segment
- Value Proposition: QuickChange is an educational game that teaches kids how to count money in the most accurate and efficient way by introducing the student to a real world learning environment.
- Customer Segment: Kids that want to learn how to count change, elementary schools and learning platforms that desire to supplement their math curriculum.


## 2. Stakeholders

### List of stakeholders in order of control over the product
1.  Our group of developers: We are a user which in this case would manage the distribution of our program and who has access to the managerial side of the content.
2.  Teachers and school faculty: This group would have access to the software and the ability to manage which of their students have access to it and the ability to track progress of those students.
3.  Students and other children learning: This group would be the one using the main part of the program to learn with. They would be the group interacting with the game/learning experience. 


## 3. Functional Requirements

1. Data Storage: Our system must be capable of storing the data of each user into a database constructed to keep information accessible to both user and teacher. The aim is to include a main way to store progress of the individuals, incorporate a system for teachers to view progress and to allow for there to be simple communication of the database to everyone. Mostly, the database will keep simple data as well as some tracking of points accumulated or other added options to the application.
2. GUI Simplicity: The design programming for the GUI must be with a process of simplicity and easy-to-understand importance for the users. This requirement is needed for the uses of students to give them something they can use while also be friendly to teachers for simple maneuvering of information. This will mostly be in the form of buttons or text boxes with no knowledge needed of programming or coding.
3. Generate Problems: The program is capable of generating problems given the level at which the student input for grades. This is important for the program to not be hard coded with set questions and instead will create a near infinite amount of problems generated to the specifics of each grade and what they are relatively around. This will be on the server side with a help of some coding to include certain parameters given the differences in the levels.
4. Admin Teachers: The program is with the design of students and teachers, which is why it is important to give an advanced role to the teacher in the form of being in charge of their students. This is important for the previous requirements to give the teacher a bigger view of the class as a whole. Roughly fifteen to thirty kids can be in a class and if a teacher is in charge of overseeing their work, it is important to give that information to the teacher as well as give them oversight to be in charge of the class.

## 4. Non-Functional Requirements

1. Retention: A reward system that allows users to collect trophies or virtual currency. Currency can be used to buy trophies or customize the UI. The goal of this requirement is to keep users, primarily young children, interested in the game and the concepts that are being taught. A trophy for each grouping of levels (1st grade, 2nd grade...) could work, or a virtual shop where user's could spend the currency they earned from completing levels. At least 7 out of 10 users should be excited with the reward system.
2. Feedback: A progress tracking bar the shows the current level completion percentage and accuracy per question. This would allow the teacher or admin to track their students progress and see who is excelling or who might need some extra guidance. It could also potentially allow students to recognize where they are struggling themselves. This requirement should be supported by 8 out of 10 teachers/admin.
3. Contextualization: The ability to change the basis of the level. For example, one implementation might use a grocery store to help users learn how to use money in real-world situations. The goal of this requirement would be to introduce users to different situations where they could be tasked with buying or selling goods, and giving change based on their role. There should be at least two different level designs.
4. Accessibility: The software should include features such as adjustable text size or colorblind-friendly modes to ensure that students with visual impairments can use the application effectively. The goal of this requirement is to ensure inclusivity for all users, so that a majority of users can participate and learn from the software. At least 9 out of 10 users with accessibility issues should be able to use the software comfortably.

## 5. Minimal Viable Product (MVP)

### 5.1 Our MVP
Our MVP will showcase the core gameplay mechanics of QuickChange. While it won't include certain advanced features like account saving, progress review, or difficulty scaling, it will clearly demonstrate the game's objectives and the financial literacy skills we're aiming to teach.

### 5.2 Features
The core features we will validate in our MVP are:

1. **Request of currency:** A customer requests a specific amount of change from the player.
2. **Selecting currency:** The player selects coins or bills to provide the requested change.
3. **Displaying the total sum:** A real-time display shows the total sum of the selected currency.
4. **User submission:** The player submits their selected currency when they believe they have provided the correct amount.
5. **Validation:** The system checks whether the total sum matches the requested amount.

These five features form the core mechanics of QuickChange and clearly illustrate our goals of teaching users how to calculate and provide the correct amount of change.

### 5.3 Validation Strategy
To validate these features, we will conduct playtesting sessions where users interact with the core mechanics of the game. We will assess the following:

- **User Engagement:** Observe how easily users understand the request and selection of currency mechanics, ensuring the gameplay is intuitive.
- **Accuracy of Submissions:** Analyze how often users are able to correctly provide the requested amount of currency and how long it takes them.
- **Feedback Collection:** Gather qualitative feedback from users on their experience, particularly regarding ease of use and areas of confusion.
- **Iterative Improvements:** Based on user feedback, we will refine the interface and game mechanics to make QuickChange more accessible and engaging before expanding to additional features.

By focusing on these key metrics, we will be able to ensure the core gameplay mechanics are effectively teaching users how to calculate change, aligning with the goals of the application.


## 6. Use Cases

### 6.1 Use Case Diagrams

![Model](https://github.com/James-d-Harris/QuickChange/blob/main/images/UseCaseTate.drawio%20(1).png)

### 6.2 Use Case Descriptions and Interface Sketch

- **Dazzion - Use Case 1:** Create new account
  - **Actor:** Student
  - **Trigger:** User intends to save game progress
  - **Pre-condition:** The student creates valid password and username
  - **Post-condition:** Game progress is saved and linked to username and is retrievable
  - **Main Success Scenario:**
    1. Student progresses in game
    3. Student Chooses to create an account
    4. System requests valid password and username
    5. System links entered login with saved progress
  - **Alternate Scenarios**:
    
    1a. Student has no progress
     1. Student may choose to create an account in the opening main menu
        
    2a. Student does not enter a valid username/password
     1. Student must re-enter valid username and password to save game progress
  - **Interface Sketch**:
    ![image](https://github.com/user-attachments/assets/a19f755a-e160-4d72-bf59-2a18767b638e)
- James: As a **teacher**, I want to be able to **teach students how to calculate change effectively** so that they can **improve their financial literacy and practical math skills**.
  - **Use Case:** Teach Change Calculation
  - **Primary Actor:** Teacher
  - **Precondition:** The teacher is using the QuickChange application in a classroom or learning environment.
  - **Trigger:** The teacher introduces a lesson on calculating change and uses the application as a tool to demonstrate the concept.
  - **Main Success Scenario:** Students interact with the application, learn to calculate change accurately, and the teacher can track their progress.
  - **Postcondition:** Students gain confidence in their ability to give correct change, and the teacher receives feedback on their performance for further instruction.
- Sean: As a **teacher**, I have a large class and want to **see what is happening with the ones I cannot help in such a small amount of time** so that if any help is required to push that student or give them clarity, I can **model lesson planning or give a clearer indication of what to do to the student.**
  - **Use Case:** See each child's tracked records
  - **Primary Actor:** Teacher
  - **Precondition:** Teacher has and uses QuickChange in their teachings.
  - **Trigger:** The teacher does not have enough time throughout the allotted time to get to every student who needs help, and not all students will admit struggles.
  - **Main Success Scenario:** The teacher is provided with a summarized detail of the class and with what each student has comleted/struggled/missed.
  - **Postcondition:** Teacher is able to give more help to certain students or find what can be changed to support their learning and success.
- **Tate - Use Case 4:** View Child Progress
  - **Actor:** Parent of User/Child
  - **Trigger:** The parent(s) of a user/child want to view their child's progress.
  - **Precondition:** The parent has a child that uses QuickChange.
  - **Postconditions:** Parent(s) are able to successfully log on to their user's/child's QuickChange account and provide necessary help.
  - **Main Success Scenario(s):**
    1. Parents of users/children are able to successfully login and view child's progress.
    2. Parents reach out to the teacher or admin in charge of this user's/child's account and ask for advice on what they can do at home to help their child progress.
    3. Parents successfully are able to use strategies from the teacher to help their user/child better understand how to use money.
  - **Alternative Scenario(s):**\
    1a. Parents are unable to login to their user's/child's QuickChange account.
      1. System informs parent of unsuccessful login and prompts them for another try OR a "forgot username/password" features is present.
  - **Interface Sketch:**\
  ![image](https://github.com/James-d-Harris/QuickChange/blob/Tate-Development-Branch/images/UseCaseInterfaceSketchTate.drawio.png)
- Tre: As a **student** I want to learn how to **handle money** so that I can **figure out the amount of change I am supposed to get back when buying things**.
  - **Use Case:** Handle Money
  - **Primary Actor:** Student
  - **Precondition:** The student is using the application in student mode in a learning environment. 
  - **Trigger:** The student needs to learn about currency in the classroom and thus opens the application as a direction of the teacher.
  - **Main Success Scenario:**  The student starts learning about currency in a way that interests them.
  - **Postcondition:** The student understands how currency works.

## 7. User Stories

- Dazzion: As a **student**, I want to **create my own account** so that my **game progress is saved and retrievable**.
  - **Priority:** 10
  - **Estimated Hours:** 10
- Dazzion: As a **student**, I want to be able to **view the set difficulty** so that i can **infer how much of a challenge the current level is**.
  - **Priority:** 8
  - **Estimated Hours:** 2
- James: **As a teacher**, I want to be able to **track my students' progress** so that I can **identify which students need more help with calculating change**.
  - **Priority:** 10
  - **Estimated Hours:** 8
- James: **As a teacher**, I want to be able to **assign different difficulty levels to my students** so that they can **gradually improve their change-calculating skills at an appropriate pace**.
  - **Priority:** 8
  - **Estimated Hours:** 5
- James: **As a student**, I want to **receive immediate feedback** on whether I provided the correct amount of change so that I can **learn from my mistakes and adjust my approach**.
  - **Priority:** 9
  - **Estimated Hours:** 3 
- Sean: **As a student**, I want to **see what went wrong if I got the wrong answer** so that I can **learn what I could do to move forward**.
  - **Priority:** 7
  - **Estimated Hours:** 6
- Sean: **As a teacher**, I want to **see if my students are improving or staying the same** so that I can **see what is working or not**.
  - **Priority:** 8
  - **Estimated Hours:** 8
- Tate: **As a teacher**, I want to **see an overview of my class** so that I can **plan future lessons around topics where students are struggling**.
  - **Priority:** 7
  - **Estimated Hours:** 10
- Tate: **As a parent**, I want to be able to **view my child's progress at home** so that I can **support their learning and practice with them outside of school**.
  - **Priority:** 3
  - **Estimated Hours:** 5
- Tre: **As a teacher** I want to be capable of **Sorting students progress** so that I can **help the low performing students without singling them out.**
  - **Priority:** 9
  - **Estimated Hours:** 2.5
- Tre: **As a student** I want to **have fun** so that I can **learn without it feeling like a chore**.
  - **Priority:** 6
  - **Estimated Hours:** 10

## 8. Issue Tracker

- <a href="https://github.com/James-d-Harris/QuickChange/issues" target="_blank">GitHub Issue Tracker </a>
- ![Model](https://github.com/James-d-Harris/QuickChange/blob/Tate-Development-Branch/images/IssueTrackerScreenshot.png)
