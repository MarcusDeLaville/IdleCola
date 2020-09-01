using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCapSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _capPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parrentPoint;

    [SerializeField] private SoundEvents _soundEvents;

    private void Start()
    {
        _soundEvents = FindObjectOfType<SoundEvents>();
        StartCoroutine(DropCap());
    }

    private IEnumerator DropCap()
    {
        while (true)
        {
        yield return new WaitForSeconds(5.0f);
        SpawnCap();
        }        
    }

    public void SpawnCap()
    {
        _soundEvents.PlayAudioClip(_soundEvents._tapSounds[6], _soundEvents._audioSourceEvents);
        Vector3 pos = new Vector3(_spawnPoint.transform.position.x + Random.Range(-2f, 2f), _spawnPoint.transform.position.y + Random.Range(-1f, 1f));
        Instantiate(_capPrefab, pos, Quaternion.identity, _parrentPoint);
    }
}
