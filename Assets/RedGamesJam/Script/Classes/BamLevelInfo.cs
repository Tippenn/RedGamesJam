using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BamLevelInfo
{
    public float timer;
    public List<ConveyerItem> itemLeft;
    public List<ConveyerItem> itemRight;
    public List<ConveyerItem> itemAllowed;
}
