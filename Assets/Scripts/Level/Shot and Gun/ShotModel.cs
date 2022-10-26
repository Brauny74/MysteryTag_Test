using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    public class ShotModel : MT_TestGameObject
    {
        /// <summary>
        /// „R„{„€„‚„€„ƒ„„„ „„…„|„ „y„s„‚„€„{„p
        /// </summary>
        public float velocity;
        /// <summary>
        /// „N„p„„‚„p„r„|„u„~„y„u, „„€ „…„}„€„|„‰„p„~„y„ - „r„u„‚„‡ „„{„‚„p„~„p.
        /// </summary>
        public Vector3 direction = new Vector3(0, 0, 1);        
    }
}