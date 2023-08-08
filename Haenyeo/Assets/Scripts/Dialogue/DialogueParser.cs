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
        
        //for(int i=1; i<data.Length;)
        //{
        //    string[] row = data[i].Split(new char[] { ',' });

        //    Dialogue dialogue = new Dialogue(); //��� ����Ʈ ����

        //    dialogue.name = row[1];
        //    Debug.Log(row[1]);

        //    List<string> contextList = new List<string>();

        //    do
        //    {
        //        contextList.Add(row[2]);
        //        Debug.Log(row[2]);
        //        if (++i < data.Length)
        //        {
        //            row = data[i].Split(new char[] { ',' });
        //        }
        //        else
        //        {
        //            break;
        //        }
        //    }
        //    while (row[0].ToString() == "");

        //    dialogue.contexts = contextList.ToArray();

        //    dialogueList.Add(dialogue);
         
        //}

        for(int i=2; i<data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });


            Dialogue dialogue = new Dialogue(); //��� ����Ʈ ����

            dialogue.name = row[5];
            //Debug.Log(row[5]);
            List<string> contextList = new List<string>();
            List<string> spriteList = new List<string>();

            do
            {
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
            while (row[5].ToString() == "" && row[6].ToString() == "");

            dialogue.contexts = contextList.ToArray();

            dialogueList.Add(dialogue);

        }

        return dialogueList.ToArray();
    }

}
