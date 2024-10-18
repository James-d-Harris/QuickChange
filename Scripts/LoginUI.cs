using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_Text feedbackText;
    public MongoDBManager mongoDBManager;

    // This method will be called when the login button is clicked
    public async void OnLoginButtonClick()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        // Validate the user with MongoDB
        bool isAuthenticated = await mongoDBManager.ValidateUser(username, password);

        // Display feedback to the user
        if (isAuthenticated)
        {
            feedbackText.text = "Login successful!";
        }
        else
        {
            feedbackText.text = "Login failed. Please check your credentials.";
        }
    }
}
