using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<Attribute> attributes = new List<Attribute>();
    [SerializeField] private float placementRadius = 5f;

    private List<GameObject> _attributeViewInstances = new List<GameObject>();

    private void Start()
    {
        RebuildAttributeViews();
    }

    public void AddAttribute(Attribute attribute)
    {
        attributes.Add(attribute);
        RebuildAttributeViews();
    }

    public void RemoveAttribute(Attribute attribute)
    {
        if (attributes.Contains(attribute))
        {
            attributes.Remove(attribute);
            RebuildAttributeViews();
        }
    }

    public bool ContainsAttribute(Attribute attribute)
    {
        return attributes.Contains(attribute);
    }

    public int GetAttributeCount(Attribute attribute)
    {
        return attributes.Count(i => i == attribute);
    }

    private void RebuildAttributeViews()
    {
        int count = attributes.Count;

        foreach (GameObject a in _attributeViewInstances)
        {
            Destroy(a);
        }
        _attributeViewInstances.Clear();
        
        for (int i = 0; i < count; i++)
        {
            Attribute attribute = attributes[i];
            float angle = i * Mathf.PI * 2 / count;
            Vector3 position = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * placementRadius;

            GameObject instance = Instantiate(attribute.view.gameObject, position, Quaternion.identity, transform);
            _attributeViewInstances.Add(instance);
        }
        
        while (_attributeViewInstances.Count > count)
        {
            Destroy(_attributeViewInstances[_attributeViewInstances.Count - 1]);
            _attributeViewInstances.RemoveAt(_attributeViewInstances.Count - 1);
        }
    }
}

