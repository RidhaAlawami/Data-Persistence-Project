#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public void NewPlayerName(InputField nameInput)
    {
        GameManager.Instance.playerName = nameInput.text;
    }

    public void StarMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLeaderBoard()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
