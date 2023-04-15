using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
     VariableJoystick joy; //���̽�ƽ

    public float speed = 1f; //������ �ӵ�
    float objectWidth;
    protected float restrictY = 0.68f;
    protected float objectHeight;

    protected float x;
    protected float y;
    protected bool restrict = true;

    Rigidbody2D rigid; 

    Vector2 moveVec; 

    SpriteRenderer render; //�¿���� ��������Ʈ ������

    protected Camera mainCamera;

    float leftEdge;
    float rightEdge;
    float topEdge;
    float bottomEdge;

    private void Awake()
    {
        joy = FindObjectOfType<VariableJoystick>();
    }

    virtual protected void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main;
        objectWidth = transform.localScale.x;
        objectHeight = transform.localScale.y;
    }

    private void FixedUpdate()
    {
        Debug.Log(y);
        x = joy.Horizontal;
        y = joy.Vertical;

        //�¿����
        if (x >= 0)
            render.flipX = true;
        else
            render.flipX = false;

        moveVec = rigid.position + new Vector2(x, y) * speed * Time.deltaTime;
       
        //ī�޶� ������ ������ �ʵ��� ����

        leftEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + objectWidth / 2;
        rightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - objectWidth / 2;
        topEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, restrictY, 0)).y - objectHeight / 2;
        bottomEdge = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + objectHeight / 2;


        moveVec = new(Mathf.Clamp(moveVec.x, leftEdge, rightEdge), 
            Mathf.Clamp(moveVec.y, bottomEdge, topEdge));


        rigid.MovePosition(moveVec);

        if (SceneManager.GetActiveScene().name=="Sea" && moveVec.y <= bottomEdge+2f)
        {
            SceneManager.LoadScene("UnderSea");
        }
    }


}
