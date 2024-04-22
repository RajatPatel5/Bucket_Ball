using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class OnMouseHover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Button Button;

    private Vector3 Original_Scale;
    public float Speed;
    public float Increase_Scale;
    private Vector3 Target_Scale;

    private void Start()
    {
        Original_Scale = transform.localScale;
    }

    public void IncreaseScale(Button button)
    {

        Target_Scale = Original_Scale + Vector3.one * Increase_Scale;
        button.transform.localScale = Vector3.Lerp(button.transform.localScale, Target_Scale, Time.deltaTime * Speed);
    }

    public void Defaultscale(Button button)
    {
        button.transform.localScale = Original_Scale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IncreaseScale(Button);     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Defaultscale(Button);
    }
}

