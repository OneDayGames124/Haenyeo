using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CVSFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();
        TextAsset csvData = Resources.Load<TextAsset>(_CVSFileName);

        string[] data = csvData.text.Split(new char[] { '\n' }); //���� ������ �ɰ��� ������


        for(int i=2; i<data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });


            Dialogue dialogue = new Dialogue(); //��� ����Ʈ ����

            dialogue.dialogueIndex = row[0]; //change to int
           // dialogue.name = row[5];
            Debug.Log(row[5]);
            List<string> contextList = new List<string>();
            List<string> nameList = new List<string>();
            //List<string> spriteList = new List<string>();

            do
            {
                if (nameList.Count == 0)
                {
                    nameList.Add(row[5]);
                }
                else if (row[5] == "")
                {
                    nameList.Add(nameList[nameList.Count - 1]);
                    //Debug.Log(2);
                }
                else
                {
                    nameList.Add(row[5]);
                    //Debug.Log(3);
                }

                //nameList.Add(row[5]);
                contextList.Add(row[6]);
                //Debug.Log(row[6]);
                if (++i < data.Length)
                {
                    row = data[i].Split(new char[] { ',' });
                }
                else
                {
                    break;
                }
            }
            while (row[0].ToString() == "");
            //while (row[5].ToString() == "");

            dialogue.contexts = contextList.ToArray();
            dialogue.name = nameList.ToArray();

            dialogueList.Add(dialogue);

        }

        return dialogueList.ToArray();
    }

}
