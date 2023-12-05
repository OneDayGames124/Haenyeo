using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slot : MonoBehaviour
{
    public Item item; //ȹ���� ������
    public Image itemImage; // �������� �̹���
    public int itemCount;

    [SerializeField]
    TMP_Text text_Count;

    //[SerializeField]
    //GameObject go_CountImage; // ������ ī��Ʈ �̹��� �ʿ��� ��� Ȱ��ȭ


    //�̹��� ���� ����
    void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }


    //������ ȹ��
    public void AddItem(Item _item, int _count =1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType != Item.ItemType.Tool)
        {
            text_Count.text = itemCount.ToString();
            //text_Count.text = "0";
            text_Count.gameObject.SetActive(false);
            
        }
        else
        {
            text_Count.text = "0";
        }
        SetColor(1);
    }


    //������ ���� ����
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if(itemCount <=0)
        {
            ClearSlot();
        }
    }


    //���� �ʱ�ȭ
    void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        text_Count.gameObject.SetActive(false);

    }
}
