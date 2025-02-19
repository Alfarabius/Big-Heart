using UnityEngine;
using System.Collections.Generic;

public class AttributeView: MonoBehaviour
{
    [SerializeField] private string attributeName;
    [SerializeField] private string description;
    
    

    private void OnMouseOver()
    {
        System.Func<string> getTooltipTextFunc = () => $"{attributeName} \n{description}";
        TooltipScreenSpaceUI.ShowTooltip_Static(getTooltipTextFunc);
    }

    private void OnMouseExit()
    {
        TooltipScreenSpaceUI.HideTooltip_Static();
    }
}
