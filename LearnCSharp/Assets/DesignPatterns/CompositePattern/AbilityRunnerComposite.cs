using UnityEngine;

public class AbilityRunnerComposite : MonoBehaviour
{
    [SerializeField]
    IAbilityComp currentAbility =
        new SequenceComposite(
            new IAbilityComp[] {
                new HealAbilityComp(),
                new RageAbilityComp(),
                new DelayedDecoratorComp(
                    new RageAbilityComp()
                )
            }
        );

    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IAbilityComp
{
    void Use(GameObject currentGameObject);
}

public class SequenceComposite : IAbilityComp
{
    private IAbilityComp[] children;

    public SequenceComposite(IAbilityComp[] children)
    {
        this.children = children;
    }

    public void Use(GameObject currentGameObject)
    {
        foreach (var child in children)
        {
            child.Use(currentGameObject);
        }
    }
}

public class DelayedDecoratorComp : IAbilityComp
{
    private IAbilityComp wrappedAbility;

    public DelayedDecoratorComp(IAbilityComp wrappedAbility)
    {
        this.wrappedAbility = wrappedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        // TODO some delaying functionality.
        wrappedAbility.Use(currentGameObject);
    }
}

public class RageAbilityComp : IAbilityComp
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class HealAbilityComp : IAbilityComp
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}

public class FireballAbilityComp : IAbilityComp
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}
