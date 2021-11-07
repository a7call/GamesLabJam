using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    public SoundParam[] soundsFx;

    public SoundParam[] impacts;

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

    public void playRandomPitch(string name, GameObject sourceObject,float pitchValueMin, float picthValueMax){
         try{
            SoundParam sp = Array.Find(soundsFx, sound => sound.name.Equals(name));

            if(sp.audioSource == null)
            {

                LoadSource(sp, sourceObject);

            }

            float rand = UnityEngine.Random.Range(pitchValueMin,picthValueMax);
            sp.audioSource.pitch = rand;
            sp.audioSource.PlayOneShot(sp.audioClip);


         }
        catch(NullReferenceException){
            Debug.Log("Audio clip" + name + " non existant");
        }
    }

    public void playFXRandom()
    {
            try{
            // Debug.Log("Name : " + songName);
           

            int fxChosen = UnityEngine.Random.Range(0,impacts.Length); 
            Debug.Log("fxChosen : " + fxChosen );
            SoundParam sp = impacts[fxChosen];
        
            Debug.Log("sfx : " + sp.audioClip.name);
            //Si vide, on l'initialise (il va avoir la position de l'objet child)
            if(sp.audioSource == null)
            {

                LoadSource(sp, this.gameObject);

            }
            sp.audioSource.PlayOneShot(sp.audioClip);
        }
        catch(NullReferenceException){
        Debug.Log("Audio clip" + impacts[0] + " non existant");
        }
    }


    public void pointsClassic()
    {
        if (Time.timeScale == 0)
            return;
        //Impact1
        playRandomPitch("Impact1", this.gameObject, 0.8f, 1.1f);
        //Impact2
        playRandomPitch("Impact2", this.gameObject, 0.7f, 1.1f);
        playRandomPitch("Impact3", this.gameObject, 0.9f, 1.1f);
        playRandomPitch("Impact4", this.gameObject, 0.7f, 1.2f);


        //FX
        playFXRandom();
    }

    public void pointsToy()
    {
        if (Time.timeScale == 0)
            return;
        //Impact1
        Play("Impact1", this.gameObject);
        playRandomPitch("Impact3", this.gameObject, 0.9f, 1.1f);
        playRandomPitch("Impact4", this.gameObject, 0.7f, 1.2f);

        //FX stylé
        Play("ToyCatched", this.gameObject);
    }

    public void failedSound()
    {
        if (Time.timeScale == 0)
            return;
        playRandomPitch("Impact4", this.gameObject, 0.7f, 1.2f);

        Play("Failed", this.gameObject);
    }
}
