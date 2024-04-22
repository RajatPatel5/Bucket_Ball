using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScreen : BaseScreen
{
    [SerializeField] private Slider slider;

    bool LodingComplet = false;

    // Update is called once per frame
    void Update()
    {
        if (slider.value >= 0.97 && !LodingComplet)
        {
            UiManager.instance.SwitchScreen(GameScreens.Home);
            Debug.Log("done");
            LodingComplet = true;
        }
    }
}
