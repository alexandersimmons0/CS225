//  This script is for displaying text
//       on the Inspector for communication purposes.
//                                                 - Sachiterasu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [TextArea(5, 10)]
    public string note;
}
