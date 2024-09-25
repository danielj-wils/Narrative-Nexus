using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextMechanism : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());   
    }

    // Update is called once per frame
    void Update()
    {
        MoveText();
    }

    public void MoveText()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public IEnumerator FadeOut()
    {
        float startAlpha = Text.color.a;
        float rate = 1.0f / lifeTime;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmp = Text.color;
            tmp.a = Mathf.Lerp(startAlpha, 0, progress);

            Text.color = tmp;

            progress += rate * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
