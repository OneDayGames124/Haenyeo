using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{

    [SerializeField] GameObject QuestBoxList;
    [SerializeField] GameObject questBoxPrefab;

    [Header("����Ʈ ���� â")]
    [SerializeField] TMP_Text questText;

    [Header("����Ʈ ������")]
    [SerializeField] TMP_Text questDetailName;
    [SerializeField] TMP_Text questDetail;

    Quest[] quests;

    [Header("�����")]
    [SerializeField] SaveNLoad storage;


    private void Start()
    {
        for(int i= storage.saveData.completeQuest; i< storage.saveData.questAllCount; i++)
        {
            quests = DatabaseManager.instance.GetQuest(storage.saveData.questAllCount);
            GameObject temp = Instantiate(questBoxPrefab);
            temp.transform.SetParent(QuestBoxList.transform);
            temp.transform.localScale = new Vector3(1, 1, 1);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = quests[i].name;

            //0�� �����ؽ�Ʈ, 1�� �������ؽ�Ʈ
            temp.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = quests[i].name;

            //��ü ����
            string replaceText = quests[i].details;
            replaceText = replaceText.Replace("'", ",");
            replaceText = replaceText.Replace("\\n", "\n");
            temp.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = replaceText;
        }
    }


    public void ActiveQuest(int questCount = 1)
    {
        quests = DatabaseManager.instance.GetQuest(questCount);

        for (int i = 0; i < questCount; i++)
        {
            int qCount = storage.saveData.questAllCount;
            int qCompleteCount = storage.saveData.completeQuest;

            //while(QuestBoxList.transform.childCount != qCount - qCompleteCount)
            //{
            //    GameObject temp = Instantiate(questBoxPrefab);
            //    Debug.Log("instance");
            //    temp.transform.SetParent(QuestBoxList.transform);
            //    temp.transform.localScale = new Vector3(1, 1, 1);

            //}

            GameObject temp = Instantiate(questBoxPrefab);
            Debug.Log("instance");
            temp.transform.SetParent(QuestBoxList.transform);
            temp.transform.localScale = new Vector3(1, 1, 1);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = quests[qCount].name;

            //0�� �����ؽ�Ʈ, 1�� �������ؽ�Ʈ
            temp.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = quests[qCount].name;

            //��ü ����
            string replaceText = quests[qCount].details;
            replaceText = replaceText.Replace("'", ",");
            replaceText = replaceText.Replace("\\n", "\n");
            temp.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = replaceText;

            storage.saveData.questAllCount++;
            storage.SaveData();

        }
    }
}
