using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementContainer _achievements;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        TryLoad();
    }

    private void TryLoad()
    {
        if (File.Exists(Application.persistentDataPath + "/Achievement.json"))
        {
            AchievementContainer loadedAchievements = JsonUtility.FromJson<AchievementContainer>
                (File.ReadAllText(Application.persistentDataPath + "/Achievement.json"));
            foreach (var ach in loadedAchievements.achievements)
            {
                foreach (var achi in _achievements.achievements)
                {
                    if (ach.ID == achi.ID)
                    {
                        achi.isSolved = ach.isSolved;
                        break;
                    }
                }
            }
        }
    }

    public void NewAchievementSolved(string ID)
    {
        foreach (var ach in _achievements.achievements)
        {
            if (ach.ID == ID)
            {
                ach.isSolved = true;
                string json = JsonUtility.ToJson(_achievements);
                // TODO: Save to persistent data path
                break;
            }
        }
    }
}
