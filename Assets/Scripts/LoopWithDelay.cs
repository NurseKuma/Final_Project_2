using UnityEngine;

public class LoopWithDelay : MonoBehaviour
{
    public AudioSource audioSource;
    public float minDelay = 1f;  // เวลาพักขั้นต่ำ
    public float maxDelay = 3f;  // เวลาพักสูงสุด

    void Start()
    {
        StartCoroutine(PlayLoopWithDelay());
    }

    private System.Collections.IEnumerator PlayLoopWithDelay()
    {
        while (true)
        {
            audioSource.Play();

            // รอจนเสียงเล่นจบ
            yield return new WaitForSeconds(audioSource.clip.length);

            // พักตามที่กำหนด
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }
}
