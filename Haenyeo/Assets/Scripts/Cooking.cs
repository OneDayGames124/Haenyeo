using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cooking", menuName = "New Cooking/Cooking")]
public class Cooking : ScriptableObject
{
    public string cookingName; //�丮 �̸�
    public Sprite cookingImage; //�丮 �̹���
    public int price;
    public NeedFood[] needfood;
    

    [System.Serializable]
    public struct NeedFood
    {
        public Item food;
        public int needCount; 
    }

}
