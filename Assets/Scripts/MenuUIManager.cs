using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MenuUIManager : MonoBehaviour
{

    public void NameEntered(string name)
    {
        HighscoreManager.Instance.playerName = name;
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void TestButton(int scene)
    {
        Debug.Log("Load scene #" + scene);
    }
    public void Difficulty(int dif)
    {
        HighscoreManager.Instance.Difficulty(dif);
    }
}
