using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            EnemyFactory.Instance.DestroyEnemy(collision.gameObject);
            GameManager.Instance.EnemyHitBase();
            GameManager.Instance.UpdateEnemiesRemaining();
            HUDManager.Instance.UpdateEnemiesRemaining(GameManager.Instance.ReturnEnemiesRemaining());
        }
    }
}
