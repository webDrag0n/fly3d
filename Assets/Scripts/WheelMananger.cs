using Shapes;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WheelMananger : MonoBehaviour
{
    public Disc zone;
    public Disc cursor;
    List<(float, float)> region;
    // Start is called before the first frame update
    void Start()
    {
        region = MiniGame.instance.GenerateTargetRegion(1);
        MiniGame.instance.StartMiniGame();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(region.Count);
        zone.AngRadiansStart = region[0].Item1 / 180 * 3.14f;
        zone.AngRadiansEnd = region[0].Item2 / 180 * 3.14f;

        float cursor_pos = MiniGame.instance.CurPointerValue;
        cursor.AngRadiansStart = (cursor_pos - 1f) / 180 * 3.14f;
        cursor.AngRadiansEnd = (cursor_pos + 1f) / 180 * 3.14f;
    }
}
