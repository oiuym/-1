using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speed = 5.0f;
    public float startPosition;
    public float endPosition;
    void Update()
    {
        // �� ������ x �������� ���ݾ� �̵���Ų��
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        // ��ũ���� ��ǥ �������� �����ߴ��� üũ
        if (transform.position.x <= endPosition) ScrollEnd();
    }
    void ScrollEnd()
    {
        // ��ũ���� �Ÿ� ��ŭ�� �ǵ�����
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);
        // ������ ���� ������Ʈ�� ����Ǿ� �ִ� ������Ʈ�� �޽����� ������
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
}
