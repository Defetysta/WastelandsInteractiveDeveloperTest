using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    private AudioSource src;
    [SerializeField]
    private SimpleAudioEvent onAsteroidDestroyed = null;
    public void PlayDestroySound()
    {
        onAsteroidDestroyed.Play(src);
    }

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }
}
