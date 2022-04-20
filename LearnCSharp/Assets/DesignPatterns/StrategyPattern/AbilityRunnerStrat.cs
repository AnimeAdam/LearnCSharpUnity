using UnityEngine;

public class AbilityRunnerStrat : MonoBehaviour {
    [SerializeField] IAbilityStrat currentAbility = new RageAbilityStrat();

    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IAbilityStrat 
{
    void Use(GameObject currentGameObject);
}

//Can be a prefab
public class RageAbilityStrat : MonoBehaviour, IAbilityStrat
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

//Cool ScriptableObject.
public class HealAbilityStrat : ScriptableObject, IAbilityStrat
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}

public class FireballAbilityStrat : IAbilityStrat
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}
