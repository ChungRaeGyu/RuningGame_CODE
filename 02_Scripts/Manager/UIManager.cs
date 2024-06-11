using UnityEngine;

public class UIManager : MonoBehaviour
{
    public UIControl uiControl;
    public ButtonControl buttonControl;
    // Start is called before the first frame update
    void Awake(){
        uiControl = GetComponent<UIControl>();
        buttonControl = GetComponent<ButtonControl>();
    }
    void Start()
    {
        GameManager_CH.Instance.uiManager = this;
        buttonControl.StartBtn+= StartBtnAction;
        uiControl.SetStartPanel();
    }

    void StartBtnAction(){
        uiControl.StartingPanelControl(false);
    }

    public void PlayAndStopBtn(){
        Debug.Log("실행");
        buttonControl.PlayAndStop();
        uiControl.StopAndPlayerPanelControl();
    }
}
