using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount;
    public Rigidbody Ball;
    public float ballSpeed;

    public Text ScoreText;
    public GameObject GameOverText;
    public Text highScoreText;

    private bool m_Started = false;
    private int m_Points;
    public string playerName;

    private string hs_Name;
    private int hs_Points;

    private bool m_GameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerName = HighscoreManager.Instance.playerName;
        Load();
        ballSpeed = HighscoreManager.Instance.ballSpeed;
        LineCount = HighscoreManager.Instance.LineCount;
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * ballSpeed, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        if (m_Points > hs_Points)
        {
            Save();
        }
    }
    [System.Serializable]
    class SaveData 
    {
        public int scoreData;
        public string nameData;
    }  
    public void Save()
    {
        SaveData data = new SaveData();
        data.nameData = playerName;
        data.scoreData = m_Points;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
        Debug.Log("Game Saved to " + Application.persistentDataPath);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hs_Name = data.nameData;
            hs_Points = data.scoreData;

            highScoreText.text = "Best Score: " + hs_Name + " " + hs_Points;
            Debug.Log("Game Loaded to " + Application.persistentDataPath);
        }
    }
}
