using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Events/Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
    public AudioClip[] clips;

    public RangedFloat volume;

    [MinMaxRange(0, 2)]
    public RangedFloat pitch;

    public override void Play(AudioSource source)
    {
        if (clips.Length == 0) return;

        source.clip = clips[Random.Range(0, clips.Length)];
        source.volume = Random.Range(volume.minValue, volume.maxValue);
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.Play();
    }
    public override void Reset()
    {
        volume.minValue = 0.5f;
        volume.maxValue = 1f;
        pitch.minValue = 0.9f;
        pitch.maxValue = 1.1f;
    }

}
