using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioSource SESource;

    [SerializeField] private List<BGMSoundData> bgmSoundDatas;
    [SerializeField] private List<SESoundData> seSoundDatas;

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance  == null )
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        BGMSource.clip = data.audioClip;
        BGMSource.volume = data.volume * masterVolume * bgmMasterVolume;
        BGMSource.Play();
    }

    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        SESource.clip = data.audioClip;
        SESource.volume = data.volume * masterVolume * seMasterVolume;
        SESource.PlayOneShot(data.audioClip);
    }
}

[System.Serializable]
public class BGMSoundData
{
    //ƒ‰ƒxƒ‹
    public enum BGM
    {
        Title,
        Stage,
        GameOver,
        GameClear
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    //ƒ‰ƒxƒ‹
    public enum SE
    {
        PlayerAttack,
        PlayerDamage,
        PlayerJump
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}
