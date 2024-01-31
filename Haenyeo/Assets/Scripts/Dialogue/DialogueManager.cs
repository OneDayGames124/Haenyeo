using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    //[SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] TMP_Text txt_Dialogue;
    [SerializeField] TMP_Text txt_Name;

    Dialogue[] dialogues;

    bool isDialogue = false;
    bool isNext = false; // Ư�� Ű �Է� ���.

    [Header("�ؽ�Ʈ ��� ������")]
    [SerializeField] float textDelay;

    int lineCount = 0; // ��ȭ ī��Ʈ
    int contextCount = 0; // ��ȭ ī��Ʈ

    [Header("�����")]
    [SerializeField] SaveNLoad storage;
    //public string tagName;
    [Header("����Ʈ")]
    [SerializeField] QuestManager quest;
    [Header("������")]
    [SerializeField] RewardManager reward;

    [Header("�˸�â")]
    [SerializeField] GameObject rewardBox;
    [SerializeField] Image itemBox;
    [SerializeField] Sprite[] itemSprite;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDetail;

    [SerializeField] GameObject questBox;
    [SerializeField] TMP_Text questName;

    [Header("��ȭ")]
    [SerializeField] Image[] charImg;

    bool isClickRewardBox = false;
    bool isClickQuestBox = false;

    bool multiCoroutine = false;


    void ShowDialogueImg(string name,bool active = true)
    {

        for (int i = 0; i < charImg.Length; i++)
        {
            if (active)
            {
                if (charImg[i].name == name.ToString())
                {
                    charImg[i].gameObject.SetActive(true);
                }
                else
                    charImg[i].gameObject.SetActive(false);
            }
            else
                charImg[i].gameObject.SetActive(false);
        }


    }
    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        isDialogue = true;
        txt_Dialogue.text = "";
        txt_Name.text = "";

        dialogues = p_dialogues;
        Debug.Log(dialogues.Length);
        StartCoroutine(Typewriter());
    }

    IEnumerator Typewriter()
    {
        SettingUI(true);

        string t_ReplaceText = dialogues[lineCount].contexts[contextCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ",");
        t_ReplaceText = t_ReplaceText.Replace("\\n", "\n");

        txt_Name.text = dialogues[lineCount].name[contextCount];
        ShowDialogueImg(txt_Name.text);
        for(int i=0; i<t_ReplaceText.Length; i++)
        {
            txt_Dialogue.text += t_ReplaceText[i];
            yield return new WaitForSecondsRealtime(textDelay);
        }
        isNext = true;

        
    }

    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        //go_DialogueNameBar.SetActive(p_flag);
    }

    private void Update()
    {

        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isNext = false;
                    txt_Dialogue.text = "";
                    if(++contextCount < dialogues[lineCount].contexts.Length)
                    {
                        StartCoroutine(Typewriter());
                    }
                    else
                    {
                        contextCount = 0;
                        if(++lineCount<dialogues.Length)
                        {
                            StartCoroutine(Typewriter());
                        }
                        else
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }

  

        if (Input.GetMouseButtonDown(0) && !isDialogue) //��ȭ Ŭ��
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f, LayerMask.GetMask("NPC"));

            if(hit)
            {
                ShowDialogue(DatabaseManager.instance.GetDialogue(storage.saveData.nowIndex));
            }
        }

        
    }

    bool SetSystemIndex(int index, RaycastHit2D hit, string character, string SceneName)
    {
        if (storage.saveData.questAllCount == index && hit.collider.tag == character
            && SceneManager.GetActiveScene().name == SceneName)
        {
            return true;
        }
        else
            return false;
    }

    public void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
        SettingUI(false);
        StopAllCoroutines();
        ShowDialogueImg("stop", false);

        //reward.GetReward(storage.saveData.nowIndex); //���� ������ ���� �����尡 �ִ� ���� �ƴ϶� ���� �ʿ�
        quest.Active(storage.saveData.nowIndex);
        

    }


    public void ClickRewardBox()
    {
        isClickRewardBox = true;
        rewardBox.SetActive(false);

    }

    public void ClickQuestBox()
    {
        isClickQuestBox = true;
        questBox.SetActive(false);
    }    
}
