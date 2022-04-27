using System;
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    float currentHealth = 0;

    //Model-View-Presenter
    public event Action onHealthChange;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void Start()
    {
    }

    private void OnEnable()
    {
        GetComponent<Level>().onLevelUp.AddListener(ResetHealth); //Sets a callback function whenever onLevelUp is invoked.
        GetComponent<Level>().OnLevelUpAction += ResetHealth; //Adds to the events in OnLevelUpAction.
    }

    private void OnDisable()
    {
        GetComponent<Level>().OnLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }

    public void ResetHealth()
    {
        currentHealth = fullHealth;
        if (onHealthChange != null)
        {
            onHealthChange();
        }

    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
    }
}