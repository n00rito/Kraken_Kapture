using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;
    public MeleeAttack meleeAttack;

    int currentLevel, totalExperience;
    int previousLevelsExperience, nextLevelsExperience;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Slider experienceFill;
    InventoryManager inventory;
    Wallet wallet;

    void Start()
    {
        UpdateLevel();
        experienceFill.value = totalExperience;
    }

    void Update()
    {

        if (Input.GetButtonDown("SpearSlash"))
        {
            AddExperience(10);
        }

        if (currentLevel == 5)
        {
            meleeAttack.weaponDamage = 5;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddExperience(10);
        }
        if (currentLevel == 15)
        {
            meleeAttack.weaponDamage = 10;
        }

        if (currentLevel == 25)
        {
            meleeAttack.weaponDamage = 15;
        }

        if (currentLevel == 40)
        {
            meleeAttack.weaponDamage = 30;
        }
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        if (totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            UpdateLevel();

            // Start level up sequence... Possibly vfx?
        }
    }

    void UpdateLevel()
    {
        previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + " exp / " + end + " exp";
        experienceFill.value = (float)start / (float)end;
    }
}