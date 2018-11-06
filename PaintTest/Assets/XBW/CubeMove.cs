using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter;
using Es.InkPainter.Sample;
public class CubeMove : MonoBehaviour {
    public float speed = 0.1f;
    public Brush brush;
    private Transform cacheTransform;
    private Vector3 lastPos;
    private Camera mainCam;
    void Awake() {
        cacheTransform = transform;
        lastPos = cacheTransform.position;
        mainCam = Camera.main;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 worldPos = cacheTransform.position;
        if (Input.GetKey(KeyCode.D))
        {
            //move right
            worldPos.x += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A)) {
            //move left
            worldPos.x -= speed * Time.deltaTime;
        }
        cacheTransform.position = worldPos;
        if (CheckMove())
        {
            DrawMoveLine();
        }
        lastPos = worldPos;
	}
    private void DrawMoveLine()
    {
        Vector3 worldPos = cacheTransform.position;
        Ray ray = new Ray(worldPos, -cacheTransform.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            InkCanvas inkCanvas = hitInfo.transform.GetComponent<InkCanvas>();
            if (inkCanvas != null) {
                inkCanvas.Paint(brush, hitInfo);
            }
        }
    }
    private bool CheckMove()
    {
        if (lastPos == cacheTransform.position)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
