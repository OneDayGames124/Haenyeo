using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomWindow : MonoBehaviour
{
    public GameObject[] windows;
    public GameObject won;
    public Image panel; // ���̵���/�ƿ� ȿ���� ������ Panel
    public float fadeDuration = 1.0f; // ���̵���/�ƿ��� �ɸ��� �ð�

    private float currentAlpha = 0.0f; // ���� ���� ��

    void Start()
    {
        //if (SaveNLoad.instance.saveData.questAllCount > 0)
        //    won.SetActive(false);
        SaveNLoad save = FindObjectOfType<SaveNLoad>();
        if (save.saveData.nowIndex > 0)
            won.SetActive(false);


        if ((int)GameManager.instance.state == 0)
        {
            ChangeWindow(0);
        }
        else if ((int)GameManager.instance.state == 1)
        {
            ChangeWindow(1);
        }
        else
        {
            ChangeWindow(2);
            won.SetActive(false);
        }
    }

    void ChangeWindow(int day)
    {
        windows[day].SetActive(true);
        for(int i=0; i<windows.Length; i++)
        {
            if(i!=day)
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void GoSleep()
    {
        GameManager.instance.time = 0;
        panel.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
        windows[0].SetActive(true);
        windows[2].SetActive(false);
        
    }

   


    IEnumerator FadeIn()
    {
        //panel.gameObject.SetActive(true);
        while (currentAlpha > 0.0f)
        {
            currentAlpha -= Time.deltaTime / fadeDuration;
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, currentAlpha);
            yield return null;
        }
        panel.gameObject.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        
        while (currentAlpha < 1.0f)
        {
            currentAlpha += Time.deltaTime / fadeDuration;
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, currentAlpha);
            yield return null;
        }
        StartCoroutine(FadeIn());
       // panel.gameObject.SetActive(false);
    }


}
