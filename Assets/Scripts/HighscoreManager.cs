using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;
    public string playerName;
    public float ballSpeed = 2.0f;
    public int LineCount = 6;
    public float paddleSpeed = 2.0f;
    public float maxVel = 3.0f;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void BallSpeedSet(float speed)
    {
        ballSpeed = speed;
    }
    public void LineCountSet (int lines)
    {
        LineCount = lines;
    }
    public void PaddleSpeedSet (float speed)
    {
        paddleSpeed = speed;
    }
    public void MaxVelocity (float vel)
    {
        maxVel = vel;
    }
    public void Difficulty(int dif)
    {
        if(dif == 0)
        {
            BallSpeedSet(2.0f);
            LineCountSet(6);
            PaddleSpeedSet(2.0f);
            MaxVelocity(3.0f);
        } else if (dif == 1)
        {
            BallSpeedSet(3.0f);
            LineCountSet(6);
            PaddleSpeedSet(3.0f);
            MaxVelocity(3.0f);
        } else if (dif == 2)
        {
            BallSpeedSet(5.0f);
            LineCountSet(6);
            PaddleSpeedSet(2.0f);
            MaxVelocity(6.0f);
        }

    }
}
