using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NewTowerCreater : MonoBehaviour
{
    [Inject] BasicTowerFactory basicTowerFactory;

    private void OnMouseDown()
    {
        var basicTower = basicTowerFactory.Create();

        basicTower.transform.position = transform.position + new Vector3(0, 1.5f, 0);

        transform.GetChild(0).gameObject.SetActive(false);
    }
}
