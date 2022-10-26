using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    #region Input
    /// <summary>
    /// �R���q�����y�u �y�x�}�u�~�u�~�y�u �����y �r�r���t�p
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �y�s�����{ �~�p�w�y�}�p�u�� �~�p �{�~�����{�� �x�p�r�u�����u�~�y�� �������r�~��.
    /// </summary>
    public class EndLevelButtonClickEvent
    { }
    #endregion

    #region Level
    /// <summary>
    /// �R���q�����y�u ���{���~���p�~�y�u �������r�~��
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �{���~�������|�|�u�� �p�����u�����y�t���r �������r�u�����u��, �~�u �r���|�u���u�| �|�y �r�y�t �p�����u�����y�t�p �x�p �s���p�~�y����
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �p�����u�����y�t �q���| ���~�y�������w�u�~.
    /// �N�� �u���v �~�u �x�p�r�u�����y�| �p�~�y�}�p���y�� �r�x�����r�p.
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �p�����u�����y�t �x�p�r�u�����p�u�� �p�~�y�}�p���y�� �r�x�����r�p.
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �������q�� ���u���u�}�u�����y���� �p�����u�����y�t.
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �y�x�}�u�~���u������ �{���|�y���u�����r�� �p�����u�����y�t���r, �{�����������u �~�p�t�� ���~�y�������w�y����.
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �{���~�������|�|�u�� �r���������u�|���r �������r�u�����u��, �~�u �r���|�u���u�| �|�y �r�y�t �r���������u�|�p �x�p �s���p�~�y����
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �r���������u�| �����p�|�{�y�r�p�u������ �� ���������y�r�~�y�{���}.
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �{���~�������|�|�u�� �r���������u�|�p ���u���u�t�r�y�s�p�u�� �r�y�t�� �r���������u�|���r.
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �y�x�}�u�~���u������ �{���|�y���u�����r�� �w�y�x�~�u�z �y�s�����{�p.
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
    /// �^���� �����q�����y�u �r���x���r�p�u������, �{���s�t�p �y�s�����{ �����p�|�{�y�r�p�u������ �� ���������y�r�~�y�{���}.
    /// </summary>
    public class PlayerHitEvent
    {
    }
    #endregion
}