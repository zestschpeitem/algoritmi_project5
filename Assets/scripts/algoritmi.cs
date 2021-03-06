using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class algoritmi : MonoBehaviour
{
    [SerializeField] private int[] ArrayToSort;
    private int element_poiska=1;
    private int maximym;
    private bool element;





    [ContextMenu("sortirovka")]
    public void Sortirovka_massiva()
    {
        ArrayToSort = sortirovka(ArrayToSort);
    }

    public int[] sortirovka(int[] array)
    {
        if (array.Length > 1)
        {
            int[] left = new int[array.Length / 2];
            int[] right = new int[array.Length - left.Length];
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = array[i];
            }
            for (int i = 0; i < right.Length; i++)
            {
                right[i] = array[left.Length + i];
            }
            if (left.Length > 1)
            {
                left = sortirovka(left);
            }
            if (right.Length > 1)
            {
                right = sortirovka(right);
            }
            array = MergeSort(left, right);
        }
        return array;
    }

    public int[] MergeSort(int[] left, int[] right)
    {
        int[] array = new int[left.Length + right.Length];
        int l = 0;//left massiv
        int r = 0;//right massiv
        for (int i = 0; i < array.Length; i++)
        {
            if (r >= right.Length)
            {
                array[i] = left[l];
                l++;
            }
            else if (l < left.Length && left[l] < right[r])
            {
                array[i] = left[l];
                l++;
            }
            else
            {
                array[i] = right[r];
                r++;
            }
        }
        return array;

    }



    [ContextMenu("FindMaximym")]
    public void FindMaximym()
    {
        maximym = Maximym(ArrayToSort);
    }
    public int Maximym(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (max < array[i])
            {
                max = array[i];
            }
        }
        Debug.Log(max);
        return max;
    }


    [ContextMenu("FindElement")]
    public void FindElement()
    {
        element = poisk(ArrayToSort,12);
    }
    public bool poisk(int[] array, int element_poiska)
    {
        bool flag = false;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == element_poiska)
            {
                flag=true;
            }
        }
        Debug.Log(flag);
        return flag;
    }
}
