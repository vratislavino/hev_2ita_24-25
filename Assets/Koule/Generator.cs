using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // vytvoøit (prázdný) objekt Genereator
    // umístit objekt na (0,10,0)
    // dát na nìj skript Generator
    // vytvoøit Cube + rigidbody
    // udìlat z nìj prefab
    // pøiøadit prefab na Generator
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
