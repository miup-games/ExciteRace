using UnityEngine;
using System.Collections;
using System;

public class CountDownController : MonoBehaviour
{
    [SerializeField] AudioSource _beep;

    private Action onCountDownFinished;

    public void Init(Action cb)
    {
        onCountDownFinished = cb;
        StartCoroutine(StartSecuence());
    }

    private IEnumerator StartSecuence()
    {        
        yield return new WaitForSeconds(1);
        PlayBeep();
        yield return new WaitForSeconds(1);
        PlayBeep();
        yield return new WaitForSeconds(1);
        PlayBeep();
        yield return new WaitForSeconds(1);
        PlayBeep(true);

        if (onCountDownFinished != null)
        {
            onCountDownFinished();
        }
    }


    private void PlayBeep(bool finalBeep = false)
    {
        if (finalBeep)
        {
            _beep.pitch += 0.5f;
        }
        _beep.Play();
    }
}
