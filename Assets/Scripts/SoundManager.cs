using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
  
    public static SoundManager inst;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioSource bgaudiosource;
    [SerializeField] Sound[] clips;
   
    private void Awake()
    {
        inst = this;
    }

    //public void Update()
    //{
    //    bgaudiosource.volume = 
    //    audiosource.volume = 
    //}
    public void PlaySound(SoundName name)
    {
        foreach (var item in clips)
        {
            if (item.name == name)
            {
                audiosource.PlayOneShot(item.clip);
                break;
            }
        }
    }

    public void SoundMute()
    {
        audiosource.enabled = false;
    }

    public void Sound()
    {
        audiosource.enabled = true;
    }

    public void MusicMute()
    { 
      bgaudiosource.enabled = false;
    }

    public void Music()
    {
        bgaudiosource.enabled = true;
    }
}
[System.Serializable]
public class Sound
{
    public SoundName name;
    public AudioClip clip;

}

public enum SoundName
{
    soundOn,
    musicOn,
    jump,
    win,
    gameOver
}


