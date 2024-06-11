using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;

    public void SetSlider(Slider sldier)
    {
        audioSlider = sldier;
    }
    public void SoundControl()
    {
        float sound = audioSlider.value;
        if (sound == -40)
        {
            Debug.Log("실행");
            audioMixer.SetFloat(audioSlider.name, -80);
        }
        else
        {
            audioMixer.SetFloat(audioSlider.name, sound);
        }
    }

}
