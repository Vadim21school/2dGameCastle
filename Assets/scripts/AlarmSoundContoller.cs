using System.Collections;
using UnityEngine;

public class AlarmSoundContoller : MonoBehaviour
{
    private AudioSource _alarmSound;
    [SerializeField] private GameObject _flash;
    private float _maxVolume = 1f;
    private float _fadeTime = 2f;
    private float _minVolume = 0f;

    private bool _fading = false;

    void Start()
    {
        _alarmSound = GetComponent<AudioSource>();
    }

    private IEnumerator StartFade(float targetVolume)
    {
        _fading = true;
        float startVolume = _alarmSound.volume;
        float elapsedTime = 0f;

        _alarmSound.Play();

        while (elapsedTime < _fadeTime)
        {
            elapsedTime += Time.deltaTime;
            _alarmSound.volume = Mathf.MoveTowards(startVolume, targetVolume, elapsedTime / _fadeTime);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _flash.SetActive(true);
            TriggerAlarm(_maxVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _flash.SetActive(false);
            TriggerAlarm(_minVolume);
        }
    }

    private void TriggerAlarm(float volume)
    {
        StartCoroutine(StartFade(volume));
    }
}
