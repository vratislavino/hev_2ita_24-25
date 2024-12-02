using UnityEngine;

public class PyramidShooter : MonoBehaviour
{
    private Camera cam;
    public float shootForce = 10f;
    public Rigidbody bulletPrefab;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) //klik hr·Ëe
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = ray.origin;
            bullet.AddForce(ray.direction * shootForce, ForceMode.Impulse);
            Destroy(bullet, 3f);
        }
    }
}
