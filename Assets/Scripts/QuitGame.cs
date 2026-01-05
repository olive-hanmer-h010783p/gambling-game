using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Causes the game to close when the button is clicked
    public void QuitOnClick()
    {
        // THIS IS ONLY FOR MAKING SURE THE CODE WORKS. REMOVE BEFORE COMPILING.
        UnityEditor.EditorApplication.isPlaying = false;
        //closes the game lol
        Application.Quit();
    }
}
