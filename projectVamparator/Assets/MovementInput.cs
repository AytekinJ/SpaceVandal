using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MovementClass
{
    public class MovementInput : MonoBehaviour
    {
        public RectTransform panelRectTransform;
        public Camera uiCamera;

        private Vector2 joystickCenter;
        public static Vector2 joystickDirection;

        void Start()
        {
            joystickCenter = panelRectTransform.rect.center;
        }

        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector2 touchPosition;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, touch.position, uiCamera, out touchPosition);

                if (RectTransformUtility.RectangleContainsScreenPoint(panelRectTransform, touch.position, uiCamera))
                {
                    Vector2 directionVector = touchPosition - joystickCenter;

                    joystickDirection = directionVector.magnitude > 0 ? directionVector.normalized : Vector2.zero;

                }
                else
                {
                    joystickDirection = Vector2.zero;
                }
            }
            else
            {
                joystickDirection = Vector2.zero;
            }
        }

        public Vector2 GetJoystickDirection()
        {
            return joystickDirection;
        }
    }
}
