using UnityEngine;
using UnityEngine.UI;

public class ResolutionControl : MonoBehaviour
{
    public Dropdown dropdown;

    public void Start()
    {

    }
    public void setScreen()
    {
        int index = dropdown.value;
        string selectedOption = dropdown.options[index].text;
        switch (selectedOption)
        {
            case "540:960": Screen.SetResolution(540, 960, false); break;
            case "585:1040": Screen.SetResolution(585, 1040, false); break;
            case "603:1072": Screen.SetResolution(603, 1072, false); break;
        }

    }
}
