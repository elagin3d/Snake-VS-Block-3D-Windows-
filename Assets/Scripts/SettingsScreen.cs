using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{

    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    [SerializeField] private Slider SliderVolumeSound;
    [SerializeField] private Slider SliderSensitivityValue;

    void Start()
    {
        SliderVolumeSound.value = _saveLoadSystem.GetVolumeSound();
        SliderSensitivityValue.value = _saveLoadSystem.GetSensitivityValue() / 50;
    }

}
