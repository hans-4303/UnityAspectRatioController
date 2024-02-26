using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 해상도 컨트롤러와 상호작용하는 UI에 필요한 코드들
/// </summary>
public class UIController : MonoBehaviour
{
    /// <summary>
    /// <para>비율 조정에 필요한 슬라이더</para>
    /// </summary>
    public Slider AspectWidthSlider;
    public Slider AspectHeightSlider;

    /// <summary>
    /// <para>비율 조정 텍스트</para>
    /// </summary>
    public TextMeshProUGUI AspectText;

    /// <summary>
    /// <para>해상도 조정 텍스트</para>
    /// </summary>
    public TextMeshProUGUI ResolutionText;

    /// <summary>
    /// <para>비율 조정 컨트롤러 컴포넌트를 알고 있음</para>
    /// </summary>
    public AspectRatioController AspectController;

    /// <summary>
    /// <para>비율 조정 슬라이더가 움직이면 호출됨</para>
    /// </summary>
    /// <param name="apply">너비나 높이 중 하나가 작동하면 나머지는 자동으로 false 처리</param>
    public void AspectRatioSlidersChanged(bool apply)
    {
        int aspectRatioWidth = (int) AspectWidthSlider.value;
        int aspectRatioHeight = (int) AspectHeightSlider.value;

        AspectText.text = "Aspect: <b>" + aspectRatioWidth + ":" + aspectRatioHeight + "</b>";

        // 비율 조정 컴포넌트에게 새로운 비율을 알림
        AspectController.SetAspectRatio(aspectRatioWidth, aspectRatioHeight, apply);
    }

    /// <summary>
    /// <para>버튼 클릭 시 전체화면과 윈도우 전환</para>
    /// </summary>
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    /// <summary>
    /// <para>창 해상도가 변경될 때마다 트리거되는 AspectRatioController의 이벤트에 대한 콜백.</para>
    /// </summary>
    /// <param name="width">새로운 너비.</param>
    /// <param name="height">새로운 높이.</param>
    /// <param name="fullscren">새로운 풀 스크린 상태, true라면 풀 스크린.</param>
    public void ResolutionChanged(int width, int height, bool fullscren)
    {
        ResolutionText.text = "Resolution: <b>" + width + "x" + height + "</b>";
    }
}
