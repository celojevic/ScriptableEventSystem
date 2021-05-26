using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Int")]
public class IntCondition : Condition<int>
{

    protected override void CheckType()
    {
        var cache = VarToCompare;
        if (!(VarToCompare is IntVar))
        {
            Debug.Log("You must assign an IntVar.");
            VarToCompare = cache;
        }
    }

}
