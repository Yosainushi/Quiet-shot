using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Joystiks :  MonoBehaviour,IDragHandler, IPointerDownHandler, IPointerUpHandler
{
     public Image bgImg { get; set; }
     public Image joystick { get; set; }
     public Vector2 inputVector { get; set; }
     internal bool isTouched { get; set; }

     

     public void OnDrag(PointerEventData eventData)
     {
          Vector2 pos;
          if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
          {
               pos.x = (pos.x / transform.GetComponent<CircleCollider2D>().radius);
               pos.y = (pos.y /transform.GetComponent<CircleCollider2D>().radius );
               inputVector = new Vector2(pos.x, pos.y);
               inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

               joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (transform.GetComponent<CircleCollider2D>().radius),
                    inputVector.y * (transform.GetComponent<CircleCollider2D>().radius));
          }
     }

     public void OnPointerDown(PointerEventData eventData)
     {
          isTouched = true;
          OnDrag(eventData);
     }

     public virtual void OnPointerUp(PointerEventData eventData)
     {
          isTouched = false;
          inputVector = Vector2.zero;
          joystick.rectTransform.anchoredPosition = Vector2.zero;
          MoveController.instanse.StopMove();
     }
}
