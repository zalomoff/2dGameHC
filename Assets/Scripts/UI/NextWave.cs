using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveBtn;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveBtn.onClick.AddListener(OnNextWaveBtnClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveBtn.onClick.RemoveListener(OnNextWaveBtnClick);
    }

    public void OnAllEnemySpawned()
    {
        _nextWaveBtn.gameObject.SetActive(true);
    }

    public void OnNextWaveBtnClick()
    {
        _spawner.NextWave();
        _nextWaveBtn.gameObject.SetActive(false);
    }
}
