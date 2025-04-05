using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class No : MonoBehaviour
{
    private void OnMouseDown()
    {
        GridManager gridManagerTempReference = GameObject.Find("TiebreakerMain").GetComponent<GridManager>();
        gridManagerTempReference.promoteQuestion.SetActive(false);
        gridManagerTempReference.noOption.SetActive(false);
        gridManagerTempReference.yesOption.SetActive(false);
    }
}
