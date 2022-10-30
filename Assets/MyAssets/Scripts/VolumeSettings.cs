using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField, Tooltip("Mixer Maestro")]
    private AudioMixer _mixer;

    [SerializeField, Tooltip("Volumen Maestro")]
    private Slider _masterSlider;

    [SerializeField, Tooltip("Volumen Micrófono")]
    private Slider _microphoneSlider;

    [SerializeField, Tooltip("Volumen del altavoz")]
    private Slider _speakersSlider;

    [SerializeField, Tooltip("Volumen Música")]
    private Slider _musicSlider;

    [SerializeField, Tooltip("Volumen SFX")]
    private Slider _sfxSlider;

    private const string MIXER_MASTER = "MasterVolume";
    private const string MIXER_MICROPHONE = "MicrophoneVolume";
    private const string MIXER_SPEAKERS = "SpeakersVolume";
    private const string MIXER_MUSIC = "MusicVolume";
    private const string MIXER_FX = "SFXVolume";


    private void Awake()
    {
        _masterSlider.onValueChanged.AddListener(SetMasterVolume);
        _microphoneSlider.onValueChanged.AddListener(SetMicrophoneVolume);
        _speakersSlider.onValueChanged.AddListener(SetSpeakersVolume);
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void SetMasterVolume(float value)
    {
        _mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
    }

    private void SetMicrophoneVolume(float value)
    {
        _mixer.SetFloat(MIXER_MICROPHONE, Mathf.Log10(value) * 20);
    }

    private void SetSpeakersVolume(float value)
    {
        _mixer.SetFloat(MIXER_SPEAKERS, Mathf.Log10(value) * 20);
    }

    private void SetMusicVolume(float value)
    {
        _mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    private void SetSFXVolume(float value)
    {
        _mixer.SetFloat(MIXER_FX, Mathf.Log10(value) * 20);
    }
}