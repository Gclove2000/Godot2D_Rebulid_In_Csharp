using Bogus;
using Godot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SceneInstancingDemo
{
    public static class GD_Extensions
    {
        /// <summary>
        /// 假数据生成，详情请看Bogus官方文档
        /// </summary>
        public static Faker Faker = new Faker();

        /// <summary>
        /// 获取子节点，需要保证子节点命名完全一致
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="root">node跟节点</param>
        /// <param name="childNode">子节点属性，需要保证和场景命名完全一致</param>
        /// <param name="nameExpression">获取子节点命名字符串</param>
        /// <exception cref="Exception"></exception>
        public static void GetChildNode<T1, T2>(this T1 root, ref T2 childNode,
            [CallerArgumentExpression(nameof(childNode))] string nameExpression = null)
            where T1 : Node where T2 : Node
        {
            childNode = root.GetNode<T2>(nameExpression);
            if (childNode == null)
            {
                var str = $"{nameExpression} node is null!";
                GD.Print(str);
                throw new Exception(str);
            }
        }
        /// <summary>
        /// Godot 序列号输出
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="formatting"></param>
        public static void GD_Print(object obj, Formatting formatting = Formatting.None)
        {
            GD.Print(JsonConvert.SerializeObject(obj, formatting));

        }

        /// <summary>
        /// 获取输入转为2D移动
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetMoveInput()
        {
            var velocity = Vector2.Zero;

            if (Input.IsActionPressed("ui_right"))
            {
                velocity.X += 1;
            }
            if (Input.IsActionPressed("ui_left"))
            {
                velocity.X -= 1;


            }
            if (Input.IsActionPressed("ui_up"))
            {
                velocity.Y -= 1;
            }
            if (Input.IsActionPressed("ui_down"))
            {
                velocity.Y += 1;

            }
            return velocity;
        }
    }

}
