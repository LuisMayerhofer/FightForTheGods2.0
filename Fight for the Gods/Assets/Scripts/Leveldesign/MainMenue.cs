using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("A Button"))
        {
            int Number = Random.Range(1, 3);
            if (Number == 1)
                SceneManager.LoadScene(1);
            else
                SceneManager.LoadScene(4);
        }
    }
}
