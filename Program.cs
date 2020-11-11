using System;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
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

        }
    }
}
