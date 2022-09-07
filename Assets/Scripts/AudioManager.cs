using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _addBodySound;
    [SerializeField] private AudioClip _finishSound;
    [SerializeField] private AudioClip _gameOverSound;
    [SerializeField] private AudioClip _blockDestroySound;
    [SerializeField] private AudioClip _removeBodySound;
    //
    [SerializeField] private SaveLoadSystem _saveLoadSystem;
    private float _volumeSound;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _volumeSound = _saveLoadSystem.GetVolumeSound();
        _audioSource.volume = _volumeSound;
        //
        Body.AddBody.AddListener(PlayAddBodySound);
        Finish.FinishEvent.AddListener(PlayFinishSound);
        SnakeManager.GameOver.AddListener(PlayGameOverSound);
        SnakeManager.RemoveBodyEvent.AddListener(PlayRemoveBodySound);
        Block.BlockDestroy.AddListener(PlayBlockDestroySound);
    }
    public void SetVolume(float vol) // Âûחמג קונוח סכאיהונ
    {
        _volumeSound = vol;
        _saveLoadSystem.SaveVolumeSound(_volumeSound);
        _audioSource.volume = _volumeSound;
    }

    private void PlayAddBodySound()
    {
        _audioSource.PlayOneShot(_addBodySound);
    }
    private void PlayFinishSound()
    {
        _audioSource.PlayOneShot(_finishSound);
    }
    private void PlayGameOverSound()
    {
        _audioSource.PlayOneShot(_gameOverSound);
    }
    private void PlayBlockDestroySound()
    {
        _audioSource.PlayOneShot(_blockDestroySound);
    }
    private void PlayRemoveBodySound()
    {
        _audioSource.PlayOneShot(_removeBodySound);
    }
}
