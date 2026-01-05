using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //enter the name of the scene to load on the button clicked
    public string sceneToLoad;



    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
