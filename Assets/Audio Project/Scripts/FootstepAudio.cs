using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] concreteClips;
    public AudioClip[] grassClips;
    public float stepDelay = 1.5f;
    private float stepTimer;
    public CharacterController controller;

    private string currentSurface = "Concrete";

    void Update()
    {
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer > stepDelay)
            {
                PlayFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepDelay;
        }
    }

    void PlayFootstep()
    {
        AudioClip[] selectedClips;

        switch (currentSurface)
        {
            case "Grass":
                selectedClips = grassClips;
                break;
            default:
                selectedClips = concreteClips;
                break;
        }

        if (selectedClips.Length > 0)
        {
            int index = Random.Range(0, selectedClips.Length);
            audioSource.PlayOneShot(selectedClips[index]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grass"))
        {
            currentSurface = "Grass";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grass"))
        {
            currentSurface = "Concrete";
        }
    }
}
