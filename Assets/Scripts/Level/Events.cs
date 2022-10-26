using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    #region Input
    /// <summary>
    /// „R„€„q„„„„y„u „y„x„}„u„~„u„~„y„u „€„ƒ„y „r„r„€„t„p
    /// </summary>
    public class InputEvent
    {
        public string Axis { get; }
        public float Direction { get; }

        public InputEvent(string axis, float direction = 0)
        {
            Axis = axis;
            Direction = direction;
        }
    }

    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „y„s„‚„€„{ „~„p„w„y„}„p„u„„ „~„p „{„~„€„„{„… „x„p„r„u„‚„Š„u„~„y„‘ „…„‚„€„r„~„‘.
    /// </summary>
    public class EndLevelButtonClickEvent
    { }
    #endregion

    #region Level
    /// <summary>
    /// „R„€„q„„„„y„u „€„{„€„~„‰„p„~„y„u „…„‚„€„r„~„‘
    /// </summary>
    public class LevelEndEvent
    {
        public bool Win;

        public LevelEndEvent(bool w)
        {
            Win = w;
        }
    }
    #endregion

    #region Asteroids
    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „{„€„~„„„‚„€„|„|„u„‚ „p„ƒ„„„u„‚„€„y„t„€„r „„‚„€„r„u„‚„‘„u„„, „~„u „r„„|„u„„„u„| „|„y „r„y„t „p„ƒ„„„u„‚„€„y„t„p „x„p „s„‚„p„~„y„ˆ„…
    /// </summary>
    public class AsteroidOutOfBoundsEvent
    {
        public AsteroidView View;
        public Vector3 CurrentPosition;

        public AsteroidOutOfBoundsEvent(AsteroidView a, Vector3 p)
        {
            View = a;
            CurrentPosition = p;
        }
    }

    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „p„ƒ„„„u„‚„€„y„t „q„„| „…„~„y„‰„„„€„w„u„~.
    /// „N„€ „u„‹„v „~„u „x„p„r„u„‚„Š„y„| „p„~„y„}„p„ˆ„y„ „r„x„‚„„r„p.
    /// </summary>
    public class AsteroidDestructionEvent
    {
        public AsteroidView View;
        public AsteroidDestructionEvent(AsteroidView a)
        {
            View = a;
        }
    }


    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „p„ƒ„„„u„‚„€„y„t „x„p„r„u„‚„Š„p„u„„ „p„~„y„}„p„ˆ„y„ „r„x„‚„„r„p.
    /// </summary>
    public class AsteroidDestructionFinishEvent
    {
        public AsteroidView View;

        public AsteroidDestructionFinishEvent(AsteroidView a)
        {
            View = a;
        }
    }

    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „‰„„„€„q„ „„u„‚„u„}„u„ƒ„„„y„„„ „p„ƒ„„„u„‚„€„y„t.
    /// </summary>
    public class AsteroidMoveEvent
    {
        public Vector3 Direction { get; }

        public AsteroidMoveEvent(Vector3 direction)
        {
            Direction = direction;
        }
    }

    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „y„x„}„u„~„‘„u„„„ƒ„‘ „{„€„|„y„‰„u„ƒ„„„r„€ „p„ƒ„„„u„‚„€„y„t„€„r, „{„€„„„€„‚„„u „~„p„t„€ „…„~„y„‰„„„€„w„y„„„.
    /// </summary>
    public class AsteroidAmountEvent
    {
        public int asteroidsAmount;

        public AsteroidAmountEvent(int newAmount)
        {
            asteroidsAmount = newAmount;
        }
    }
    #endregion

    #region Shots
    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „{„€„~„„„‚„€„|„|„u„‚ „r„„ƒ„„„‚„u„|„€„r „„‚„€„r„u„‚„‘„u„„, „~„u „r„„|„u„„„u„| „|„y „r„y„t „r„„ƒ„„„‚„u„|„p „x„p „s„‚„p„~„y„ˆ„…
    /// </summary>
    public class ShotOutOfBoundsEvent
    {
        public ShotView shotView;
        public Vector3 currentPosition;

        public ShotOutOfBoundsEvent(ShotView shView, Vector3 position)
        {
            shotView = shView;
            currentPosition = position;
        }
    }

    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „r„„ƒ„„„‚„u„| „ƒ„„„p„|„{„y„r„p„u„„„ƒ„‘ „ƒ „„‚„€„„„y„r„~„y„{„€„}.
    /// </summary>
    public class ShotHitEvent
    {
        public ShotView shotView;

        public ShotHitEvent(ShotView shView)
        {
            shotView = shView;
        }
    }

    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „{„€„~„„„‚„€„|„|„u„‚ „r„„ƒ„„„‚„u„|„p „„u„‚„u„t„r„y„s„p„u„„ „r„y„t„ „r„„ƒ„„„‚„u„|„€„r.
    /// </summary>
    public class ShotMoveEvent
    {
        public Vector3 Direction { get; }
        public float Velocity { get; }

        public ShotMoveEvent(Vector3 direction, float velocity)
        {
            Direction = direction;
            Velocity = velocity;
        }
    }
    #endregion

    #region Player
    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „y„x„}„u„~„‘„u„„„ƒ„‘ „{„€„|„y„‰„u„ƒ„„„r„€ „w„y„x„~„u„z „y„s„‚„€„{„p.
    /// </summary>
    public class PlayerLivesEvent
    {
        public int lives;

        public PlayerLivesEvent(int l)
        {
            lives = l;
        }
    }

    /// <summary>
    /// „^„„„€ „ƒ„€„q„„„„y„u „r„„x„„r„p„u„„„ƒ„‘, „{„€„s„t„p „y„s„‚„€„{ „ƒ„„„p„|„{„y„r„p„u„„„ƒ„‘ „ƒ „„‚„€„„„y„r„~„y„{„€„}.
    /// </summary>
    public class PlayerHitEvent
    {
    }
    #endregion
}