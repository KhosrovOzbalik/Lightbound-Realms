using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<SkillAsset> skills;
    private Dictionary<string, float> lastUsedTimes;

    private void Awake()
    {
        lastUsedTimes = new Dictionary<string, float>();
        foreach (var skill in skills)
        {
            lastUsedTimes[skill.skill.name] = Time.time - skill.skill.cooldown;
        }
    }

    public void TriggerSkill(string skillName)
    {
        if (CanUseSkill(skillName))
        {
            // Trigger the skill: animations, effects, damage, etc.
            Debug.Log("Using skill: " + skillName);
            lastUsedTimes[skillName] = Time.time;
            // Assuming the character has an Animator component
            GetComponent<Animator>().Play(skills.Find(s => s.skill.name == skillName).skill.animationClip.name);
        }
        else
        {
            Debug.Log("Skill on cooldown");
        }
    }

    private bool CanUseSkill(string skillName)
    {
        return Time.time >= lastUsedTimes[skillName] + skills.Find(s => s.skill.name == skillName).skill.cooldown;
    }
}
