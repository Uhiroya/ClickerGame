using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrankRotateManager : MonoBehaviour
{
    static public float Total_Rotate { get; private set; } = 0;
    RectTransform _parent_Rect = default;
    Vector2 _posStart;
    Quaternion _boxRotation;
    Vector2 _vecStart;
    Vector2 _vecEnd;
    bool _isTarget = false;
    float _mouseAngle;
    // Start is called before the first frame update
    void Start()
    {
        _parent_Rect = transform.parent.GetComponent<RectTransform>();
    }
    public void SetPos()
    {
        _posStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _isTarget = true;
    }
    public void Rotate()
    {

        _boxRotation = transform.parent.rotation;
        Vector2 parent_position = (Vector2)_parent_Rect.position;
        //èâä˙à íu
        _vecStart = _posStart - parent_position;
        _vecEnd = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - parent_position);
        _mouseAngle = Vector2.Angle(_vecStart, _vecEnd);
        if (_isTarget)
        {
            if (Vector3.Cross(_vecStart, _vecEnd).z < 0)
            {
                if (_mouseAngle > 1)
                {
                    transform.parent.localRotation = _boxRotation * Quaternion.Euler(0, 0, -_mouseAngle);
                    _posStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Total_Rotate += _mouseAngle;
                    if (Total_Rotate > 360)
                    {
                        Total_Rotate -= 360;
                        print("âÒÇ¡ÇΩ");
                        print(EQUIP_LIST.g_list[0].GenerateAmount());
                        //àÍé¸îªíË
                        GAME_MAIN.capa = GAME_MAIN.capa + (EQUIP_LIST.g_list[0].GenerateAmount());
                    }
                    _mouseAngle = 0;
                }
            }
            else
            {
                _isTarget = false;
            }
        }

    }


}
