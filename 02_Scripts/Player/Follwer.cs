

using UnityEngine;
using UnityEngine.UI;

public class HealthBarFollowPlayer : MonoBehaviour
{
    public Slider healthSlider; // ü���� ��Ÿ���� UI �����̴�
    public Transform player; // �÷��̾��� Transform

    void Update()
    {
        // �÷��̾��� ��ġ�� ���� ��ǥ�� ��ȯ�Ͽ� ������
        Vector3 worldPosition = player.position;

        // �÷��̾��� ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        // �����̴��� ��ġ�� �÷��̾��� �������� ����
        healthSlider.transform.position = screenPosition + new Vector3(0, 80, 0);
    }
}
