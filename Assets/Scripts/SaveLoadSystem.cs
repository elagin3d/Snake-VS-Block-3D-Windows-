using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    // �������
    private const string LevelIndexKey = "LevelIndex";
    
    public void SaveLevelIndex(int levelIndex)
    {
        PlayerPrefs.SetInt(LevelIndexKey, levelIndex);
    }

    public int GetLevelIndex()
    {
        return PlayerPrefs.GetInt(LevelIndexKey, 0);
    }
   
    // ����
    private const string VolumeSoundKey = "VolumeSound";

    public void SaveVolumeSound(float VolumeValue)
    {
        PlayerPrefs.SetFloat(VolumeSoundKey, VolumeValue);
    }

    public float GetVolumeSound()
    {
        return PlayerPrefs.GetFloat(VolumeSoundKey, 0.5f);
    }

    // �������������� ����
    private const string SensitivityValueKey = "SensitivityValue";

    public void SaveSensitivityValue(float SensitivityValue)
    {
        PlayerPrefs.SetFloat(SensitivityValueKey, SensitivityValue);
    }

    public float GetSensitivityValue()
    {
        return PlayerPrefs.GetFloat(SensitivityValueKey, 30f);
    }
    
    // ���� ����
    private const string ScoreSnakeKey = "ScoreSnake";

    public void SaveScoreSnake(int ScoreSnake)
    {
        PlayerPrefs.SetInt(ScoreSnakeKey, ScoreSnake);
    }

    public int GetScoreSnake()
    {
        return PlayerPrefs.GetInt(ScoreSnakeKey, 1);
    }

    public void ResetSave() // ����� �� ����
    {
        SaveLevelIndex(0);
        SaveVolumeSound(0.5f);
        SaveSensitivityValue(30f);
        SaveScoreSnake(1);
    }
}
