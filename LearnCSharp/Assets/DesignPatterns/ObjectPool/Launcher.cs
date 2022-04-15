using System;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour {
    [SerializeField] Bullet bulletPrefab;
    private IObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGet,
            OnRelease,
            OnDestroyBullet, //OnDestory overides the interface :\
            maxSize:3 //Maximum amount of objects that won't be destroyed
            );
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    //Called at creation
    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
    }

    //Will be called when it reaches the end of the screen.
    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    //Creates Bullet for Object Pool
    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.SetPool(bulletPool);
        return bullet;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Get();
        }
    }
}