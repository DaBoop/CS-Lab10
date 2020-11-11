using System;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Image[] imgArr =
                {
                    new Image(200,200,"png", "water"),
                    new Image(100,200, "png", "earth"),
                    new Image(300,200, "jpg", "fire"),
                    new Image(150,200, "png", "air")
                };
            var imgList = new ImgList(imgArr);
            Console.WriteLine(imgList);
        }
    }
}
