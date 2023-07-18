using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TriggerAllarm : MonoBehaviour
{
    private AudioSource _alarmSound;
    private float _fadeTime = 2f;
    private Coroutine _changeSound;

    private IEnumerator StartFade(float targetVolume)
    {
        _alarmSound = GetComponent<AudioSource>();
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

    public void PlaySound(float strengthSound)
    {
        if(_changeSound != null)
        {
            StopCoroutine(_changeSound);
        }

        _changeSound = StartCoroutine(StartFade(strengthSound));
    }
}
