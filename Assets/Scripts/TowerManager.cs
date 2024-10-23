using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TowerManager : MonoBehaviour
{
    private List<ITower> _towers = new List<ITower>();

    // Kule eklendiğinde veya silindiğinde eventler tetiklenecek
    public event Action<ITower> OnTowerAdded;
    public event Action<ITower> OnTowerRemoved;

    // Kulelerin listesini Inject etmek için kullanacağız
    [Inject]
    public void Initialize(List<ITower> initialTowers)
    {
        // Başlangıçta var olan kuleleri ekle
        foreach (var tower in initialTowers)
        {
            AddTower(tower);
        }
    }

    // Yeni kule ekleme fonksiyonu
    public void AddTower(ITower tower)
    {
        if (!_towers.Contains(tower))
        {
            _towers.Add(tower);
            OnTowerAdded?.Invoke(tower); // Event'i tetikle
        }
    }

    // Kule silme fonksiyonu
    public void RemoveTower(ITower tower)
    {
        if (_towers.Contains(tower))
        {
            _towers.Remove(tower);
            OnTowerRemoved?.Invoke(tower); // Event'i tetikle
        }
    }

    // Kule listesini almak için bir fonksiyon
    public List<ITower> GetTowers()
    {
        return _towers;
    }
}