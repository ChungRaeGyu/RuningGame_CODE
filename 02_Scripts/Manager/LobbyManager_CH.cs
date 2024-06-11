using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager_CH : MonoBehaviour
{
    Color trueColor = new Color(255/255, 255/255, 255/255);
    Color falseColor = new Color(97f/255f,97f/255f,97f/255f);

    public GameObject[] stages;
    
    [Header("AchievementPanel")]
    public GameObject AchievementPanel;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI descriptionTxt;
    public TextMeshProUGUI progressTxt;

    
    void Start(){
        Time.timeScale = 1;
        for (int i=1; i<stages.Length;i++){
            bool check = GameManager_CH.Instance.dataManager.data.stages[i - 1];
            stages[i].GetComponent<Image>().color = check ? trueColor:falseColor;
            stages[i].GetComponent<Button>().enabled = check;
        }
    }
    public void GameScene(StageData stageData)
    {
        GameManager_CH.Instance.stageData=stageData;
        Time.timeScale = 0;
        SceneManager.LoadScene("GameMainScene");
    }
    public void AchievementBtn(){
        AchievementData data = GameManager_CH.Instance.achievementManager_CH.AchievementList[(int)Type.MONSTER];
        nameTxt.text = data.name;
        descriptionTxt.text = data.description;
        progressTxt.text = $"{data.curCount} / {data.maxCount[data.level]}";
        AchievementPanel.SetActive(!AchievementPanel.activeInHierarchy);
    }
}
