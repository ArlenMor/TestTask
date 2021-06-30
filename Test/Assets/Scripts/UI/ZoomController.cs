using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

namespace UI
{
    public class ZoomController : MonoBehaviour
    {
        [Header("Camera:")]
        [SerializeField]
        private Camera cam;


        [Header("Zoom limit:")]
        [SerializeField]
        private float m_maxZoom;
        [SerializeField]
        private float m_minZoom;

        [SerializeField]
        private float sensivity;

        //0 элемент - приблизить
        //1 элемент - отдалить
        [SerializeField]
        List<ButtonZoom> Zoom = new List<ButtonZoom>();

        void Update()
        {

            if(Input.touchCount == 2)
            {
                //фиксируем касания. При помощи векторов находим разницу, между изночальным
                //тапом и перемещённым. исходдя из этой разницы приближаем или отдаляем
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;
                ZoomCamera(difference * 0.01f);
            }
            //зум благодаря колесу мыши
            ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));
            
            //зум через кнопки
            if (Zoom[0].plusZoom)
                ZoomCamera(0.015f);
            if (Zoom[1].minusZoom)
                ZoomCamera(-0.015f);
        }

        void ZoomCamera(float increment)
        {
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - increment * sensivity, m_minZoom, m_maxZoom);
        }
    }

}
