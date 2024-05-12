using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
    [SerializeField] private Transform pointPrefab;
    [SerializeField] private int resolution;
    Transform[] points;

    private void Awake() {
        float step = 2f / resolution;
        var position = Vector3.zero;
		var scale = Vector3.one * step;

        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            points[i] = point;  
            position.x = (i + 0.5f) * step - 1f;
            point.transform.position = position;
            point.transform.localScale = scale;
            point.SetParent(transform);
        }

    }
    private void Update() {

        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.position;
            position.y = (float)Math.Sin(Math.PI * (position.x + time));
            point.localPosition = position;
        }
    }
}
