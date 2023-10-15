using Bogus;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BulletShower
{
    public static class GD_Extension
    {
        public static Faker Faker = new Faker();

        public static void GetChildNode<T1,T2>(this T1 root,ref T2  childNode, 
            [CallerArgumentExpression(nameof(childNode))] string nameExpression = null)
            where T1: Node where T2: Node
        {
            childNode = root.GetNode<T2>(nameExpression);
            if(childNode == null)
            {
                var str = $"{nameExpression} node is null!";
                GD.Print(str);
                throw new Exception(str);
            }
        }

    }
}
