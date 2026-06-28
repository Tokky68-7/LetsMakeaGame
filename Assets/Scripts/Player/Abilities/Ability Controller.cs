using UnityEngine;
using System;
using System.Collections.Generic;


public class AbilityController : MonoBehaviour
{
    private Dictionary<Type, Ability> abilities;

    public Ability ActiveAbility { get; private set;}


    void Awake()
    {
        abilities = new Dictionary<Type, Ability>();

        foreach(Ability ability in GetComponents<Ability>())
        {
            abilities.Add(ability.GetType(), ability);
        }

    }

    public bool AbilityFinished()
    {
        if (ActiveAbility == null)
            return false;

        return ActiveAbility.Finished();
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
        T ability = GetAbility<T>();

        if(ability == null)
        {
            return false;
        }

        if(!ability.CanActivate())
        {
            return false;
        }

        ActiveAbility = ability;

        ability.Begin();

        return true;
    }


    public void Tick()
    {
        ActiveAbility?.Tick();
    }

    public void Finish()
    {
        ActiveAbility?.End();

        ActiveAbility = null;
    }

    
}
