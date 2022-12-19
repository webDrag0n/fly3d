using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    /* 
     * this class is used for controlling the frontend of genshin minigame
    */

    //singleton 
    public static MiniGame instance;

    // pointer position value, range 0-180 implements start (0) to end(100)
    public float CurPointerValue;
    public float moveSpeed = 10;
    bool movingUp;

    // store current target region
    List<float> curTargetRegion = new List<float>();

    // detect whether this minigame is running 
    bool _isRuning;
    bool _isPause;

    private void Awake()
    {
        CurPointerValue = 0;
        _isRuning = false;
    }

    private void Update()
    {
        UpdateCurPointer();
    }

    // update curPointer
    private void UpdateCurPointer()
    {
        //usual move 
        if (_isRuning) 
        {
            if (CurPointerValue >= 180) { movingUp = false; }
            if (CurPointerValue <= 0) { movingUp = true; }

            CurPointerValue += movingUp ? Time.deltaTime * moveSpeed : -Time.deltaTime * moveSpeed;
        }

        //unusual move
        if (CurPointerValue > 20 && CurPointerValue < 160) 
        {
            float chance = Random.Range(0, 100);
            if (chance > 5) { return; }

            //--------------random move value--------------
            CurPointerValue += 5;
        }
    }


    #region Public function

    /// <summary>
    /// This funciton is used to generate a target region in fixed length
    /// </summary>
    /// <param name="n">paramter used to determined the target region amount</param>
    /// <returns>
    /// result: float[] cotain start point and end point of target region range 0 - 100
    /// </returns>
    public List<(float, float)> GenerateTargetRegion(int n)
    {



        List<(float, float)> result = new List<(float, float)>();
        float fixedLength = 40;
        if (n < 1) { Debug.LogError("cannot generate **0** target region"); return result; }
        if (!_isRuning)
        {
            Debug.LogError("The mini game is not running");
            return result;
        }


        List<float> nums = new List<float>(18);
        for (float i = 0; i < nums.Count; i++)
        {
            nums.Add(i * 10);
        }

        for (int i = 0; i < n; i++)
        {
            //generate "random" region
            int targetIndex = Random.Range(0, nums.Count);
            float targetPoint = nums[targetIndex];
            float endPoint = targetPoint + fixedLength;

            nums.Remove(nums[targetIndex]);
            curTargetRegion.Add(nums[targetIndex]);
            result.Add((targetPoint, endPoint));
        }
        return result;
    }

    /// <summary>
    /// this function is used to detect whether the current pointer is in the target region
    /// </summary>
    /// <returns> return whether current pointer is in target region</returns>
    public bool Detect()
    {
        if (!_isRuning)
        {
            Debug.LogError("The mini game is not running");
            return false;
        }
        for (int i = 0; i < curTargetRegion.Count; i++)
        {
            if (CurPointerValue >= curTargetRegion[i] && CurPointerValue <= curTargetRegion[i] + 40)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// tell this class to start game
    /// </summary>
    public void StartMiniGame()
    {
        _isRuning = true;
        if (_isPause)
        {
            _isPause = false;
        }
        else
        {
            // clear current target region backup
            curTargetRegion.Clear();
        }
    }

    public void PauseMiniGame()
    {
        _isPause = true;
        _isRuning = false;
    }

    public void StopMiniGame()
    {
        _isRuning = false;
    }
    #endregion



}
