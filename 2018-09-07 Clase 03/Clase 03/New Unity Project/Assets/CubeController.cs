using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    Vector3 velocity = new Vector3(0.5f,   0.5f, 0f);
    Vector3 gravity = new Vector3( 0.0f, -0.05f, 0f);

    float floor = -12.0f;
    float wallR =  20.0f;
    float wallL = -20.0f;
	void Start () {
		
	}

	void Update () {
        velocity += gravity;
        transform.position += velocity;
        //velocity.x *= 0.999f;

        if (transform.position.y <= floor) {
            //Vector3 aux = transform.position;
            //aux.y = floor;
            //transform.position = aux;

            transform.position -= velocity;
            velocity -= gravity;
            velocity.y *= -1.0f;
            //velocity.x *= 0.999f;
        }

        if (transform.position.x >= wallR) {
            Vector3 aux = transform.position;
            aux.x = wallR;
            transform.position = aux;
            velocity.x *= -0.99f;
        }

        if (transform.position.x <= wallL) {
            Vector3 aux = transform.position;
            aux.x = wallL;
            transform.position = aux;
            velocity.x *= -0.99f;
        }
    }
}