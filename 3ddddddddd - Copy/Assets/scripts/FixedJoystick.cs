using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
[System.Serializable]
public enum JoyStickDirection { Horrizontal, Vertical, Both }

public class FixedJoystick : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler {
	//dont ask the joystick is downloaded OK!!
	public RectTransform Background;
	public JoyStickDirection JoyStickDirection = JoyStickDirection.Both;
	public RectTransform handle;
	[Range(0, 2f)] public float handleLimit = 1f;
	private Vector2 input = Vector2.zero;
	//Output
	public float Vertical { get { return input.y; } }
	public float Horrizontal { get { return input.x; } }
	public void OnPointerDown(PointerEventData eventData)
    {
		OnDrag(eventData);
    }
	public void OnDrag(PointerEventData eventData)
	{
		Vector2 JoyDirection = eventData.position - RectTransformUtility.WorldToScreenPoint(new Camera(), Background.position);
		input = (JoyDirection.magnitude > Background.sizeDelta.x / 2f) ? JoyDirection.normalized :
			JoyDirection / (Background.sizeDelta.x / 2f);
		if (JoyStickDirection == JoyStickDirection.Horrizontal)
        {
			input = new Vector2(input.x, 0f);
        }
		if (JoyStickDirection == JoyStickDirection.Vertical)
        {
			input = new Vector2(0f, input.y);
        }
		handle.anchoredPosition = (input * Background.sizeDelta.x / 2f)*handleLimit;
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		input = Vector2.zero;
		handle.anchoredPosition = Vector2.zero;
	}

}
