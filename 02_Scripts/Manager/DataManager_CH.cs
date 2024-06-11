using System.IO;
using UnityEngine;

public class DataManager_CH : MonoBehaviour
{
    string FileName = "GameData.json";
    public Data data; 
    void Start(){
        GameManager_CH.Instance.dataManager = this;
    }
    public void LoadGameData(){
        string filePath = Application.persistentDataPath + "/" + FileName;

        if(File.Exists(filePath)){
            //File속 내용을 받아온다.
            string FromJsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<Data>(FromJsonData);
            GameManager_CH.Instance.achievementManager_CH.LoadAchievementManager();
            Debug.Log("불러오기");
        }
        else{
            GameManager_CH.Instance.achievementManager_CH.GenerateData();
            Debug.Log("업적생성");
        }
        
    }
    public void SaveGameData(){
        
        //PlayerScript를 한번 찾아보고 밑에 것처럼 저장을 따로 해주어야 한다면 SaveData메소드를 만들 예정;
        GameManager_CH.Instance.achievementManager_CH.SaveAchievementManager();
        //true 는 prettyPrint Json파일이 예쁘게 정리되어있다.
        string ToJsonData = JsonUtility.ToJson(data, true);
        //파일 저장 위치 : 사용자디렉토리/AppData/LocalLow/회사이름/프로덕트이름 (파일 읽기 쓰기 가능)
        string filePath = Application.persistentDataPath+"/"+ FileName;
        
        //이미 저장된 파일이 있다면 덮어쓰고, 없다면 새로 만든다.
        File.WriteAllText(filePath,ToJsonData);

        Debug.Log("저장완료");
    }

    //경험치 + Level업
    public void ExpCondition(int monsterLevel)
    {
        data.exp += monsterLevel;
        if (data.exp > data.maxExp[data.level])
        {
            data.level++;
        }
    }
}
