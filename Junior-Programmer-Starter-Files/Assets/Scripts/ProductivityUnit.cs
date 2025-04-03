using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    public float ProductionSpeed = 0.5f;

    protected override void BuildingInRange()
    {
        if (m_Target.gameObject.GetComponent<ResourcePile>() != null){
            ResourcePile pile = (m_Target as ResourcePile);
            pile.CreateProduction(pile.ProductionSpeed * ProductionSpeed);
        }
    }

    public override string GetName()
    {
        return "Productivity";
    }
}
