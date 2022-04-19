using UnityEngine;

public class AbilityRunner : MonoBehaviour {
    [SerializeField] IAbility currentAbility = new RageAbility();

    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IAbility 
{
    void Use(GameObject currentGameObject);
}

//Can be a prefab
public class RageAbility : MonoBehaviour, IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

//Cool ScriptableObject.
public class HealAbility : ScriptableObject, IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}

public class FireballAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}
