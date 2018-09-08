using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {
    /* WayPoints */
    Vector3 r0, r1, r2, r3, r4, r5 = new Vector3(0, 0, 0);

    /* Lista de WayPoints */
    List<Vector3> points = new List<Vector3>();

    /* Progreso */
    float t = 0.00f;

    int index = 0;

    List<Vector3> currentPath = new List<Vector3>();

    void Start () {
        /* Asignando WayPoints
        r0 = GameObject.Find("0").transform.position;
        r1 = GameObject.Find("1").transform.position;
        r2 = GameObject.Find("2").transform.position;
        r3 = GameObject.Find("3").transform.position;
        r4 = GameObject.Find("4").transform.position;
        r5 = GameObject.Find("5").transform.position; */

        /* Asignando WayPoints a la lista "points" 
        points.Add(GameObject.Find("0").transform.position);
        points.Add(GameObject.Find("1").transform.position);
        points.Add(GameObject.Find("2").transform.position);
        points.Add(GameObject.Find("3").transform.position);
        points.Add(GameObject.Find("4").transform.position);
        points.Add(GameObject.Find("5").transform.position);
        points.Add(GameObject.Find("0").transform.position); */

        /* Designar ruta */
        NewWay();
    }

    void NewWay () {
        /* Limpiar Path */
        currentPath.RemoveRange(0, currentPath.Count);

        /* Generar 1r intento */
        int ran1 = Random.Range(0, 6);
        int ran2 = Random.Range(0, 6);
        int ran3 = Random.Range(0, 6);

        /* Evitar duplicados */
        while (ran1 == ran2 || ran2 == ran3 || ran1 == ran3) {
            ran2 = Random.Range(0, 6);
            ran3 = Random.Range(0, 6);
        }

        /* Ver */
        print(ran1 + ", " + ran2 + ", " + ran3);

        /* Designar waypoints */
        r0 = GameObject.Find(ran1.ToString()).transform.position;
        r1 = GameObject.Find(ran2.ToString()).transform.position;
        r2 = GameObject.Find(ran3.ToString()).transform.position;

        /* Añadirlos al path */
        currentPath.Add(r0);
        currentPath.Add(r1);
        currentPath.Add(r2);
    }

	void Update () {
        t += 0.05f;

        /* LERPs */
        //transform.position = Vector3.Lerp(p0, p1, t);

        //transform.position = Vector3.Lerp(points[0], points[1], t);
        //transform.position = Vector3.Lerp(points[index], points[index + 1], t);
        transform.position = Vector3.Lerp(currentPath[index], currentPath[index + 1], t);

        /* Bucle */
        //if (t >= 1) { t = 0; }
        /*if (t >= 1) {
            t = 0;
            index += 1;

            if (index == points.Count - 1) { index = 0; }
        }*/

        if (t >= 1) {
            t = 0;
            index += 1;

            if (index == currentPath.Count - 1) {
                index = 0;
                NewWay();
            }
        }
    }
}