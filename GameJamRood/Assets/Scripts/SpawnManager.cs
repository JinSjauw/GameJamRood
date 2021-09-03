using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public SpawnState state = SpawnState.COUNTING;

    public float _timeBetweenWaves = 5f;
    public float _countDown = 2f;

    [SerializeField]
    private int _waveNumber = 0;

    public int _spawnAmount;

    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    GameObject _BasicKikker;

    //public TextMeshProUGUI _WaveText;
    //public TextMeshProUGUI _FinalWaveText;

    [SerializeField]
    private Transform[] _SpawnPoints;

    private void Start()
    {
        StartCoroutine(RunSpawner());
    }


    private IEnumerator RunSpawner()
    {
        //Wait two seconds on the first time
        yield return new WaitForSeconds(_countDown);

        //This routine runs infinitly
        while (true)
        {
            state = SpawnState.SPAWNING;

            //Do the spawning and wait until it is finished
            yield return SpawnWave();

            state = SpawnState.WAITING;

            //Wait until all enemies are dead
            yield return new WaitWhile(EnemyisAlive);

            state = SpawnState.COUNTING;

            //Wait an x amount of seconds between waves
            yield return new WaitForSeconds(_timeBetweenWaves);

            _spawnAmount += 5;
        }
    }

    private bool EnemyisAlive()
    {
        //Uses Linq to filter out previously destroyed enemies
        enemies = enemies.Where(e => e != null).ToList();

        return enemies.Count > 0;
    }



    private IEnumerator SpawnWave()
    {
        _waveNumber++;
        //UpdateWaveText();
        for (int i = 0; i < _spawnAmount; i++)
        {
            SpawnBasicEnemy();

            yield return new WaitForSeconds(0);
        }
    }

    private void SpawnBasicEnemy()
    {
        int spawnPointIndex = Random.Range(0, _SpawnPoints.Length);
        enemies.Add(Instantiate(_BasicKikker, _SpawnPoints[spawnPointIndex].position, _SpawnPoints[spawnPointIndex].rotation));
    }

    //void UpdateWaveText()
    //{
    //    _WaveText.text = _waveNumber.ToString();
    //    _FinalWaveText.text = _waveNumber.ToString();
    //}
}
