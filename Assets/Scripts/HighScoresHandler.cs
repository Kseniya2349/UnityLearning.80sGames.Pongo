using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class HighScoresHandler
{
    private readonly string _filePath = Application.persistentDataPath + "/highscores.json";
    private readonly HighScores _highScores;

    public HighScoresHandler()
    {
        _highScores = ReadHighScores();
    }
    
    public int[] HighScores => _highScores?.values ?? Array.Empty<int>();
    
    public void UpdateHighScores(int newScore)
    {
        var scoresList = new List<int>(_highScores?.values ?? Array.Empty<int>()) { newScore };
        scoresList.Sort((a,b) => b.CompareTo(a));
        
        _highScores.values = scoresList.Take(3).ToArray();
        
        var json = JsonUtility.ToJson(_highScores);
        var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);

        using var writer = new StreamWriter(fileStream);
        writer.Write(json);
    }

    private HighScores ReadHighScores()
    {
        var content = "";
        
        if (File.Exists(_filePath))
        {
            using StreamReader reader = new StreamReader(_filePath);
            content = reader.ReadToEnd();
        }

        return string.IsNullOrEmpty(content) ? new HighScores() : JsonUtility.FromJson<HighScores>(content);
    }
}
