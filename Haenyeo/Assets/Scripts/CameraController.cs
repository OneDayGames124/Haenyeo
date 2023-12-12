using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �������� ���� �ӵ�
    public Transform target; // ī�޶� ���� ������Ʈ�� Transform ������Ʈ


    private void Start()
    {
        //target = GameObject.Find("UnderSea_Player").transform;
    }
    private void LateUpdate()
    {
        
        Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        if(target.transform.position.y<=0 || transform.position.y <=0)
            transform.position = smoothedPosition;
        

    }
}
