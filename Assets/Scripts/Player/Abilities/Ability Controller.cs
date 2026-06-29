using UnityEngine;
using System;
using System.Collections.Generic;


public class AbilityController : MonoBehaviour
{
    private Dictionary<Type, Ability> abilities;
    private Dictionary<Type, Ability> activeAbilities;

    public Ability ActiveAbility
    {
        get
        {
            foreach (Ability ability in activeAbilities.Values)
            {
                return ability;
            }

            return null;
        }
    }


    void Awake()
    {
        abilities = new Dictionary<Type, Ability>();
        activeAbilities = new Dictionary<Type, Ability>();
    
        foreach(Ability ability in GetComponents<Ability>())
        {
            abilities.Add(ability.GetType(), ability);
        }

    }

    public bool AbilityFinished()
    {
        return activeAbilities.Count == 0;
    }


    public T GetAbility<T>() where T : Ability
    {
        if(abilities.TryGetValue(typeof(T), out Ability ability))
        {
            return (T)ability;
        }
    
        return null;
    }

    public bool Activate<T>() where T : Ability
    {
        Type abilityType = typeof(T);

        if(activeAbilities.ContainsKey(abilityType))
        {
            return false;
        }

        T ability = GetAbility<T>();

        if(ability == null)
        {
            return false;
        }

        if(!ability.CanActivate())
        {
            return false;
        }

        activeAbilities.Add(abilityType, ability);

        ability.Begin();

        return true;
    }


    public void Tick()
    {
        List<Type> finishedAbilities = new List<Type>();

        foreach(KeyValuePair<Type, Ability> activeAbility in activeAbilities)
        {
            activeAbility.Value.Tick();

            if(activeAbility.Value.Finished())
            {
                finishedAbilities.Add(activeAbility.Key);
            }
        }

        foreach(Type abilityType in finishedAbilities)
        {
            Finish(abilityType);
        }
    }

    public void Finish()
    {
        List<Type> activeAbilityTypes = new List<Type>(activeAbilities.Keys);

        foreach(Type abilityType in activeAbilityTypes)
        {
            Finish(abilityType);
        }
    }

    public void Finish<T>() where T : Ability
    {
        Finish(typeof(T));
    }

    private void Finish(Type abilityType)
    {
        if(!activeAbilities.TryGetValue(abilityType, out Ability ability))
        {
            return;
        }

        ability.End();
        activeAbilities.Remove(abilityType);
    }

    
}
