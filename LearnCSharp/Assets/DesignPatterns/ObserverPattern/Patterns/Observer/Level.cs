using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{

    [SerializeField] int pointsPerLevel = 200;
    public UnityEvent onLevelUp; //Core of Observer
    int experiencePoints = 0;

    //event = function pointer - special kind of multicast delegate that can only be invoked from within the class or struct where they are declared (the publisher class).
    //Action = it's like Delegate, BUT is used for calling void functions.
    public event System.Action OnLevelUpAction;
    //Model-View-Presenter
    public event System.Action onExperienceChange;

    public delegate void CallbackType(); //Create function pointer type. COULD ALSO MAKE IT function(int i)
    public event System.Action<float> OnLevelUpActionFloat; //like above function (int i)
    public event CallbackType OnLevelUpActionDelegate; //Create instant to assign function to later on.

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int currentLevel = GetLevel();
        experiencePoints += points;
        if (GetLevel() > currentLevel)
        {
            onLevelUp.Invoke();
            if (OnLevelUpAction != null)
                OnLevelUpAction();
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}