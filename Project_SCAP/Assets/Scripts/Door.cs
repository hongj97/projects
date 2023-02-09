using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : MonoBehaviour
{
    private int[] goal;
    private int[] input_goal;
    private int input_num;

    // Update is called once per frame
    void Start()
    {
        goal = new int[4]{1,2,3,4};
        input_goal = new int[4];
        input_num = 0;
    }

    public void input_val(int i)
    {   
        print("input 1");
        input_goal[input_num] = i;
        input_num += 1;
        if(input_num == 4){
            if(Enumerable.SequenceEqual(goal, input_goal)){
                print("open");
            }
            else{
                input_num = 0;
                print("retry");
            }

        }

    }
}
