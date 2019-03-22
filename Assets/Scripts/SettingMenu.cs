using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour {

    public AudioMixer MainAudioMixer;

    public void SetVolume (float value)
    {
        MainAudioMixer.SetFloat("volume", value);
    }
}
