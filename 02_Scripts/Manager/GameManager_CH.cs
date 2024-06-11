using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager_CH : MonoBehaviour
{
    #region 싱글톤
    private static GameManager_CH _instance;
    public static GameManager_CH Instance
    {
        get{
            if(_instance == null){
                _instance = new GameObject("GameManager").AddComponent<GameManager_CH>();
            }
            return _instance;
        }
    }
    void Awake(){
        if(_instance != null)
        {
            if(_instance != this)
                Destroy(gameObject);
        }else{
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion
    public AchievementManager_CH achievementManager_CH;
    public DataManager_CH dataManager;
    public UIManager uiManager;
    public bool isStart = false;
    public StageData stageData;
    public int curMonster;
    public int curScore;
    public ObjectManager objectManager;


    void Start(){
        Time.timeScale =1;
        dataManager.LoadGameData();
    }
    void Update(){
        if(isStart){
            //1.로비에서 스테이지를 고른다. 스테이지에 따라서 몬스터의 숫자가 달라질 예정이다.
            //2.몬스터를 다 죽이면 GameOver 호출
            if(curMonster == 0){
                GameClear();
            }
        }
    }

    public void OnStartSetData(){
        Time.timeScale = 1;
        curMonster = stageData.monsterCount;
        curScore = 0;
        isStart =true;
    }

    public void Lobby(){
        SceneManager.LoadScene("Lobby");
    }

    //프로그램 종료시 자동 저장
    private void OnApplicationQuit() {
        dataManager.SaveGameData();
    }

    public void GameClear(){
        //EndingPanel이 나오고 게임이 멈춘다.
        uiManager.uiControl.EndingPanelControl(true);
        Time.timeScale=0;
        dataManager.data.stages[stageData.stageNum-1] = true;
        isStart = false;
        stageData = null;
        achievementManager_CH.CheckClear();
        //이 true값을 가지고 버튼이 생성되도록 하면 되겠다.
        //스테이지를 받아와서 Data에 클리어 했다고 표시 해준다.
    }
    public void GameOver()
    {
        uiManager.uiControl.EndingPanelControl2(true);
        Time.timeScale = 0;
        dataManager.data.stages[stageData.stageNum - 1] = true;
        isStart = false;
        stageData = null;
        achievementManager_CH.CheckClear();
    }
    //점수 추가
    public void AddScore(int value){
        curScore+=value;
    }
    //몬스터가 죽었을 때 경험치
    public void AddExp(int monsterLevel){
        if (dataManager.data.level > 4) return;
        dataManager.ExpCondition(monsterLevel);
    }

}
