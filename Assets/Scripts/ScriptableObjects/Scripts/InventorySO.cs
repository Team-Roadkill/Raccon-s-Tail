/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 27/01/2023
/// Purpose : scriptable object that cotains the data types to save that have been collected (or that need to be saved out of level?)
/// 
/// OLD
/// was used to store progress while playing however has become redundant
/// may be reused with the use of multiple scenes 
/// 
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    public List<string> sCollectablesIDs;
    public int iCoins;

}
