using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Conditions/String")]
public class StringCondition : Condition<string>
{

    protected override void CheckType()
    {
        if (!(VarToCompare is StringVar))
        {
            Debug.Log("You must assign a StringVar.");
            VarToCompare = null;
        }
    }

}
