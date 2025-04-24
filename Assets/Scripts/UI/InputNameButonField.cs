using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputNameButonField : UIHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image imagetoDisable;
    private bool hasInputText = false;

    void Start()
    {
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(OnInputChange);
        }
    }

    public override void OnInputChange(string value) 
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            hasInputText = true;
            imagetoDisable.enabled = false;
        }
    }
    public override void OnInputFieldMouseEnter() 
    {
        if (!hasInputText)
        {
            imagetoDisable.enabled = false;
        }
    }

    public override void OnInputFieldMouseExit() 
    {
        if (imagetoDisable != null && !hasInputText)
        {
            imagetoDisable.enabled = true;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        OnInputFieldMouseExit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnInputFieldMouseEnter();
    }
}
