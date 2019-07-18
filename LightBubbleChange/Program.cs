using System;
using System.Collections.Generic;
using System.Linq;

namespace LightBubbleChange
{
    /// <summary>
    /// 題目假設會有0~n個燈泡(最小為第0個燈泡)
    /// 題會隨機給一個開關順序的數字陣列
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var order = new int[] { 1, 3, 2, 4, 5 , 2 , 3 , 2, 1, 2 };
            var changeCount = CountChange(order);
            Console.WriteLine(changeCount);
        }

        static int CountChange(int[] order)
        {
            var max = order.Max();
            var min = order.Min();

            LightBubble[] lightArr = new LightBubble[max - min + 1];
            for (var i = 0; i < lightArr.Length; i++, min++)
            {
                lightArr[i] = new LightBubble(i);
            }
            var lightLinkList = new LinkedList<LightBubble>(lightArr);
            var firstNode = lightLinkList.First;

            var changeCount = 0;
            foreach(var i in order)
            {
                if(i == min)
                {
                    firstNode.Value.IsOpen = !firstNode.Value.IsOpen;
                    changeCount += 1;
                    continue;
                }

                LinkedListNode<LightBubble> currentNode = firstNode;
                bool isChange = true;

                for(var x = 0;x < i - 1; x++)
                {
                    if(currentNode.Value.IsOpen == false)
                    {
                        isChange = false;
                    }
                    currentNode = currentNode.Next;
                }
                currentNode.Value.IsOpen = !currentNode.Value.IsOpen;
                if (isChange)
                {
                    changeCount += 1;
                }
            }

            return changeCount;
        }
    }

    class LightBubble
    {
        public bool IsOpen = false;
        
        public int Index;

        public LightBubble(int i)
        {
            this.Index = i;
        }
    }


}
