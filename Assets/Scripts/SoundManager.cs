using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource menuMusic;

    public AudioSource gameMusic;

    public AudioSource flipper1;
    public AudioSource flipper2;
    public AudioSource flipper3;
    public AudioSource flipper4;

    public AudioSource CircleBumper;

    public AudioSource TriBumper;

    public AudioSource powerUp;

    public AudioSource negativeEffect;

    public AudioSource positiveEffect;

    public AudioSource plunger1;
    public AudioSource plunger2;

    public AudioSource drain;

    public AudioSource cashRegister;

    public AudioSource coinClink;

    //Singleton Stuff

    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void playMenuMusin()
    {
        menuMusic.Play();
    }

    public void playGameMusic()
    {
        gameMusic.Play();
    }

    public void playTriBumper()
    {
        TriBumper.Play();
    }
    
    public void playCircleBumper()
    {
        CircleBumper.Play();
    }

    public void playFlipper()
    {
        int sound = Random.Range(1,5);
        switch (sound)
        {
            case 1:
                flipper1.Play();
                return;
            case 2:
                flipper2.Play();
                return;
            case 3:
                flipper3.Play();
                return;
            case 4:
                flipper4.Play();
                return;
        }
    }

    public void playPowerUpPickup()
    {
        powerUp.Play();
    }

    public void playNegativePowerUp()
    {
        negativeEffect.Play();
    }

    public void playPositivePowerUp()
    {
        positiveEffect.Play();
    }

    public void playPlunger()
    {
        int sound = Random.Range(1, 3);
        switch (sound)
        {
            case 1:
                plunger1.Play();
                return;
            case 2:
                plunger2.Play();
                return;
        }
    }

    public void playDrain()
    {
        drain.Play();
    }

    public void playCashRegister()
    {
        cashRegister.Play();
    }

    public void playCoinClink()
    {
        coinClink.Play();
    }
}