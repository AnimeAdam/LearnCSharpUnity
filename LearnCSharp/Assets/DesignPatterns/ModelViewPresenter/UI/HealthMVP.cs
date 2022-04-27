using System;
using System.Collections;
using UnityEngine;

public class HealthMVP : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    public event Action onHealthMVPChange;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void OnEnable()
    {
        GetComponent<LevelMVP>().onLevelMVPUpAction += ResetHealth;
    }

    private void OnDisable()
    {
        GetComponent<LevelMVP>().onLevelMVPUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }

    void ResetHealth()
    {
        currentHealth = fullHealth;
        if (onHealthMVPChange != null)
        {
            onHealthMVPChange();
        }
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            if (onHealthMVPChange != null)
            {
                onHealthMVPChange();
            }
            yield return new WaitForSeconds(1);
        }
    }
}