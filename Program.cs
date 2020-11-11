using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace Lab10
{
    class Program
    {
        static void Reaction(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Collection changed: " + e.Action);
        }
        static void Main(string[] args)
        {
            // =========
            // 1
            // =========

            Image air, fire;
            Image[] imgArr =
                {
                    new Image(200,200,"png", "water"),
                    new Image(100,200, "png", "earth"),
                    fire = new Image(300,200, "jpg", "fire"),
                    air = new Image(150,200, "png", "air")
                };
            var imgList = new ImgList(imgArr);
            Console.WriteLine(imgList);

            imgList.Add(new Image());
            imgList.Remove(fire);
            Console.WriteLine(imgList);
            Console.WriteLine(imgList.Find(air));

            // =========
            // 2
            // =========

            var list1 = new LinkedList<int>();
            list1.AddLast(0);
            list1.AddLast(1);
            list1.AddLast(2);
            list1.AddLast(3);
            list1.AddLast(4);

            int n = 3;

            for (int i = 0; i < n; i++)
                list1.RemoveLast();

            list1.AddFirst(-2);
            list1.AddAfter(list1.First, -1);
            list1.AddBefore(list1.First, -3);


            var list2 = new List<int>(list1);

            foreach (int item in list2)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Predicate<int> func = delegate (int x)
            {
                return x > 0;
            };
            Console.WriteLine(list2.Find(func));
            Console.WriteLine(list2.FindIndex(0,func));

            // =========
            // 3
            // =========

            var obsColl = new ObservableCollection<Image>();

           
            obsColl.CollectionChanged += Reaction;
            obsColl.Add(air);
            obsColl.Add(fire);
            obsColl.Remove(fire);
        }

       
    }
}
