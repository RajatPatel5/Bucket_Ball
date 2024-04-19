using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : BaseScreen
{
    [SerializeField] Button startButton;
    private void Start()
    {

        startButton.onClick.AddListener(OnStart);
       

    }
     public override void ActivateScreen()
    {
        //AudioManager.instance.PlayInBackGround(SoundName.HomeScreenSound);
        base.ActivateScreen();
    }
    void OnStart()
    {
        // AudioManager.instance.Play(SoundName.ButtonSound);
        SoundManager.inst.PlaySound(SoundName.soundOn);
        UiManager.instance.SwitchScreen(GameScreens.Play);
    }
  
}
