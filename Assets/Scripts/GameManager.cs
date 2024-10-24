using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] BasicTowerFactory _basicTowerFactory;

    
    void Start()
    {
        var basicTower = _basicTowerFactory.Create();

        SetBasicTower(basicTower.gameObject);
    }

    void SetBasicTower(GameObject basicTower)
    {
        basicTower.transform.position = new Vector3(0, 1.5f, 0);
    }

}
