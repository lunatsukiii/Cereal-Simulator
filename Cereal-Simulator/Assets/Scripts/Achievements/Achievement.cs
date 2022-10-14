using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObjects/Achievement", order = 1)]
[Serializable] public class Achievement : ScriptableObject
{
    public bool isSolved;
    public string description;
    public string ID;
}

[Serializable]
public class AchievementContainer
{
    public Achievement[] achievements;
}
