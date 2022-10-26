using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    /// <summary>
    /// „R„€„q„„„„y„u „~„p„w„p„„„y„u „~„p „}„p„‚„{„u„‚ „…„‚„€„r„~„‘
    /// </summary>
    public class MarkerClickEvent
    {
        public LevelData levelToSelect;

        public MarkerClickEvent(LevelData l)
        {
            levelToSelect = l;
        }
    }
    
    /// <summary>
    /// „R„€„q„„„„y„u „r„„‡„€„t„p „y„x „y„s„‚„
    /// </summary>
    public class QuitEvent
    { }
}