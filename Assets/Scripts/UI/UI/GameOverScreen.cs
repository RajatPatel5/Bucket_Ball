using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : BaseScreen
{
    [SerializeField] Button restartButton;
    [SerializeField] Button homeButton;
   
  
    private void Start()
    {

        restartButton.onClick.AddListener(OnReplay);
        homeButton.onClick.AddListener(OnHome);
    }
    public override void ActivateScreen()
    {
        //AudioManager.instance.PlayInBackGround(SoundName.GameOverSound);
        base.ActivateScreen();
       
    }
    public override void DeactivateScreen()
    {
        base.DeactivateScreen();
    }
    void OnReplay()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        SoundManager.inst.PlaySound(SoundName.soundOn);
        UiManager.instance.SwitchScreen(GameScreens.Play);
        
    }
    void OnHome()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        SoundManager.inst.PlaySound(SoundName.soundOn);
        //UiManager.instance.SwitchScreen(GameScreens.Home);
        SceneManager.LoadSceneAsync(0);

    }

}
