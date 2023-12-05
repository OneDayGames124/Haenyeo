using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string name; // �뷡 �̸�
    public AudioClip clip; // �뷡
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager instance;

    #region singleton
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    #endregion singleton

    public AudioSource[] audioSourceEffects; //ȿ����
    public AudioSource audioSourceBgm; // �����

    public string[] playSoundName;

    public Sound[] effectSounds;
    public Sound[] bgmSounds;

    private void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }

    public void PlaySE(string _name)  //�뷡 ���
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if(!audioSourceEffects[j].isPlaying)
                    {
                        playSoundName[j] = effectSounds[i].name;
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        return;
                    }
                }
                Debug.Log("��� AudioSource�� ��� ��");
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�");
    }

    public void StopAllSE() //��� ȿ���� ����
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if(playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                return;
            }
        }
        Debug.Log("��� ����" + _name + "���尡 �����ϴ�");
    }
   
}
