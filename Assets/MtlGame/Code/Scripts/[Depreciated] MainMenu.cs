using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    // public Button optionsButton;

    public Texture2D cursorDefault;



    void Start()
    {
        // Add Event to Start the game
        startButton.onClick.AddListener(StartGame);

        // Add Event to Option
        // optionsButton.onClick.AddListener(ShowOptions);

        // Add Event to Quit the game
        quitButton.onClick.AddListener(QuitGame);


        
    }


    void StartGame()
    {
        // Load the game
        SceneManager.LoadScene("Loading");
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);

    }

     void ShowOptions()
    {
        // Show the options menu
        
    }

    void QuitGame()
    {
        // Quit app
        Application.Quit();
    }
}