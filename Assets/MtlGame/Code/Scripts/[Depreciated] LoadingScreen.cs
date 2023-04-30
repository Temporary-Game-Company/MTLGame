using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Linq;

public class LoadingScreen : MonoBehaviour {

    private bool loadScene = false;
    public string sceneToLoad;

    // public Slider progressBar;

    public GameObject loadingText;

    TextMeshProUGUI  loadingTextComp;

    private Coroutine loadingCoroutine;

    void Start(){
        Debug.Log(loadScene);
    }
    // Updates once per frame
    void Update() {

        // If a new scene is not loading yet...
        if (loadScene == false) {

            // set the loadScene boolean to true to prevent loading a new scene more than once...
            loadScene = true;

            // change the instruction text to read "Loading..."
            loadingText.GetComponent<TextMeshProUGUI>().SetText("Loading...");
            
            
            if (loadingCoroutine != null) {
                StopCoroutine(loadingCoroutine);
                Debug.Log("je suis là");
            }
            
            // and start a coroutine that will load the desired scene.
            loadingCoroutine = StartCoroutine(LoadNewScene(3f));

        }

        // If the new scene has started loading...
        if (loadScene == true) {
            loadingTextComp = loadingText.GetComponent<TextMeshProUGUI>();
            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
           loadingTextComp.color = new Color(loadingTextComp.color.r, loadingTextComp.color.g, loadingTextComp.color.b, Mathf.PingPong(Time.time, 1));

        }

    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene(float delayTime=3f) {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // The scenes are so simple that they load too fast to read the "Loading..." text.
        Debug.Log(sceneToLoad);
        
        yield return new WaitForSeconds(delayTime);

        Debug.Log(sceneToLoad);
        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation loadingOperation = Application.LoadLevelAsync(sceneToLoad);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!loadingOperation.isDone) {
            // progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            yield return null;
        }

    }

}