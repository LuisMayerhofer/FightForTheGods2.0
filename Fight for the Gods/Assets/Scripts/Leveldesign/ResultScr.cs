using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScr : MonoBehaviour
{
    public Text txt1;
    public Text txt2;
    public string Hero1Name;
    public string Hero2Name;
    public float restartTime;
    
    private void Awake()
    {
        txt1.text = "Fight is over!";
        txt2.text = Hero2Name + " " + "has won!";
        Invoke("RestartGame", restartTime);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
