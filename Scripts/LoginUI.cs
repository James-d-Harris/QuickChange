using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LoginUI : MonoBehaviour
{
    // UI Elements for the login (these are created in Unity Editor)
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text feedbackText;
    public TMP_Text titleText;
    public Button loginButton;  // Added loginButton to reference the button
    public MongoDBManager mongoDBManager;
    public Canvas canvas;


    private GameObject panelObject;

    // Event without parameters
    public event System.Action OnLoginSuccess;

    void Start()
    {
        // CreateOverlay();  // Create the overlay when the scene starts
    }

    // This method will be called when the login button is clicked
    public async void OnLoginButtonClick()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        // Call the MongoDBManager's Login function
        var userDocument = await mongoDBManager.Login(username, password);

        if (userDocument != null)
        {
            feedbackText.text = "Login successful!";
            OnLoginSuccess?.Invoke();

            // Create the Student object using the user data
            Student loggedInStudent = new Student();

            // Set fields from the MongoDB document
            loggedInStudent.SetPermissionLevel(userDocument.GetValue("permissionLevel").AsInt32);

            // Pass the Student object to the MenuManager
            FindObjectOfType<MenuManager>().OnUserLogin(loggedInStudent);

            // Close the login overlay
            // Destroy(panelObject);
            HideOverlay();
        }
        else
        {
            feedbackText.text = "Login failed. Please check your credentials.";
        }
    }

    // Method to create the login overlay
    public void CreateOverlay()
    {

        // Create a Panel as the backdrop (Optional if you want a transparent overlay)
        panelObject = new GameObject("BackdropPanel");
        panelObject.transform.SetParent(canvas.transform, false);

        // Add an Image component to the panel (used for the background color and opacity)
        Image panelImage = panelObject.AddComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0);

        // Set the panel to stretch and fill the entire screen
        RectTransform panelRectTransform = panelObject.GetComponent<RectTransform>();
        panelRectTransform.anchorMin = new Vector2(0, 0);
        panelRectTransform.anchorMax = new Vector2(1, 1);
        panelRectTransform.offsetMin = Vector2.zero;
        panelRectTransform.offsetMax = Vector2.zero;

        // Create a container for the login UI
        GameObject infoContainer = new GameObject("InfoContainer");
        infoContainer.transform.SetParent(panelObject.transform, false);

        // Add an Image component to the container to act as the background with the border image
        Image containerImage = infoContainer.AddComponent<Image>();
        containerImage.sprite = Resources.Load<Sprite>("images/border_image");
        containerImage.type = Image.Type.Sliced;

        // Set size of the container to be 20% smaller than the screen size
        RectTransform containerRectTransform = infoContainer.GetComponent<RectTransform>();
        float width = Screen.width * 0.8f;
        float height = Screen.height * 0.8f;
        containerRectTransform.sizeDelta = new Vector2(width, height);
        containerRectTransform.anchoredPosition = Vector2.zero;

        // Reparent and adjust existing UI elements
        AdjustUIElements();
    }

    public void HideOverlay()
    {
        if (panelObject != null)
        {
            panelObject.SetActive(false); // Hide the login panel
            Debug.Log("Hiding Panel");
        }
        else
        {
            Debug.LogWarning("Panel object is not initialized or already hidden.");
        }
    }


    // Method to adjust and parent the input fields and feedback text
    private void AdjustUIElements()
    {
        // Reparent the feedback text to the info container
        titleText.transform.SetParent(GameObject.Find("InfoContainer").transform, false);
        RectTransform titleRect = titleText.GetComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0.5f, 0.5f);
        titleRect.anchorMax = new Vector2(0.5f, 0.5f);
        titleRect.sizeDelta = new Vector2(500, 200);
        titleRect.anchoredPosition = new Vector2(0, 160);
        titleText.fontSize = 70;

        // Reparent the username input field to the info container
        usernameInput.transform.SetParent(GameObject.Find("InfoContainer").transform, false);
        RectTransform usernameRect = usernameInput.GetComponent<RectTransform>();
        usernameRect.anchorMin = new Vector2(0.5f, 0.5f);
        usernameRect.anchorMax = new Vector2(0.5f, 0.5f);
        usernameRect.sizeDelta = new Vector2(300, 40);
        usernameRect.anchoredPosition = new Vector2(0, 80);

        // Reparent the password input field to the info container
        passwordInput.transform.SetParent(GameObject.Find("InfoContainer").transform, false);
        RectTransform passwordRect = passwordInput.GetComponent<RectTransform>();
        passwordRect.anchorMin = new Vector2(0.5f, 0.5f);
        passwordRect.anchorMax = new Vector2(0.5f, 0.5f);
        passwordRect.sizeDelta = new Vector2(300, 40);
        passwordRect.anchoredPosition = new Vector2(0, 20);
        passwordInput.contentType = TMP_InputField.ContentType.Password;
        passwordInput.ForceLabelUpdate();

        // Reparent the feedback text to the info container
        feedbackText.transform.SetParent(GameObject.Find("InfoContainer").transform, false);
        RectTransform feedbackRect = feedbackText.GetComponent<RectTransform>();
        feedbackRect.anchorMin = new Vector2(0.5f, 0.5f);
        feedbackRect.anchorMax = new Vector2(0.5f, 0.5f);
        feedbackRect.sizeDelta = new Vector2(300, 40);
        feedbackRect.anchoredPosition = new Vector2(0, -40);
        feedbackText.fontSize = 18;

        // Reparent the login button to the info container
        loginButton.transform.SetParent(GameObject.Find("InfoContainer").transform, false);
        RectTransform buttonRect = loginButton.GetComponent<RectTransform>();
        buttonRect.anchorMin = new Vector2(0.5f, 0.5f);
        buttonRect.anchorMax = new Vector2(0.5f, 0.5f);
        buttonRect.sizeDelta = new Vector2(200, 40);
        buttonRect.anchoredPosition = new Vector2(0, -100);

        // Add the button click event (if it's not already assigned in the Inspector)
        loginButton.onClick.AddListener(OnLoginButtonClick);
    }
}
