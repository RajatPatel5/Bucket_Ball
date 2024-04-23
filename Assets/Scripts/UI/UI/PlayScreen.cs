using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayScreen : BaseScreen
{
    [SerializeField] Button musicOnButton;
    [SerializeField] Button musicOffButton;
    [SerializeField] Button soundOffButton;
    [SerializeField] Button soundOnButton;
    public Image image1;
    public Image image2;

    [SerializeField] private GameObject player;
    private void Start()
    {
        musicOnButton.onClick.AddListener(OnMusic);
        musicOffButton.onClick.AddListener(OffMusic);
        soundOnButton.onClick.AddListener(OnSound);
        soundOffButton.onClick.AddListener(OffSound);
    }

    void OnMusic()
    {
        SoundManager.inst.PlaySound(SoundName.soundOn);
        image1.enabled = false;    
    }

    void OffMusic()
    {
        SoundManager.inst.PlaySound(SoundName.soundOn);
        image1.enabled = true;
    }


    void OnSound()
    {      
        SoundManager.inst.PlaySound(SoundName.soundOn);     
        image2.enabled = false;
    }

    void OffSound()
    {
        SoundManager.inst.PlaySound(SoundName.soundOn);
        image2.enabled = true;
    }


    public override void ActivateScreen()
    {
        base.ActivateScreen();

        player.SetActive(true);
    }
    public override void DeactivateScreen()
    {
        base.DeactivateScreen();
        player.SetActive(false);

    }
}
