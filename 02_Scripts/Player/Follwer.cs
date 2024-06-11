

using UnityEngine;
using UnityEngine.UI;

public class HealthBarFollowPlayer : MonoBehaviour
{
    public Slider healthSlider; // 체력을 나타내는 UI 슬라이더
    public Transform player; // 플레이어의 Transform

    void Update()
    {
        // 플레이어의 위치를 월드 좌표로 변환하여 가져옴
        Vector3 worldPosition = player.position;

        // 플레이어의 월드 좌표를 스크린 좌표로 변환
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

        // 슬라이더의 위치를 플레이어의 위쪽으로 설정
        healthSlider.transform.position = screenPosition + new Vector3(0, 80, 0);
    }
}
