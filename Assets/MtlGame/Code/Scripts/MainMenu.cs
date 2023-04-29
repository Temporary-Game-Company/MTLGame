using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button optionsButton;


    void Start()
    {
        // Add Event to Start the game
        startButton.onClick.AddListener(StartGame);

        // Add Event to Option
        optionsButton.onClick.AddListener(ShowOptions);

        // Add Event to Quit the game
        quitButton.onClick.AddListener(QuitGame);

        
    }

    void StartGame()
    {
        // Load the game
        SceneManager.LoadScene("DesignScene");
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