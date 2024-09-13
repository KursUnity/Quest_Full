using System.Collections;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Food[] Foods;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        var timer = new WaitForSeconds(2);

        while (true)
        {
            Instantiate(Foods[Random.Range(0, Foods.Length)], new Vector3(Random.Range(-34, 34), Random.Range(-5.85f, 0f), 0), Quaternion.identity);
            //Instantiate(Foods[Случайный префаб(от 0 элемента,до длины массивы)],
            //new Vector3(по оси Х случайная позиция от(-34,по 34), По оси Y(-5.85f, 1.5f), по оси Z - 0),стандартное вращение);
            yield return timer;
        }
    }
}
