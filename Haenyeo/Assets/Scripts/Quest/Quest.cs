using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Tooltip("����Ʈ �̸�")]
    public string name;

    [Tooltip("����Ʈ ����")]
    public string[] details;

    public bool isQuest = false;
}

[System.Serializable]
public class QuestEvent
{
    public string name;

    public Vector2 line;
    public Quest[] quests;
}
