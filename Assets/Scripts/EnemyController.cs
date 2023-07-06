using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.Instance.OnKill();
        }
    }
}
