﻿#region Access
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using XavHelpTo.Get;
using XavHelpTo.Change;
using XavHelpTo.Know;
using XavHelpTo.Set;
using XavHelpTo;
using XavHelpTo.Look;
#endregion
public class AudioSystem : MonoBehaviour
{
    #region Variable
    private const string MUSIC_KEY = "MusicVolume";
    private const string SOUND_KEY = "SoundVolume";
    private const float TIMER_FADE = 5;
    private const float MAX_dB = 55f;//dato curioso: Según la OMS, el nivel de ruido que el oído humano puede tolerar sin alterar su salud es de 55 decibeles. Y dependiendo del tiempo de exposición, ruidos mayores a los 60 decibeles pueden provocarnos malestares físicos.
    private static AudioSystem _;
    private Vector2 dBValues;
    private AudioSource src_sound;
    private AudioSource src_generalSound;

    [Header("AudioSystem")]
    public AudioMixer mixer;
    [Space]
    [Header("AudioSystem General Sounds")]
    public AudioClip[] clip_generalSounds;
    #endregion
    #region Event
    private void Awake() {
        this.Singleton(ref _);
        this.Component(out src_sound);
        transform.GetChild(0).Component(out src_generalSound, true);
    }
    #endregion
    #region Method
    /// <summary>
    /// Adjust the Music based in a 0-1 value
    /// </summary>
    public static void SetMusic(float percent) => _.SetAdjustedB(out _.dBValues.x, percent, MUSIC_KEY);
    /// <summary>
    /// Adjust the Sound based in a 0-1 value
    /// </summary>
    public static void SetSound(float percent) => _.SetAdjustedB(out _.dBValues.y, percent, SOUND_KEY);
    /// <summary>
    /// Normalize the value
    /// </summary>
    private float Normalize(float value) => (value.PercentOf(MAX_dB) / 100) + 1 ;
    /// <summary>
    /// Based on the max dB adjust the Volume with the saved percentage
    /// Using <see cref="SavedData"/>
    /// </summary>
    private void SetAdjustedB(out float dB, float percent, string key)
    {
        mixer.GetFloat(key, out dB);
        dB = (-1 + percent).QtyOf(MAX_dB) * 100;
        mixer.SetFloat(key, dB);
    }

    /// <summary>
    /// Plays the music, if exist another playing then trys to go down and set the new one
    /// </summary>
    public static void Play(AudioClip clip) {
        if (_.src_sound.clip && clip.name.Equals(_.src_sound.clip.name)){
            "Se esta intentando una cancion que ya esta puesta".Print("red");
            return;//🛡
        }

        _.StartCoroutine(_.FadePlay(TIMER_FADE, false, clip));
    }

    private IEnumerator FadePlay(float timer, bool fadeIn = true, AudioClip clip=default) {

        int volumeToReach = fadeIn.ToInt();
        float lastVolume = _.src_sound.volume;
        float val = Time.deltaTime / timer;
        float magnitude = lastVolume.UnitInTime(volumeToReach);

        if (!fadeIn) magnitude--;

        while (!_.src_sound.volume.Equals(volumeToReach))
        {
            _.src_sound.volume = (_.src_sound.volume + magnitude).Min(0).Max(1);
            yield return new WaitForSeconds(val);
        }

        //si hay clip...
        if (clip){
            src_sound.clip = clip;
            src_sound.Play();
            $"Sonando {clip.name}".Print("lime");
            StartCoroutine(FadePlay(timer));
        }
    }




    /// <summary>
    /// Playes one of the most common sounds in game
    /// </summary>
    public static void PlaySound(GeneralSounds g) => PlaySound(g.ToInt());
    public static void PlaySound(int index) {
        _.src_generalSound.clip = _.clip_generalSounds[index];
        _.src_generalSound.Play();
        //$"Colocar {(GeneralSounds)index} ".Print("red");
    }
    #endregion
}


/// <summary>
/// General sounds
/// </summary>
public enum GeneralSounds {
    BUTTON = 0,
    BACK_BUTTON = 1,

}
