using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeInput_Eon : MonoBehaviour
{
    public GameObject iconPrefab; // �������� ������
    public Transform iconParent; // �����ܵ��� ��ġ�� �θ� ��ü
    public GameObject itemCountTextPrefab; // ������ ǥ���� UI �ؽ�Ʈ�� ������
    public Transform textParent; // �ؽ�Ʈ���� ��ġ�� �θ� ��ü

    //public Dictionary<string, int> itemCountDictionary = new Dictionary<string, int>(); // �� �������� ������ ������ ��ųʸ�
    public Button removeButton1;
    public Button removeButton2;
    public Button removeButton3;
    public GameObject fishButton; // Fish_Button ���� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ⿡�� �����ܵ��� ��Ȱ��ȭ
        SetIconsActive(false);

        // �ʱ⿡ ��� �ؽ�Ʈ�� 0���� ����
        UpdateItemCountText("recipe_numA", 0);
        UpdateItemCountText("recipe_numB", 0);
        UpdateItemCountText("recipe_numC", 0);

        // �ػ깰 ��ư�鿡 ���� �̺�Ʈ�� �߰�
        //��ġ ���� ���̴� ���� ��� ����
        AddSeafoodButtonEvent("Crust_tuto_A", "Icon_a", "recipe_numA");
        AddSeafoodButtonEvent("Crust_tuto_B", "Icon_b", "recipe_numB");
        AddSeafoodButtonEvent("Crust_tuto_C", "Icon_c", "recipe_numC");

        // remove ��ư�鿡 ���� �̺�Ʈ �߰�
        AddRemoveButtonEvents(removeButton1, "recipe_numA");
        AddRemoveButtonEvents(removeButton2, "recipe_numB");
        AddRemoveButtonEvents(removeButton3, "recipe_numC");

        // Fish_Button Ȱ��ȭ
        fishButton.SetActive(true);
    }

    // �����ܵ��� Ȱ��ȭ�ϰ� ��ġ�� �����ϴ� �Լ�
    void SetIconsActive(bool active)
    {
        foreach (Transform child in iconParent)
        {
            child.gameObject.SetActive(active);
        }
    }

    void AddSeafoodButtonEvent(string buttonName, string iconName, string recipeNum)
    {
        //SeafoodManagerNew.Instance.seafoodCountDict.Add(recipeNum, 0); // �ʱ� ������ ������ 0���� ���� -> �߰��� �ǹ���..

        Button seafoodButton = GameObject.Find(buttonName).GetComponent<Button>();
        seafoodButton.onClick.AddListener(() => AddSeafoodItem(iconName, recipeNum));
    }

    void AddSeafoodItem(string iconName, string recipeNum)
    {
        SeafoodManagerNew.Instance.seafoodCountDict[recipeNum]++;
        // ������ ���� ����
        Debug.Log(SeafoodManagerNew.Instance.seafoodCountDict[recipeNum]);

        // �ؽ�Ʈ ������Ʈ
        UpdateItemCountText(recipeNum, SeafoodManagerNew.Instance.seafoodCountDict[recipeNum]);

        // ������ Ȱ��ȭ
        SetIconsActive(true);
    }

    // �������� �����ϰ� ������ ���ҽ�Ű�� �޼���
    private void RemoveItem(string recipeNum)
    {
        if (SeafoodManagerNew.Instance.seafoodCountDict[recipeNum] > 0)
        {
            SeafoodManagerNew.Instance.seafoodCountDict[recipeNum]--; // ������ ���� ����
            UpdateItemCountText(recipeNum, SeafoodManagerNew.Instance.seafoodCountDict[recipeNum]); // �ؽ�Ʈ ������Ʈ
            Debug.Log("Item count decreased: " + SeafoodManagerNew.Instance.seafoodCountDict[recipeNum]);
        }
        else
        {
            Debug.Log("No items to remove.");
        }

        // Fish_Button Ȱ��ȭ
        fishButton.SetActive(true);
    }


    // ������ ǥ���ϴ� UI �ؽ�Ʈ ������Ʈ �Լ�
    void UpdateItemCountText(string recipeNum, int itemCount)
    {
        // itemCountTextPrefab���� Text ������Ʈ�� ã�ƿ�
        TMP_Text textComponent = itemCountTextPrefab.transform.Find(recipeNum).GetComponent<TMP_Text>();

        // �ؽ�Ʈ ������Ʈ
        if (textComponent != null)
        {
            textComponent.text = itemCount.ToString();
        }
        else
        {
            Debug.LogError("Text component not found!");
        }
    }

    // �� remove ��ư�� ���� �̺�Ʈ �߰�
    public void AddRemoveButtonEvents(Button button, string recipeNum)
    {
        button.onClick.AddListener(() => RemoveItem(recipeNum));
    }
}
