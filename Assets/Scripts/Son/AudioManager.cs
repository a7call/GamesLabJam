using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    public SoundParam[] soundsFx;



    public void Start()
    {
        Play("ArcadeAmbience", this.gameObject);
    }

    
    public void PlayOnDestroyedObject(string name, GameObject sourceObject)
    {
        try{
            SoundParam sp = Array.Find(soundsFx, sound => sound.name.Equals(name));
        
            
            //Si vide, on l'initialise (il va avoir la position de l'objet child)
            if(sp.audioSource == null)
            {

                LoadSourceDifferentPosition(sp, this.gameObject, sourceObject.transform.position);

            }
            if(sp.loop == true){
                sp.audioSource.Play();
            }
            else
            {
                Debug.Log(sp.audioSource.pitch);
                sp.audioSource.PlayOneShot(sp.audioClip);
            }
        }
        catch(NullReferenceException){
            Debug.Log("Audio clip" + name + " non existant");
        }
    }

    public void Play(string name, GameObject sourceObject)
    {
        try{
            SoundParam sp = Array.Find(soundsFx, sound => sound.name.Equals(name));
        

            //Si vide, on l'initialise (il va avoir la position de l'objet child)
            if(sp.audioSource == null)
            {

                LoadSource(sp, sourceObject);

            }
            if(sp.loop == true){
                sp.audioSource.Play();
            }
            else
            {
                sp.audioSource.PlayOneShot(sp.audioClip);
            }
        }
        catch(NullReferenceException){
            Debug.Log("Audio clip" + name + " non existant");
        }
    } 

    public void Stop(string songName)
    {
        try{
            AudioSource[] audioSources = this.GetComponents<AudioSource>();
            Debug.Log("Name : " + songName);

            AudioSource sp = Array.Find(audioSources, audioSource => audioSource.clip.name.Equals(songName));
        
            
            //Si vide, on l'initialise (il va avoir la position de l'objet child)
            if(sp == null)
            {
                Debug.Log("Audio clip" + songName + " VIDE");

            }
            else
            {
                sp.Stop();
            }
        }
        catch(NullReferenceException){
            Debug.Log("Audio clip" + songName + " non existant");
        }
    }


    void LoadSource(SoundParam sp, GameObject sourceObject)
    {
        sp.audioSource = sourceObject.AddComponent<AudioSource>();

        sp.audioSource.clip = sp.audioClip;
        sp.audioSource.volume = sp.volume;

        sp.audioSource.pitch = sp.pitch;
        sp.audioSource.loop = sp.loop;

        sp.audioSource.spatialBlend = sp.spatialBlend;
    }

    void LoadSourceDifferentPosition(SoundParam sp, GameObject sourceObject, Vector3 position)
    {
        Debug.Log("test");
        sp.audioSource = sourceObject.AddComponent<AudioSource>();
        sp.audioSource.transform.position = position;

        sp.audioSource.clip = sp.audioClip;
        sp.audioSource.volume = sp.volume;

        sp.audioSource.pitch = sp.pitch;
        sp.audioSource.loop = sp.loop;

        sp.audioSource.spatialBlend = sp.spatialBlend;
    }

    public void randomPitch(string name, GameObject sourceObject,float pitchValueMin, float picthValueMax){
         try{
            SoundParam sp = Array.Find(soundsFx, sound => sound.name.Equals(name));

            if(sp.audioSource == null)
            {

                LoadSource(sp, sourceObject);

            }

            float rand = UnityEngine.Random.Range(pitchValueMin,picthValueMax);
            sp.audioSource.pitch = rand;


         }
        catch(NullReferenceException){
            Debug.Log("Audio clip" + name + " non existant");
        }
    }
}
