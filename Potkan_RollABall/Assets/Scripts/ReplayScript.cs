using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReplayScript : MonoBehaviour {

    public void Replay()
    {
        SceneManager.LoadScene("main");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
