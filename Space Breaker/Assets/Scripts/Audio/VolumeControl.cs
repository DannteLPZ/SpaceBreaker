using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixer _mainMixer;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private string _parameter;

    private void Start()
    {
        _volumeSlider.onValueChanged.AddListener(x => ChangeVolume());
        _volumeSlider.value = PlayerPrefs.GetFloat(_parameter, _volumeSlider.value);

    }

    private void ChangeVolume()
    {
        _mainMixer.SetFloat(_parameter, _volumeSlider.value);
        PlayerPrefs.SetFloat(_parameter, _volumeSlider.value);
    }
}
