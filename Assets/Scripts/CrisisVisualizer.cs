using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrisisVisualizer : MonoBehaviour
{
    public static CrisisVisualizer Instance;
    
    private List<IDestructible> _currentDestructibles = new();
    private List<IDestructible> _nextDestructibles = new();

    private Coroutine _crisisRoutine;
    private WaitForSeconds _wait;
    private bool _isRunning;

    private void Awake()
    {
        Instance = this;
        _wait = new WaitForSeconds(0.6f);
    }

    public void AddDestructibleForNextTic(IDestructible destructible)
    {
        if (!_isRunning)
        {
            _isRunning = true;
            _currentDestructibles.Add(destructible);
            _crisisRoutine = StartCoroutine(CrisisRoutine());
        }
        else
        {
            _nextDestructibles.Add(destructible);
        }
    }

    private IEnumerator CrisisRoutine()
    {
        int i = 0;
        while (_currentDestructibles.Count > 0)
        {
            Debug.Log($"Crisis Step: {++i}");
            DoCrisisStep();
            yield return _wait;
        }

        _isRunning = false;
        Debug.Log("CrisisFinished");
    }

    private void DoCrisisStep()
    {
        _currentDestructibles.ForEach(d => d.Disable());
        _currentDestructibles = _nextDestructibles.ToArray().ToList();
        _nextDestructibles.Clear();
    }
}