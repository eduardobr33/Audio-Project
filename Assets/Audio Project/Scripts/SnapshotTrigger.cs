using UnityEngine;
using UnityEngine.Audio;

public class SnapshotTrigger : MonoBehaviour
{
    public AudioMixerSnapshot interiorSnapshot;
    public AudioMixerSnapshot exteriorSnapshot;
    public float transitionTime = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interiorSnapshot.TransitionTo(transitionTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exteriorSnapshot.TransitionTo(transitionTime);
        }
    }
}
