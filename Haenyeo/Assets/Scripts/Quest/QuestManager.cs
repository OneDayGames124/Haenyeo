using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{

    [SerializeField] GameObject QuestBoxList;
    [SerializeField] GameObject[] questBox;

    [Header("����Ʈ ���� â")]
    [SerializeField] TMP_Text questText;

    [Header("����Ʈ ������")]
    [SerializeField] GameObject[] questDetailList;

    Quest[] quests;
    
    [Header("�����")]
    [SerializeField] SaveNLoad storage;


    //private void Start()
    //{
    //    for(int i= storage.saveData.completeQuest; i< storage.saveData.questAllCount; i++)
    //    {
    //        quests = DatabaseManager.instance.GetQuest(storage.saveData.questAllCount);
    //        GameObject temp = Instantiate(questBoxPrefab);
    //        temp.transform.SetParent(QuestBoxList.transform);
    //        temp.transform.localScale = new Vector3(1, 1, 1);
    //        temp.transform.GetChild(0).GetComponent<TMP_Text>().text = quests[i].name;

    //        //0�� �����ؽ�Ʈ, 1�� �������ؽ�Ʈ
    //        temp.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = quests[i].name;

    //        //��ü ����
    //        string replaceText = quests[i].details;
    //        replaceText = replaceText.Replace("'", ",");
    //        replaceText = replaceText.Replace("\\n", "\n");
    //        temp.transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>().text = replaceText;
    //    }
    //}

    public void Active(int index)
    {
        quests = DatabaseManager.instance.GetQuest(index);
        if (quests[0].name != null)
        {


            if (index == 0)
            {
                GameObject.FindWithTag("Won").gameObject.SetActive(false);
            }

            for (int i = 0; i < quests[0].name.Length; i++)
            {
                questBox[i].SetActive(true);
                //questBox[i].transform.GetChild(0).GetComponent<TMP_Text>().text = quests[index].name[i];
                questBox[i].transform.GetChild(0).GetComponent<TMP_Text>().text = quests[0].name[i];


                //��ü ����
                //string replaceText = quests[index].details[i];
                string replaceText = quests[0].details[i];
                replaceText = replaceText.Replace("'", ",");
                replaceText = replaceText.Replace("\\n", "\n");

                //questDetailList[i].transform.GetChild(0).GetComponent<TMP_Text>().text = quests[index].name[i];
                questDetailList[i].transform.GetChild(0).GetComponent<TMP_Text>().text = quests[0].name[i];
                questDetailList[i].transform.GetChild(1).GetComponent<TMP_Text>().text = replaceText;



            }
        }
        storage.saveData.nowIndex++;
    }


}
