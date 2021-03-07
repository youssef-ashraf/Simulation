using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public Color laserColor = new Color(0, 1, 0, 0.5f);
    public float distanceLaser = 50;
    public float finalLength = 0.2f;
    public float initialLength = 0.2f;

    private Vector3 positionLaser;
    private LineRenderer lineRenderer;
    private float distance = 0;
	// Use this for initialization
	void Start () {
        distance = distanceLaser;
        positionLaser = new Vector3(0, 0, finalLength);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
        lineRenderer.startColor = laserColor;
        lineRenderer.endColor = laserColor;
        lineRenderer.startWidth = initialLength;
        lineRenderer.endWidth = finalLength;
        lineRenderer.positionCount = 2;
        

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 finalPoint = transform.position + transform.forward * distanceLaser;
        RaycastHit collisionPoint;
        if(Physics.Raycast(transform.position,transform.forward,out collisionPoint, distanceLaser))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, collisionPoint.point);
            distance = collisionPoint.distance;

        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, finalPoint);
            distance = distanceLaser;
        }
        if(distance <4)
        {

            lineRenderer.startColor = new Color(0, 0, 50, 0.5f);
            lineRenderer.endColor = new Color(0, 0, 50, 0.5f);
        }
        else
        {
            lineRenderer.startColor = laserColor;
            lineRenderer.endColor = laserColor;
        }
	}
    public float getDistance()
    {
   
        return distance/distanceLaser;
    }
}
