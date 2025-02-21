using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    public AttributeView view;
    
    [SerializeField] public List<AttributeType> attributeTypes = new List<AttributeType>();
    private List<IEffect> _effects = new List<IEffect>();
    private bool _isRound;
    
    private void Awake()
    {
        view = GetComponentInChildren<AttributeView>();

        _effects.AddRange(GetComponents<IEffect>());
        _isRound = false;
    }

    public void SetRound(bool isRound)
    {
        _isRound = isRound;
    }

    public void ApplyEffects()
    {
        foreach (IEffect effect in _effects)
        {
            StartCoroutine(ApplyEffect(effect));
        }
    }

    private IEnumerator ApplyEffect(IEffect effect)
    {
        var interval = effect.GetTimeInterval();
        
        while (_isRound)
        {
            yield return new WaitForSeconds(interval);
            // move view
            effect.ApplyEffect();
        }
    }
}

public enum AttributeType
{
    Parfume,
    Cloth,
    Makeup,
    Taro,
    Zodiac,
    BodyType,
    Magic,
    HairColor,
    Haircut
}
