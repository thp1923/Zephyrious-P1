using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform diemDichChuyenDen;
    public Transform GetDiemDichChuyenDen()
    {
        return diemDichChuyenDen;
    }
}