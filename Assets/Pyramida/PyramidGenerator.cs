using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PyramidGenerator : MonoBehaviour
{
    public int rows = 5;
    public float mass = 5f;
    public Rigidbody blockPrefab;

    List<Transform> allCubes = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreatePyramid(rows);
    }

    private void CreatePyramid(int count)
    {
        Vector3 pos = new Vector3(-count/2f-0.5f, 0, 0);
        Rigidbody block;
        for (int i = 0; i < count; i++)
        {
            for(int j = 0; j < count-i; j++)
            {
                block = Instantiate(blockPrefab, transform);
                block.mass = mass;
                block.transform.localPosition = pos;
                allCubes.Add(block.transform);
                pos.x += 1;
            }
            pos.y += 1;
            pos.x = -(count-i) / 2f;
        }
    }
    private void Update()
    {
        if(allCubes.All(cube => cube.localPosition.y < 0.1f))
        {
            Debug.Log("Done!");
            Time.timeScale = 0;
        }   
    }
}
