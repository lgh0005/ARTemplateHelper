using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTo : MonoBehaviour
{
    // 호출할 URL
    public string url = "https://i815.or.kr/2018/main.do";

    // 버튼 클릭 시 호출되는 함수
    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}