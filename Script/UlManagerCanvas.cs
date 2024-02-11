using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UlManagerCanvas : MonoBehaviour
{


    public static UlManagerCanvas instance;
    private bool radialshine;
    

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

    [SerializeField] private Animator layoutAnimator;


    


    //butonlar
    [SerializeField] private GameObject settingsOpen;
    [SerializeField] private GameObject settingsClose;

    [SerializeField] private GameObject soundOn;
    [SerializeField] private GameObject soundOff;

    [SerializeField] private GameObject vibrationOn;
    [SerializeField] private GameObject vibrationOff;

    [SerializeField] private GameObject iap;
    [SerializeField] private GameObject information;

    [SerializeField] private GameObject leaderboard;

    // oyun sonu ekraný
    [SerializeField] private GameObject finishscreen;
    [SerializeField] private GameObject blackbackgrauns;
    [SerializeField] private GameObject complate;
    [SerializeField] private GameObject radial_shine;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject rewarded;
    [SerializeField] private GameObject nothanks;

    [SerializeField] private GameObject achivedinvertory;
    [SerializeField] private GameObject nextlevelbtn;
    [SerializeField] private Text achivedinvertorycoinText;

    [SerializeField] private GameObject leaderopen;
    [SerializeField] private GameObject leaderclose;

    [SerializeField] private GameObject leaderboardopen;
    [SerializeField] private GameObject leaderboardclose;
    void Update()
    {
        if (radialshine == true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 15f * Time.deltaTime));
        }
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radialshine = true;
        finishscreen.SetActive(true);
        blackbackgrauns.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complate.SetActive(true);
        yield return new WaitForSecondsRealtime(1.3f);
        radial_shine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        nothanks.SetActive(true);
    }

    public IEnumerator AfterRewordButton()
    {
        achivedinvertory.SetActive(true);
        achivedinvertorycoinText.gameObject.SetActive(true);
        
        for (int i = 0; i <= 100; i += 4)
        {
            achivedinvertorycoinText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
            
        }
        //yield return new WaitForSecondsRealtime(0.8f);
        
        
        yield return new WaitForSecondsRealtime(1f);
        nextlevelbtn.SetActive(true);

        rewarded.SetActive(false);
        nothanks.SetActive(false);

    }


    public void PrivacyPolicy()
    {
        Application.OpenURL("https://www.tosugames.com/privacy-policy/");
    }
    public void TermOfUse()
    {
        Application.OpenURL("https://www.tosugames.com/sample-page/");
    }

    // Start is called before the first frame update
    void Start()
    {
        



        if (PlayerPrefs.HasKey("sound") == false)// burada sound adýnda bir deðilken kontrol et var mý yok mu diye eðer bu varsa oyunu 2. defa açtýðýnda bu if true olucak ve girmiycek.ama ilk defa açtýðýnda oyunu sound u arycak soundu bulamýycak oyunu ilk defa açýyor. açtýktan sonra sounda 1 deðerini vericek 
        {
            PlayerPrefs.SetInt("sound", 1);
        }
        if (PlayerPrefs.HasKey("vibration") == false)
        {
            PlayerPrefs.SetInt("vibration", 1);
        }
    }
    
    

    public void LeaderBoardOpen()
    {
        leaderopen.SetActive(false);
        leaderclose.SetActive(true);
        leaderboardopen.SetActive(false);
        leaderboardclose.SetActive(true);

    }
    public void LeaderBoardClose()
    {
        leaderopen.SetActive(true);
        leaderclose.SetActive(false);
        leaderboardopen.SetActive(true);
        leaderboardclose.SetActive(false);
    }
    

    
    //button fonksiyonlarý
    public void SettingsOpen()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        layoutAnimator.SetTrigger("Slide_in");
        if (PlayerPrefs.GetInt("sound") == 1)//sound 1 se yani müzik açýksa
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            AudioListener.volume = 1;
            // eðer durum 1 se müzik açýk demektir ve bunu kapatýcaðýmýz durumdaki butonlarý çekmemiz gerekir 
        }
        else if (PlayerPrefs.GetInt("sound") == 2)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("vibration") == 1)
        {
            vibrationOn.SetActive(true);
            vibrationOff.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("vibration") == 2)
        {
            vibrationOn.SetActive(false);
            vibrationOff.SetActive(true);
        }
        
    }
    public void SettingsClose()
    {
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
        layoutAnimator.SetTrigger("Slide_out");
    }

    public void SoundOn()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioListener.volume = 0; //ses butonuna bastýðý anda sesi 0 yapar
        PlayerPrefs.SetInt("sound", 2);  
    }
    public void SoundOff()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("sound", 1);
    }
    public void VibrationOn()
    {
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("vibration", 2);
    }
    public void VibrationOff()
    {
        vibrationOn.SetActive(true);
        vibrationOff.SetActive(false);
        PlayerPrefs.SetInt("vibration", 1);
    }

}
