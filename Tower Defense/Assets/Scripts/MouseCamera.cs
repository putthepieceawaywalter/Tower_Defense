using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a script to allow the developer to use the mouse when testing the app
// in the unity editor


namespace TowerDefense 
{
    public class MouseCamera : MonoBehaviour {
        #if UNITY_EDITOR

        bool isDragging = false;

        float startMouseX;
        float startMouseY;

        Camera c;

        // initializer
        void Start() {
            c = GetComponent<Camera>();
        }

        // update is called once per frame
        void Update() {
            
            // if left button is pressed and hasn't started dragging
            //if(Input.GetMouseButtonDown(0) && !isDragging)
            //{
            //    // set the flag to true
            //    isDragging = true;

            //    // save the mouse start position
            //    startMouseX = Input.mousePosition.x;
            //    startMouseY = Input.mousePosition.y;
            //}
            //else if(Input.GetMouseButtonUp(0) && isDragging)
            //{
            //    isDragging = false;
            //}
            

            // drag camera while space bar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDragging = true;
                startMouseX = Input.mousePosition.x;
                startMouseY = Input.mousePosition.y;

            }
            else if (!Input.GetKey(KeyCode.Space) && isDragging)
            {
                isDragging = false;
            }
        }
        void LateUpdate()
        {
            if(isDragging)
            {
                //current mouse position
                float endMouseX = Input.mousePosition.x;
                float endMouseY = Input.mousePosition.y;

                // difference in screen coordinates
                float diffX = endMouseX - startMouseX;
                float diffY = endMouseY - startMouseY;




                float newCenterX =  Screen.width / 2.0f + 2.5f * diffX;
                float newCenterY = Screen.height / 2.0f + 2.5f * diffY;
                


                Vector3 LookHerePoint = c.ScreenToWorldPoint(new Vector3(newCenterX, newCenterY, c.nearClipPlane));

                // make camera look at look here point
                transform.LookAt(LookHerePoint);
                

                //starting position for next call
                startMouseX = endMouseX;
                startMouseY = endMouseY;
            }
        }


        #endif
    }

}