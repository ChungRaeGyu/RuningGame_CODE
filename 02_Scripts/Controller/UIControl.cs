using TMPro;
using UnityEngine;
public class UIControl : MonoBehaviour
{
    [Header("ScoreAndRemain_Canvas")]
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI remainingMonsterTxt;//남은 몬스터

    [Header("EndingPanel_Canvas")]
    public GameObject EndingPanel;
    public TextMeshProUGUI endingBodyTxt;
    public TextMeshProUGUI stageTxt;
    [Header("EndingPanel_Canvas")]
    public GameObject EndingPanel2;
    public TextMeshProUGUI endingBodyTxt2;
    public TextMeshProUGUI stageTxt2;
    [Header("StartingPanel_Canvas")]
    public GameObject StartingPanel;
    public TextMeshProUGUI startingBodyTxt;
    [Header("StopAndPlayer_Canvas")]
    public GameObject stopAndPlayerPanel;


    void Start(){
        EndingPanel.SetActive(false);
        EndingPanel2.SetActive(false);
        stopAndPlayerPanel.SetActive(false);
    }
    void Update()
    {
        remainingMonsterTxt.text = GameManager_CH.Instance.curMonster.ToString();
        scoreTxt.text = GameManager_CH.Instance.curScore.ToString();
    }
    public void EndingPanelControl(bool Active)
    {
        stageTxt.text=$"스테이지{GameManager_CH.Instance.stageData.stageNum.ToString()}";
        EndingPanel.SetActive(Active);
    }
    public void EndingPanelControl2(bool Active)
    {
        stageTxt2.text = $"스테이지{GameManager_CH.Instance.stageData.stageNum.ToString()}";
        EndingPanel2.SetActive(Active);

    }
    public void StartingPanelControl(bool Active){
        StartingPanel.SetActive(Active);
    }


    public void SetStartPanel(){
        StageData stageData = GameManager_CH.Instance.stageData;
        startingBodyTxt.text = $"설명 : 몬스터{stageData.monsterCount}마리 출현";
        startingBodyTxt.gameObject.SetActive(true);
    }
    public void StopAndPlayerPanelControl(){
        stopAndPlayerPanel.SetActive(!stopAndPlayerPanel.activeInHierarchy);
    }
}
