using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FoolSpawner : MonoBehaviour
{
    public List<Fool> foolPrefabs;
    public float spawnInterval;
    public List<Fool> fools = new List<Fool>();
    public TMPro.TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        StartCoroutine(SpawnFoolsRoutine());
    }

    private IEnumerator SpawnFoolsRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnFool();
        }
    }

    private void Update()
    {
        CheckForLose();
    }

    private void CheckForLose()
    {
        if(fools.Any(fool => Vector3.Distance(fool.transform.position, Vector3.zero) > 7f))
        {
            Debug.Log("You lose!");
            Time.timeScale = 0;
            StopAllCoroutines();
        }
    }

    private void SpawnFool()
    {
        var prefab = foolPrefabs[Random.Range(0, foolPrefabs.Count)];
        var fool = Instantiate(prefab, transform);
        fool.transform.localPosition = Vector3.zero;
        fool.transform.localRotation = 
            Quaternion.Euler(0, Random.Range(0, 360), 0);
        fools.Add(fool);
        fool.Died += OnFoolDied;
    }

    private void OnFoolDied(Fool fool)
    {
        AddScore(fool.Value);
        fool.Died -= OnFoolDied;
        fools.Remove(fool);
    }

    private void AddScore(int amt)
    {
        score += amt;
        scoreText.text = $"{score}";
    }
}
