using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementContainer _achievements;
    public static AchievementManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            TryLoad();
        }
        else
        {
            Destroy(gameObject);
        }
        
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
                    if (achi.ID == ach.ID)
                    {
                        Debug.Log("loaded Achievement: " + achi.ID);
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
                string json = JsonUtility.ToJson(ach);
                File.WriteAllText( Application.persistentDataPath+"/Achievement.json", json);
                break;
            }
        }
    }
}
