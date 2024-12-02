using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // vytvo�it (pr�zdn�) objekt Genereator
    // um�stit objekt na (0,10,0)
    // d�t na n�j skript Generator
    // vytvo�it Cube + rigidbody
    // ud�lat z n�j prefab
    // p�i�adit prefab na Generator
    // Play :)


    public float interval = 0.1f;
    public float distance = 4.5f;
    public GameObject cubePrefab;

    void Start()
    {
        StartCoroutine(CreateObjectsRoutine());
    }

    IEnumerator CreateObjectsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            CreateObject();
        }
    }

    void CreateObject()
    {
        var cube = Instantiate(cubePrefab, transform);
        cube.transform.localPosition = new Vector3(
            Random.Range(-distance, distance),
            0,
            Random.Range(-distance, distance)
            );

        Destroy(cube, 3f);
    }


}
