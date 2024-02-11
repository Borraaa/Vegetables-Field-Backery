using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioClipType { grapClip, shopClip }
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource audioSource;
    public AudioClip grapClip, shopClip;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio(AudioClipType cliptype)
    {
        if (audioSource != null)
        {
            AudioClip audioClip = null;
            if (cliptype == AudioClipType.grapClip)
            {
                audioClip = grapClip;
            }
            else if(cliptype == AudioClipType.shopClip)
            {
                audioClip = shopClip;
            }
            audioSource.PlayOneShot(audioClip, 0.6f);
        }
    }
    public void StopBackgraundMusic() // arka plan müziðinin sürekli çalmasýný istemiyorsak
    {
        Camera.main.GetComponent<AudioSource>().Stop();// kameraya baðlý olduðu için kamerayý almamýz lazým
    }
}
