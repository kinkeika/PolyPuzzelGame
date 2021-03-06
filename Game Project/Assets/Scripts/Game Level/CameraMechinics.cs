﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraMechinics : MonoBehaviour {

	public float smooth;
	
	public Transform[] CameraLocs = new Transform[5];
	public Vector3[] CameraRot  = new Vector3[5];
	public bool canMove = true;
	public int posIndex = 1;
    public float cameraZoomIndex;
 

    public Text CamPos;

	public int PositionIndex
	{
		get{return posIndex;}
		set{posIndex = value;}
	}

	public bool MoveCamera
	{
		get{return canMove;}
		set{canMove = value;}
	}

	public iTween.EaseType ease = iTween.EaseType.easeInBack;

	private string easeType;

  
    void Awake()
	{
        
        canMove = true;
		if(canMove == true){
			
			ChangePos();
			
			//Debug.Log (ease.ToString());
			
		}

		CamPos.text = (posIndex + 1).ToString();
	}
    void Start() {
        cameraZoomIndex = 6.5f;

    }

    bool changeView = false;


	void Update() {



		if(canMove == true){

			ChangePos();

			//Debug.Log (ease.ToString());
		}


        if (changeView == true)
        {
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraZoomIndex, Time.deltaTime * smooth );

        }


        if (Camera.main.orthographicSize >= cameraZoomIndex - 0.1f && Camera.main.orthographicSize <= cameraZoomIndex + 0.1f)
        {
 
            changeView = false;
        }


    }

	
	void ChangePos()
	{

		easeType = ease.ToString();

			switch(posIndex){
			case 0: 
			iTween.MoveTo(gameObject, iTween.Hash("x",CameraLocs[posIndex].position.x, "y",CameraLocs[posIndex].position.y,"z",CameraLocs[posIndex].position.z,"easeType", easeType, "loopType", "none","Time",smooth));
			iTween.RotateTo(gameObject,iTween.Hash("x", 45,"y", 0,"z", 0,"easeType", easeType,"Time",smooth));
                cameraZoomIndex = 6.5f;
                changeView = true;
                canMove = false;
				break;
			case 1: 
			iTween.MoveTo(gameObject, iTween.Hash("x",CameraLocs[posIndex].position.x, "y",CameraLocs[posIndex].position.y,"z",CameraLocs[posIndex].position.z,"easeType", easeType, "loopType", "none","Time",smooth));
			iTween.RotateTo(gameObject,iTween.Hash("x", 42,"y", 272,"z",0,"easeType", easeType ,"Time",smooth));
                cameraZoomIndex = 6.5f;
                changeView = true;
                canMove = false;
				break;
			case 2: 
			iTween.MoveTo(gameObject, iTween.Hash("x",CameraLocs[posIndex].position.x, "y",CameraLocs[posIndex].position.y,"z",CameraLocs[posIndex].position.z,"easeType", easeType, "loopType", "none","Time",smooth));
			iTween.RotateTo(gameObject,iTween.Hash("x", 66,"y", 250, "z", 0,"easeType", easeType,"Time",smooth));
                cameraZoomIndex = 7.83f;
                changeView = true;
                canMove = false;
				break;
			case 3: 
			iTween.MoveTo(gameObject, iTween.Hash("x",CameraLocs[posIndex].position.x, "y",CameraLocs[posIndex].position.y,"z",CameraLocs[posIndex].position.z,"easeType", easeType, "loopType", "none","Time",smooth));
			iTween.RotateTo(gameObject,iTween.Hash("x", 66,"y", 90,"z", 0,"easeType",easeType,"Time",smooth));
                cameraZoomIndex = 8.8f;
                changeView = true;
                canMove = false;
			break;
			case 4: 
			iTween.MoveTo(gameObject, iTween.Hash("x",CameraLocs[posIndex].position.x, "y",CameraLocs[posIndex].position.y,"z",CameraLocs[posIndex].position.z,"easeType", easeType, "loopType", "none","Time",smooth));
			iTween.RotateTo(gameObject,iTween.Hash("x", 90,"y",180,"z", 0,"easeType", easeType,"Time",smooth));
                cameraZoomIndex = 7.5f;
                changeView = true;
                canMove = false;
			break;
			}

		CamPos.text = (posIndex + 1).ToString();
       

    }


	public void SetCameraPosition()
	{
		posIndex++;

		if ( posIndex >= CameraLocs.Length)
		{
			posIndex = 0;
			canMove = true;
		}else
		{
			canMove = true;
		}

	}


}
