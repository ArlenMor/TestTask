using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Figures
{
    //отвечает за логику входящий сигналов от пользователя
    //Обрабатывает все изменения параметров и т.д.
    public class FiguresController : MonoBehaviour
    {

        public float sens;

        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
        	//проверка для компа
            if (Input.GetMouseButton(0))
                transform.Rotate(Vector3.up, -sens * Input.GetAxis("Mouse X"), Space.World);
            //проверка для телефона
            else if (Input.touchCount == 1)
                transform.Rotate(Vector3.up, -sens * Input.GetTouch(0).deltaPosition.x, Space.World);
        }
    }

}

