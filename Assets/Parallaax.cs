using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;

    float startZ;
    float startY;
    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
        startY = transform.position.y;
    }   

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, startY, startZ);

    }
}
