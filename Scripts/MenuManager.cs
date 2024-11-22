using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private Canvas canvas;         // The dynamically created canvas
    private GameObject menuPanel;  // The menu panel for buttons
    private Student currentUser;   // Tracks the logged-in user
    public LoginUI loginUI;        // Reference to the LoginUI script for creating the login overlay

    void Start()
    {
        // Dynamically create the UI
        CreateCanvas();
        CreateMenuPanel();

        // Generate the default/basic menu
        GenerateBasicMenu();
    }

    // Create the Canvas
    void CreateCanvas()
    {
        GameObject canvasObject = new GameObject("Canvas");
        canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(1920, 1080);

        canvasObject.AddComponent<GraphicRaycaster>();
    }

    // Create the Menu Panel
    void CreateMenuPanel()
    {
        menuPanel = new GameObject("MenuPanel");
        menuPanel.transform.SetParent(canvas.transform, false);

        Image panelImage = menuPanel.AddComponent<Image>();
        panelImage.color = new Color(0.76f, 0.65f, 0.46f, 1f); // Light brown color

        RectTransform rectTransform = menuPanel.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);  // Bottom-left corner
        rectTransform.anchorMax = new Vector2(0, 1);  // Top-left corner
        rectTransform.offsetMin = new Vector2(0, 0);  // Stretch to match screen height
        rectTransform.offsetMax = new Vector2(300, 0); // Fixed width of 300px
    }

    // Generate the Basic Menu (default view before login)
    void GenerateBasicMenu()
    {
        // Clear any existing buttons
        ClearMenu();

        // Create essential buttons with updated positioning
        float spacing = 60f; // Spacing between buttons
        float initialOffset = -50f; // Start buttons lower on the screen

        CreateButton("Play Demo", () => Debug.Log("Play Demo clicked"), 0, initialOffset, spacing);
        CreateButton("Settings", () => Debug.Log("Settings clicked"), 1, initialOffset, spacing);
        CreateButton("Login", OnLoginLogoutClick, 2, initialOffset, spacing);

        // Exit button fixed at the bottom
        CreateFixedBottomButton("Exit Game", Application.Quit);
    }

    // Dynamically generate the menu after login
    public void OnUserLogin(Student user)
    {
        int offset = 0;
        // Store the logged-in user
        currentUser = user;

        // Clear the current menu and create a new one
        ClearMenu();

        // Create buttons for logged-in users
        float spacing = 60f;
        float initialOffset = -50f;

        CreateButton("Play", () => Debug.Log("Play clicked"), offset++, initialOffset, spacing);
        CreateButton("Settings", () => Debug.Log("Settings clicked"), offset++, initialOffset, spacing);

        // Add additional buttons based on permission level
        if (currentUser.GetPermissionLevel() >= 2)
        {
            CreateButton("View Students", () => Debug.Log("View Students clicked"), offset++, initialOffset, spacing);
        }

        if (currentUser.GetPermissionLevel() >= 3)
        {
            CreateButton("Admin Panel", () => Debug.Log("Admin Panel clicked"), offset++, initialOffset, spacing);
        }

        CreateButton("Logout", OnLogoutClick, offset++, initialOffset, spacing);

        // Exit button fixed at the bottom
        CreateFixedBottomButton("Exit Game", Application.Quit);
    }

    // Helper method to clear all buttons
    void ClearMenu()
    {
        foreach (Transform child in menuPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Helper method to create a button with dynamic positioning
    void CreateButton(string buttonText, UnityEngine.Events.UnityAction onClickAction, int positionIndex, float initialOffset, float spacing)
    {
        GameObject buttonObject = new GameObject(buttonText);
        buttonObject.transform.SetParent(menuPanel.transform, false);

        // Set the button to the UI layer
        buttonObject.layer = LayerMask.NameToLayer("UI");

        // Add Button component
        Button button = buttonObject.AddComponent<Button>();
        button.transition = Selectable.Transition.ColorTint;

        // Configure ColorBlock for hover, press, and click feedback
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;                // Default color
        colors.highlightedColor = new Color(0.9f, 0.9f, 0.9f); // Hover color (slightly darker)
        colors.pressedColor = new Color(0.7f, 0.7f, 0.7f);     // Pressed color (darker)
        colors.selectedColor = Color.white;             // Selected state color
        colors.disabledColor = new Color(0.5f, 0.5f, 0.5f);    // Disabled state color
        colors.colorMultiplier = 1.0f;
        button.colors = colors;

        // Add Image component for the button's background
        Image buttonImage = buttonObject.AddComponent<Image>();
        buttonImage.color = Color.white; // Set default background color

        // Set RectTransform for button positioning
        RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.sizeDelta = new Vector2(0, 50); // Fixed height
        rectTransform.anchoredPosition = new Vector2(0, initialOffset - (positionIndex * spacing));

        // Add TextMeshPro for button text
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(buttonObject.transform, false);

        // Set the text to the UI layer
        textObject.layer = LayerMask.NameToLayer("UI");

        TMP_Text tmpText = textObject.AddComponent<TextMeshProUGUI>();
        tmpText.text = buttonText;
        tmpText.fontSize = 24;
        tmpText.alignment = TextAlignmentOptions.Center;
        tmpText.color = Color.black;

        // Adjust text RectTransform to fill the button
        RectTransform textRect = tmpText.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 0);
        textRect.anchorMax = new Vector2(1, 1);
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        // Assign the click action to the button
        button.onClick.AddListener(onClickAction);

    }


    // Helper method to create a button fixed at the bottom
    void CreateFixedBottomButton(string buttonText, UnityEngine.Events.UnityAction onClickAction)
    {
        // Create the Button GameObject
        GameObject buttonObject = new GameObject(buttonText);
        buttonObject.transform.SetParent(menuPanel.transform, false);

        // Set the button to the UI layer
        buttonObject.layer = LayerMask.NameToLayer("UI");

        // Add TMP Button (Button + Image + TextMeshPro)
        Button button = buttonObject.AddComponent<Button>();
        button.transition = Selectable.Transition.ColorTint;

        // Configure ColorBlock for hover, press, and click feedback
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;                // Default color
        colors.highlightedColor = new Color(0.9f, 0.9f, 0.9f); // Hover color (slightly darker)
        colors.pressedColor = new Color(0.7f, 0.7f, 0.7f);     // Pressed color (darker)
        colors.selectedColor = Color.white;             // Selected state color
        colors.disabledColor = new Color(0.5f, 0.5f, 0.5f);    // Disabled state color
        colors.colorMultiplier = 1.0f;
        button.colors = colors;

        // Add Image component for button background
        Image buttonImage = buttonObject.AddComponent<Image>();
        buttonImage.color = Color.white; // Default background color

        // Set RectTransform properties to fix the button at the bottom
        RectTransform rectTransform = buttonObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0); // Anchor to the bottom-left
        rectTransform.anchorMax = new Vector2(1, 0); // Anchor to the bottom-right
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.sizeDelta = new Vector2(0, 50); // Fixed height
        rectTransform.anchoredPosition = new Vector2(0, 30); // Slightly above the bottom edge

        // Add TextMeshProUGUI for button text
        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(buttonObject.transform, false);

        // Set the text to the UI layer
        textObject.layer = LayerMask.NameToLayer("UI");

        TMP_Text tmpText = textObject.AddComponent<TextMeshProUGUI>();
        tmpText.text = buttonText;
        tmpText.fontSize = 24;
        tmpText.alignment = TextAlignmentOptions.Center;
        tmpText.color = Color.black;

        // Adjust RectTransform for TextMeshPro text
        RectTransform textRect = tmpText.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 0);
        textRect.anchorMax = new Vector2(1, 1);
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        // Assign click action to the button
        button.onClick.AddListener(onClickAction);
    }



    // Action for login/logout button
    void OnLoginLogoutClick()
    {

        if (currentUser == null) // User is not logged in
        {
            Debug.Log("Login clicked. Show login screen.");
            loginUI.CreateOverlay(); // Call CreateOverlay on LoginUI

            // After login (simulating successful login for this example)
            currentUser = new Student(); // Replace with actual user login logic
        }
        else // User is logged in
        {
            Debug.Log("Logout clicked.");
            OnLogoutClick();
        }
    }


    // Action for logout
    void OnLogoutClick()
    {
        Debug.Log("User logged out.");
        currentUser = null;
        GenerateBasicMenu(); // Reset to basic menu
    }
}
