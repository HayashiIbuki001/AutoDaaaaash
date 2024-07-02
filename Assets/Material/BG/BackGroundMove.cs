using UnityEngine;
using UnityEngine.UI;

public class BackGroundMove : MonoBehaviour
{
    private const float s_MaxLength = 1f;
    private const string s_PropName = "_MainTex";

    [SerializeField]
    private Vector2 m_offsetSpeed;

    private Material m_material;

    private void Start()
    {
        if (GetComponent<Image>() is Image i)
        {
            m_material = i.material;
        }
    }

    private void Update()
    {
        if (m_material)
        {
            // xとyの値が0 ～ 1でリピートするようにする
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, s_MaxLength);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, s_MaxLength);
            var offset = new Vector2(x, y);
            m_material.SetTextureOffset(s_PropName, offset);
        }
    }

    private void OnDestroy()
    {
        // ゲームをやめた後にマテリアルのOffsetを戻しておく
        if (m_material)
        {
            m_material.SetTextureOffset(s_PropName, Vector2.zero);
        }
    }
}
