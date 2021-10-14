using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class scr_BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject enemyBullet;
    public GameObject playerBullet;

    public GameObject createBullet(scr_BulletType type = scr_BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        switch (type)
        {
            case scr_BulletType.ENEMY:
                temp_bullet = Instantiate(enemyBullet);
                break;
            case scr_BulletType.PLAYER:
                temp_bullet = Instantiate(playerBullet);
                break;
        }

        temp_bullet.transform.parent = transform;
        temp_bullet.SetActive(false);

        return temp_bullet;
    }

}
