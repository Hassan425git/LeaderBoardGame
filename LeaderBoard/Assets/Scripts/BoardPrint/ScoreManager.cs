using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData d;
    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        d = JsonUtility.FromJson<ScoreData>(json);
        d = new ScoreData();
    }

    public IEnumerable<Score> GetHighScore()
    {
        return d.scores.OrderByDescending(x => x.score);
    }
    public void AddScore(Score score)
    {
        d.scores.Add(score);
    }

    public void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(d);
        PlayerPrefs.SetString("scores", json);
    }
}
