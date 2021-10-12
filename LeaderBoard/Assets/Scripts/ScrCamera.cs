using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class ScrCamera : MonoBehaviour
    {
        
        static int characterAmount = 3;
        public GameObject[] characters = new GameObject[characterAmount];
        private int currentCharacter = 0;

       
        public Transform lookAt;
        public Transform camTransform;

        private Camera cam;

        private float distance = 1.0f;
        private float currentX = 0.0f;
        private float currentY = 0.0f;
        private float sensX = 4.0f;
        private float sensY = 1.0f;

        private const float Y_ANGLE_MIN = 20.0f;
        private const float Y_ANGLE_MAX = 60.0f;

        private void Start() {
            camTransform = transform;
            cam = Camera.main;
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Z)) {
                if (currentCharacter < characterAmount - 1) {
                    currentCharacter++;
                }
                else {
                    currentCharacter = 0;
                }
            }

            for (int i = 0; i < characterAmount; i++) {
                characters[i].GetComponent<ScrMovement>().selected = false;
            }
            characters[currentCharacter].GetComponent<ScrMovement>().selected = true;
            lookAt = characters[currentCharacter].transform;

            
            currentX += Input.GetAxis("Mouse X") * sensX;
            currentY += Input.GetAxis("Mouse Y") * -sensY;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        private void LateUpdate() {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rot = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rot * dir;
            camTransform.LookAt(lookAt.position);
        }

    }
}