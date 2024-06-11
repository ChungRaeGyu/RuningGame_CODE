using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public Transform[] backgrounds; // 배경 오브젝트들의 Transform 배열
    public float scrollSpeed; // 배경 스크롤 속도

    private float backgroundLength; // 배경의 길이

    void Start()
    {
        backgroundLength = 65;
    }

    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += Vector3.back * scrollSpeed * Time.deltaTime;

            if (backgrounds[i].position.z < -backgroundLength)
            {
                RepositionBackground(i);
            }
        }
    }

    void RepositionBackground(int index)
    {
        backgrounds[index].gameObject.SetActive(false);

        Vector3 newPos = backgrounds[index].position;
        newPos.z += backgrounds.Length * backgroundLength;
        backgrounds[index].position = newPos;

        backgrounds[index].gameObject.SetActive(true);
    }

}
