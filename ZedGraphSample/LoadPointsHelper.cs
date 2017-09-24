using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZedGraph;

namespace ZedGraphSample
{
    public  class LoadPointsHelper
    {
        public static List<PointPairList> GetPointPairList(string path)
        {
            var list = new List<PointPairList>();
            var list1 = new PointPairList();
            var list2 = new PointPairList();
            var list3 = new PointPairList();
            var list4 = new PointPairList();
            var list5 = new PointPairList();
            path = @"E:\11.txt";
            if (File.Exists(path))
            {
                var readText = File.ReadAllLines(path);
                for (int i = 1; i < readText.Length; i++)
                {
                    var lineArr = readText[i].Split('\t');
                    var num1 = double.Parse(lineArr[0]);
                    var num2 = double.Parse(lineArr[5]);
                    var num3 = double.Parse(lineArr[9]);
                    var num4 = double.Parse(lineArr[11]);
                    var num5 = double.Parse(lineArr[13]);
                    var num6 = double.Parse(lineArr[17]);
                    if (num1 <= 730)
                    {
                        list1.Add(num1, num2);
                        list2.Add(num1, num3);
                        list3.Add(num1, num4);
                        list4.Add(num1, num5);
                        list5.Add(num1, num6);
                    }
                    
                }
               
               
            }
            list.Add(list1);
            list.Add(list2);

            list.Add(list3);
            list.Add(list4);
            list.Add(list5);


            return list;
        }
    }
}
