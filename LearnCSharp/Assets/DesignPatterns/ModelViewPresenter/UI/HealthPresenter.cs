using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter : MonoBehaviour {
    [SerializeField] HealthMVP health;
    [SerializeField] Image healthBar;

    private void Start() {
        health.onHealthMVPChange += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = health.GetHealth() / health.GetFullHealth();
    }
}