using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelPresenter : MonoBehaviour {
    [SerializeField] LevelMVP level;
    [SerializeField] Text displayText;
    [SerializeField] Text experienceText;
    [SerializeField] Button increaseXPButton;

    private void Start() {
        increaseXPButton.onClick.AddListener(GainExperience);
        level.onExperienceChangeMVP += UpdateUI;
        UpdateUI();
    }

    private void GainExperience()
    {
        level.GainExperience(10);
    }

    private void UpdateUI()
    {
        displayText.text = $"Level: {level.GetLevel()}";
        experienceText.text = $"XP: {level.GetExperience()}";
    }
}