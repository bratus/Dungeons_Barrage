﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCrosshair : MonoBehaviour {

	public Transform Crosshair;
	SpriteRenderer colorModifiable;
	float duration = 5f;
	Vector3 correctRotation;
	Color32 colorStart = new Color32(255,71,71,255);

    protected float hAxisMouse;
    protected float vAxisMouse;

    ClassesPlayer controllerScript;

    CharacterController controller;

    GameObject target;
    Vector3 offset;



	void Start()
    {
        Color32 colorStart = new Color32(255, 71, 71, 255);

        colorModifiable = Crosshair.GetComponent<SpriteRenderer>();
		correctRotation = new Vector3 (0, 180, 0);

        controllerScript = GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<ClassesPlayer>();
        controller = gameObject.GetComponent<CharacterController>();
        offset = transform.position - target.transform.position;

    }
    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("PlayerHP");
        hAxisMouse = Input.GetAxis("Mouse X");
        hAxisMouse = Input.GetAxis("Mouse Y");
        Vector3 mouseMovement = new Vector3(hAxisMouse, 0, vAxisMouse) * 100 * Time.deltaTime;
        if (controllerScript.isControllerConnected == true)
        {
           
                transform.position = target.transform.position + offset;

            controller.SimpleMove(mouseMovement);
        }
    }
    // Update is called once per frame
    void LateUpdate () {

		float lerp = Mathf.PingPong (Time.time, duration) / duration;
		colorModifiable.color = Color32.Lerp(colorStart,new Color32(255,151,71,255),lerp);

		Crosshair.transform.Rotate (correctRotation * Time.deltaTime,Space.World);
	}
}
