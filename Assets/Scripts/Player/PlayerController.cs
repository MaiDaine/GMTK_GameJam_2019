﻿using UnityEngine;

namespace GameJam
{
    public class PlayerController : MonoBehaviour
    {
        public Camera mainCamera;
        public bool inputEnable = true;

        private SolarSailsController sailsController;

        private const int maskSolarWind = 1 << 8;

        private void Awake()
        {
            sailsController = GetComponentInChildren<SolarSailsController>();
        }

        private void Update()
        {
            if (!inputEnable)
                return;
            //Targeting
            //if (Input.GetMouseButtonDown(0))
            //    SetOrbit(1f);
            //else if (Input.GetMouseButton(1))
            //    SetOrbit(-1f);

            //Sails control
            if (Input.GetKey(KeyCode.A))
                sailsController.RotateSails(1);
            else if (Input.GetKey(KeyCode.D))
                sailsController.RotateSails(-1);
            //if (Input.GetKey(KeyCode.S))
            //    sailsController.SetSailNeutralState();

            //Time control
            //if (Input.GetKeyDown(KeyCode.KeypadPlus) && Time.timeScale < 5)
            //    Time.timeScale += 0.5f;
            //else if (Input.GetKeyDown(KeyCode.KeypadMinus) && Time.timeScale > 0.5f)
            //    Time.timeScale -= 0.5f;
        }

        private void SetOrbit(float expand)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, maskSolarWind) && hitInfo.collider.tag != "Player")
                sailsController.SetCelestialBodyTarget(hitInfo.collider.gameObject.transform, expand);
        }
    }
}