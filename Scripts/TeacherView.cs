using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MongoDB.Bson;

public class TeacherView : MonoBehaviour
{
    public MongoDBManager mongoDBManager; // Reference to the MongoDBManager
    private Canvas canvas; // Dynamically created Canvas
    private GameObject backgroundPanel; // Background Panel
    private GameObject studentListContainer; // Container for student entries
    private GameObject backButton; // Back Button
    private GameObject addStudentButton; // Add Student Button

    void Start()
    {
        // Create the Canvas dynamically
        CreateCanvas();
        // Create the Background Panel
        CreateBackgroundPanel();
        // Create the Scrollable Student List
        CreateScrollableStudentList();
        // Create the Add Student Button
        CreateAddStudentButton();
        // Create the Back Button
        CreateBackButton();

        // Hide TeacherView UI on Start
        canvas.gameObject.SetActive(false);
    }

    private void CreateCanvas()
    {
        GameObject canvasObject = new GameObject("TeacherViewCanvas");
        canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay; // Set to Screen Space - Overlay

        CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1920, 1080);

        canvasObject.AddComponent<GraphicRaycaster>();
    }

    private void CreateBackgroundPanel()
    {
        // Create the background panel and set its parent
        backgroundPanel = new GameObject("BackgroundPanel");
        backgroundPanel.transform.SetParent(canvas.transform, false);

        // Add an Image component for the background
        Image panelImage = backgroundPanel.GetComponent<Image>();
        if (panelImage == null)
        {
            panelImage = backgroundPanel.AddComponent<Image>();
        }

        // Set the panel color to light brown
        panelImage.color = new Color(0.76f, 0.65f, 0.46f, 1f); // Light brown color

        // Get or add the RectTransform component
        RectTransform rectTransform = backgroundPanel.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            rectTransform = backgroundPanel.AddComponent<RectTransform>();
        }

        // Set RectTransform properties for centering and scaling
        float width = Screen.width * 0.8f; // 80% of screen width
        float height = Screen.height * 0.8f; // 80% of screen height
        rectTransform.sizeDelta = new Vector2(width, height);
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f); // Centering
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero; // Center the panel
    }

    private void CreateScrollableStudentList()
    {
        // Create Scroll View
        GameObject scrollView = new GameObject("ScrollView");
        scrollView.transform.SetParent(backgroundPanel.transform, false); // Parent to backgroundPanel

        RectTransform scrollRectTransform = scrollView.AddComponent<RectTransform>();
        scrollRectTransform.anchorMin = new Vector2(0.05f, 0.2f); // Leave space for header
        scrollRectTransform.anchorMax = new Vector2(0.95f, 0.8f); // Leave space for back button
        scrollRectTransform.offsetMin = Vector2.zero;
        scrollRectTransform.offsetMax = Vector2.zero;

        // Add ScrollRect component
        ScrollRect scrollRect = scrollView.AddComponent<ScrollRect>();
        scrollRect.horizontal = false; // Enable vertical scrolling only

        // Add a Mask to ensure content is clipped
        Mask mask = scrollView.AddComponent<Mask>();
        mask.showMaskGraphic = false;

        // Add Image for the scroll view background
        Image scrollBackground = scrollView.AddComponent<Image>();
        scrollBackground.color = new Color(0.9f, 0.9f, 0.9f, 1f); // Light gray background

        // Create Content GameObject
        GameObject content = new GameObject("Content");
        content.transform.SetParent(scrollView.transform, false); // Parent to ScrollView

        RectTransform contentRect = content.AddComponent<RectTransform>();
        contentRect.anchorMin = new Vector2(0, 1); // Top of the ScrollView
        contentRect.anchorMax = new Vector2(1, 1);
        contentRect.pivot = new Vector2(0.5f, 1);
        contentRect.sizeDelta = new Vector2(0, 0); // Dynamically adjusted

        // Add VerticalLayoutGroup to Content
        VerticalLayoutGroup layoutGroup = content.AddComponent<VerticalLayoutGroup>();
        layoutGroup.childAlignment = TextAnchor.UpperLeft;
        layoutGroup.spacing = 10;
        layoutGroup.childControlWidth = true;
        layoutGroup.childControlHeight = true;

        // Add ContentSizeFitter to auto-adjust Content size
        ContentSizeFitter contentSizeFitter = content.AddComponent<ContentSizeFitter>();
        contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        // Link Content to ScrollRect
        scrollRect.content = contentRect;

        // Assign to studentListContainer for later use
        studentListContainer = content;
    }

    private void CreateAddStudentButton()
    {
        // Create AddStudentButton GameObject
        addStudentButton = new GameObject("AddStudentButton");
        addStudentButton.transform.SetParent(backgroundPanel.transform, false);

        // Add RectTransform for positioning
        RectTransform rectTransform = addStudentButton.AddComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.05f, 0.05f); // Bottom-left corner
        rectTransform.anchorMax = new Vector2(0.25f, 0.15f); // Small button area
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // Add Button component
        Button button = addStudentButton.AddComponent<Button>();

        // Add Image for the button's background
        Image buttonImage = addStudentButton.AddComponent<Image>();
        buttonImage.color = new Color(0.6f, 0.8f, 0.6f, 1f); // Light green color

        // Create the button's text
        GameObject buttonTextObject = new GameObject("AddStudentButtonText");
        buttonTextObject.transform.SetParent(addStudentButton.transform, false);

        TMP_Text buttonText = buttonTextObject.AddComponent<TextMeshProUGUI>();
        buttonText.text = "Add Student";
        buttonText.fontSize = 24;
        buttonText.alignment = TextAlignmentOptions.Center;

        RectTransform textRect = buttonText.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        // Attach an onClick listener to handle Add Student logic
        button.onClick.AddListener(() =>
        {
            OpenAddStudentDialog();
        });
    }

    private void CreateInputField(Transform parent, string name, string placeholderText, Vector2 position, bool isPassword = false)
    {
        GameObject inputFieldObject = new GameObject(name);
        inputFieldObject.transform.SetParent(parent, false);

        RectTransform inputRect = inputFieldObject.AddComponent<RectTransform>();
        inputRect.anchorMin = new Vector2(position.x - 0.2f, position.y - 0.05f);
        inputRect.anchorMax = new Vector2(position.x + 0.2f, position.y + 0.05f);
        inputRect.offsetMin = Vector2.zero;
        inputRect.offsetMax = Vector2.zero;

        TMP_InputField inputField = inputFieldObject.AddComponent<TMP_InputField>();
        Image inputImage = inputFieldObject.AddComponent<Image>();
        inputImage.color = Color.white;

        GameObject placeholderObject = new GameObject("Placeholder");
        placeholderObject.transform.SetParent(inputFieldObject.transform, false);
        TMP_Text placeholder = placeholderObject.AddComponent<TextMeshProUGUI>();
        placeholder.text = placeholderText;
        placeholder.fontSize = 18;
        placeholder.alignment = TextAlignmentOptions.Center;
        placeholder.color = new Color(0.7f, 0.7f, 0.7f, 1f);

        RectTransform placeholderRect = placeholder.GetComponent<RectTransform>();
        placeholderRect.anchorMin = Vector2.zero;
        placeholderRect.anchorMax = Vector2.one;
        placeholderRect.offsetMin = Vector2.zero;
        placeholderRect.offsetMax = Vector2.zero;

        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(inputFieldObject.transform, false);
        TMP_Text text = textObject.AddComponent<TextMeshProUGUI>();
        text.fontSize = 18;
        text.alignment = TextAlignmentOptions.Center;
        text.color = Color.black;

        RectTransform textRect = text.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        inputField.textComponent = text;
        inputField.placeholder = placeholder;

        if (isPassword)
        {
            inputField.contentType = TMP_InputField.ContentType.Password;
        }
    }

    private TMP_Text CreateText(Transform parent, string textContent, int fontSize, TextAlignmentOptions alignment)
    {
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(parent, false);

        TMP_Text text = textObject.AddComponent<TextMeshProUGUI>();
        text.text = textContent;
        text.fontSize = fontSize;
        text.alignment = alignment;
        text.color = Color.black;

        RectTransform textRect = text.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        return text;
    }

    private void OpenAddStudentDialog()
{
    Debug.Log("Opening Add Student Dialog");

    // Create a Panel for the dialog
    GameObject dialogPanel = new GameObject("AddStudentDialog");
    dialogPanel.transform.SetParent(canvas.transform, false);

    RectTransform panelRect = dialogPanel.AddComponent<RectTransform>();
    panelRect.anchorMin = new Vector2(0.3f, 0.3f);
    panelRect.anchorMax = new Vector2(0.7f, 0.7f);
    panelRect.offsetMin = Vector2.zero;
    panelRect.offsetMax = Vector2.zero;

    Image panelImage = dialogPanel.AddComponent<Image>();
    panelImage.color = new Color(0.9f, 0.9f, 0.9f, 1f); // Light gray background

    // Create Input Fields for Username, Password, Grade, and Permission Level
    CreateInputField(dialogPanel.transform, "UsernameInput", "Enter Username", new Vector2(0.5f, 0.8f));
    CreateInputField(dialogPanel.transform, "PasswordInput", "Enter Password", new Vector2(0.5f, 0.6f), true);
    CreateInputField(dialogPanel.transform, "GradeInput", "Enter Grade", new Vector2(0.5f, 0.4f));
    CreateInputField(dialogPanel.transform, "PermissionLevelInput", "Enter Permission Level", new Vector2(0.5f, 0.2f));

    // Add a Confirm Button
    GameObject confirmButton = new GameObject("ConfirmButton");
    confirmButton.transform.SetParent(dialogPanel.transform, false);

    RectTransform confirmRect = confirmButton.AddComponent<RectTransform>();
    confirmRect.anchorMin = new Vector2(0.4f, 0.05f);
    confirmRect.anchorMax = new Vector2(0.6f, 0.15f);
    confirmRect.offsetMin = Vector2.zero;
    confirmRect.offsetMax = Vector2.zero;

    Button confirm = confirmButton.AddComponent<Button>();
    Image buttonImage = confirmButton.AddComponent<Image>();
    buttonImage.color = new Color(0.6f, 0.8f, 0.6f, 1f); // Light green

    TMP_Text confirmText = CreateText(confirmButton.transform, "Confirm", 24, TextAlignmentOptions.Center);
    confirm.onClick.AddListener(() =>
    {
        string username = dialogPanel.transform.Find("UsernameInput").GetComponent<TMP_InputField>().text;
        string password = dialogPanel.transform.Find("PasswordInput").GetComponent<TMP_InputField>().text;
        string grade = dialogPanel.transform.Find("GradeInput").GetComponent<TMP_InputField>().text;
        string permission = dialogPanel.transform.Find("PermissionLevelInput").GetComponent<TMP_InputField>().text;

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) &&
            !string.IsNullOrEmpty(grade) && !string.IsNullOrEmpty(permission))
        {
            // Parse grade and permission level
            if (int.TryParse(grade, out int gradeLevel) && int.TryParse(permission, out int permissionLevel))
            {
                // Create a new Student object
                Student newStudent = new Student(username, password, gradeLevel, permissionLevel);

                // Insert the new student into the database
                mongoDBManager.InsertUser(newStudent);

                // Convert Student to BsonDocument for display
                BsonDocument newStudentDocument = new BsonDocument
                {
                    { "username", newStudent.Username },
                    { "password", newStudent.Password },
                    { "grade", newStudent.GradeLevel },
                    { "permissionLevel", newStudent.GetPermissionLevel() },
                    { "successfulLevels", newStudent.getSuccessfulLevels() },
                    { "failedLevels", newStudent.getFailedLevels() }
                };

                // Display the new student in the list
                DisplayStudent(newStudentDocument, studentListContainer);

                // Destroy the dialog panel
                Destroy(dialogPanel);
            }
            else
            {
                Debug.LogError("Grade and Permission Level must be valid numbers!");
            }
        }
        else
        {
            Debug.LogError("All fields must be filled!");
        }
    });
}



    private void CreateBackButton()
    {
        // Create BackButton GameObject
        backButton = new GameObject("BackButton");
        backButton.transform.SetParent(backgroundPanel.transform, false);

        // Ensure RectTransform is added
        RectTransform rectTransform = backButton.GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            rectTransform = backButton.AddComponent<RectTransform>();
        }

        // Set RectTransform properties for positioning
        rectTransform.anchorMin = new Vector2(0.75f, 0.05f); // Bottom-right corner
        rectTransform.anchorMax = new Vector2(0.95f, 0.15f); // Small button area
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // Add Button component
        Button button = backButton.GetComponent<Button>();
        if (button == null)
        {
            button = backButton.AddComponent<Button>();
        }

        // Add Image for the button's background
        Image buttonImage = backButton.GetComponent<Image>();
        if (buttonImage == null)
        {
            buttonImage = backButton.AddComponent<Image>();
        }
        buttonImage.color = Color.gray;

        // Create the button's text
        GameObject buttonTextObject = new GameObject("BackButtonText");
        buttonTextObject.transform.SetParent(backButton.transform, false);

        // Add TextMeshPro component for the button label
        TMP_Text buttonText = buttonTextObject.AddComponent<TextMeshProUGUI>();
        buttonText.text = "Back";
        buttonText.fontSize = 24;
        buttonText.alignment = TextAlignmentOptions.Center;

        // Adjust RectTransform for the button label
        RectTransform textRect = buttonText.GetComponent<RectTransform>();
        if (textRect == null)
        {
            textRect = buttonText.gameObject.AddComponent<RectTransform>();
        }
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        // Attach an onClick listener to return to the main menu
        button.onClick.AddListener(() =>
        {
            HideTeacherView();
        });
    }

    private async void LoadAndDisplayStudents(GameObject container)
    {
        // Fetch all users (or students) from the database
        List<BsonDocument> allStudents = await mongoDBManager.GetAllUsers();

        if (allStudents != null && allStudents.Count > 0)
        {
            Debug.Log($"Retrieved {allStudents.Count} students from the database.");

            foreach (var student in allStudents)
            {
                DisplayStudent(student, container);
            }
        }
        else
        {
            Debug.LogError("Failed to retrieve students or no students found.");
        }
    }

    private void DisplayStudent(BsonDocument student, GameObject container)
    {
        if (student == null)
        {
            Debug.LogWarning("Null student document provided.");
            return;
        }

        // Create a GameObject for the student entry button
        GameObject studentButton = new GameObject("StudentButton");
        studentButton.transform.SetParent(container.transform, false);

        // Add RectTransform for layout
        RectTransform rectTransform = studentButton.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(800, 100); // Ensure the button has a height
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(0.5f, 1);

        // Add LayoutElement to ensure the button height works within layouts
        LayoutElement layoutElement = studentButton.AddComponent<LayoutElement>();
        layoutElement.minHeight = 50; // Minimum button height
        layoutElement.preferredHeight = 50;

        // Add Button component
        Button button = studentButton.AddComponent<Button>();
        button.transition = Selectable.Transition.ColorTint;

        // Configure Button's color states
        ColorBlock colors = button.colors;
        colors.normalColor = new Color(0.85f, 0.85f, 0.85f); // Light gray
        colors.highlightedColor = new Color(0.75f, 0.75f, 0.75f); // Slightly darker gray on hover
        colors.pressedColor = new Color(0.65f, 0.65f, 0.65f); // Darker gray when pressed
        colors.colorMultiplier = 1f;
        button.colors = colors;

        // Add Image for the button's background
        Image buttonImage = studentButton.AddComponent<Image>();
        buttonImage.color = colors.normalColor;

        // Add TextMeshProUGUI component for student info text
        GameObject textObject = new GameObject("StudentInfo");
        textObject.transform.SetParent(studentButton.transform, false);

        TMP_Text text = textObject.AddComponent<TextMeshProUGUI>();
        text.fontSize = 24; // Readable text size
        text.alignment = TextAlignmentOptions.Left | TextAlignmentOptions.Center; // Left-aligned and vertically centered
        text.color = Color.black;

        // Populate text with student data
        string studentInfo = "Invalid student data.";
        if (student.Contains("username") && student.Contains("successfulLevels") && student.Contains("failedLevels"))
        {
            string username = student.GetValue("username").AsString;
            int successfulLevels = student.GetValue("successfulLevels").AsInt32;
            int failedLevels = student.GetValue("failedLevels").AsInt32;

            studentInfo = $"Username: {username} | Success: {successfulLevels} | Fail: {failedLevels}";
        }
        text.text = studentInfo;

        // Adjust RectTransform for the text
        RectTransform textRect = text.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 0);
        textRect.anchorMax = new Vector2(1, 1);
        textRect.offsetMin = new Vector2(10, 0); // Padding on the left
        textRect.offsetMax = new Vector2(0, 0); // Ensure it's centered vertically

        // Add an onClick listener for the button
        button.onClick.AddListener(() =>
        {
            Debug.Log($"Clicked on: {studentInfo}");
            // Add functionality for what happens when the student entry is clicked
        });
    }

    private void HideTeacherView()
    {
        // Clear all children of the "Content" container
        if (studentListContainer != null)
        {
            foreach (Transform child in studentListContainer.transform)
            {
                Destroy(child.gameObject);
            }
        }

        // Hide the TeacherView canvas
        canvas.gameObject.SetActive(false);

        // Show the main menu
        FindObjectOfType<MenuManager>().ShowMainMenu();
    }

    public void Show()
    {
        canvas.gameObject.SetActive(true);
        LoadAndDisplayStudents(studentListContainer);
    }
}
