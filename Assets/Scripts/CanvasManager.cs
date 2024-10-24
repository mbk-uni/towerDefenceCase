using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class CanvasManager : MonoBehaviour
{
    [Inject] private EnemySpawner _enemySpawner;
    [Inject] private TowerManager _towerManager;

    public TextMeshProUGUI numberOfWaves;
    public TextMeshProUGUI numberOfTowers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfWaves.text = _enemySpawner.numberOfWaves.ToString();
        numberOfTowers.text = _towerManager.towers.Count.ToString();
    }
}
