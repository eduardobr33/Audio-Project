using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bellSource;
    public float minDelay = 60f;
    public float maxDelay = 30f;
    public AudioClip bellClip;

    void Start()
    {
        StartCoroutine(PlayBellRandomly());
    }

    IEnumerator PlayBellRandomly()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            if (bellSource != null)
            {
                if (bellClip != null)
                {
                    bellSource.PlayOneShot(bellClip);
                }
                else
                {
                    bellSource.Play();
                }
            }
        }
    }
}
