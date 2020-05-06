﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{   
    public List<WaveInterface> waveInterfaces;
    private int startingWave = 0;
    //private int generateRandomPerson;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllWaves()
    {
        for (var curWave = startingWave; curWave < waveInterfaces.Count; curWave++)
        {
            var current = waveInterfaces[curWave];
            yield return StartCoroutine(SpawnAllEnemiesByWave(current));
        }
    }

    private IEnumerator SpawnAllEnemiesByWave(WaveInterface _waveInterface)
    {
        for (int i = 0; i < _waveInterface.GetNumberOfPerson(); i++)
        {
            GeneratePerson(_waveInterface);
            yield return new WaitForSeconds(_waveInterface.GetTimeBetweenSpawns());
        }
        
    }
    private void GeneratePerson(WaveInterface _waveInterface)
    {
        int generateRandomPerson = Random.Range(0, 4);
        int generateRandomTargetPos = Random.Range(0, 2);
        GameObject personObj = Instantiate(_waveInterface.GetPerson()[generateRandomPerson],
            _waveInterface.GetWaypoint()[0].transform.position,
            Quaternion.identity) as GameObject;
        personObj.GetComponent<PersonPathing>().SetWave(_waveInterface);
    }
}
