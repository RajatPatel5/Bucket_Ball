using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : BaseScreen
{
    [SerializeField] Button nextButton;
    [SerializeField] Button homeButton;
    
   


    private void Start()
    {

        nextButton.onClick.AddListener(Onnext);
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

    void Onnext()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        //  UiManager.instance.SwitchScreen(GameScreens.Play);
        SoundManager.inst.PlaySound(SoundName.soundOn);
        SceneManager.LoadScene("level2");

    }
    void OnHome()
    {
        //AudioManager.instance.Play(SoundName.ButtonSound);
        SoundManager.inst.PlaySound(SoundName.soundOn);
        /*UiManager.instance.SwitchScreen(GameScreens.Home);*/
        SceneManager.LoadSceneAsync(0);
       
    }

}
