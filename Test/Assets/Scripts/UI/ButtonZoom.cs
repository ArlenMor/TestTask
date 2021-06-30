using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ButtonZoom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool plusZoom;
        public bool minusZoom;
        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "+")
                plusZoom = true;
            if (eventData.pointerCurrentRaycast.gameObject.name == "-")
                minusZoom = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            plusZoom = minusZoom = false;
        }
    }
}

