using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class FadeInOutUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>(); 
    }
    private void Start()
    {
        text.DOFade(0.0f, 1f).SetLoops(-1,LoopType.Yoyo);
    }
}
