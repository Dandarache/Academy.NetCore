using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    class ObjectsReferenceTypesDemo
    {
        class MyPoint
        {
            public MyPoint(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return $"X={X}, Y={Y}";
            }

        }

        public void Run()
        {
            MyPoint myPoint = new MyPoint(3, 4);
            Console.WriteLine(myPoint.ToString());

            ChangePoint(myPoint);
            Console.WriteLine(myPoint.ToString());

            // --------------------------

            StringBuilder sbData = new StringBuilder();
            sbData.Append("Let's go dancing!");
            Console.WriteLine(sbData.ToString());

            ChangeStringBuilder(sbData);
            Console.WriteLine(sbData.ToString());

            ChangeStringBuilderReplace(sbData);
            Console.WriteLine(sbData.ToString());

            ChangeStringBuilderReplaceWithRef(ref sbData);
            Console.WriteLine(sbData.ToString());
        }

        private void ChangePoint(MyPoint point)
        {
            point.X = 555;
            point.Y = 222;
        }

        private void ChangeStringBuilder(StringBuilder sb)
        {
            sb.Append(" Yes that would be great!");
        }

        private void ChangeStringBuilderReplace(StringBuilder sb)
        {
            sb = new StringBuilder("Yes that would be great!");
            Console.WriteLine(sb.ToString());
        }

        private void ChangeStringBuilderReplaceWithRef(ref StringBuilder sb)
        {
            sb = new StringBuilder("Yes that would be great!");
            Console.WriteLine(sb.ToString());
        }
    }
}
