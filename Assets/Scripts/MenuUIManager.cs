using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuUIManager : MonoBehaviour
{
    public InputField inputField;
    public void NameEntered(string name)
    {
        HighscoreManager.Instance.playerName = name;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Name: " + HighscoreManager.Instance.playerName);
    }
}
