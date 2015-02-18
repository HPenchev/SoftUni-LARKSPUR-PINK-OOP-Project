using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using Game.Characters;
using Game.Core;
using Game.Draw;
using Game.Enemies;
using Game.Engine;
using Game.Items;

public class Example
{
    private static void Main()
    {
        //Engine engine = new Engine();
        //engine.Run();
        //Minion asd = new Minion("asd");
        //Console.WriteLine(asd.Id);
        //Console.WriteLine(asd.IsAlive);
        //Console.WriteLine(asd.AttackPoints);
        while (true)
        {
            MapGenerator map = new MapGenerator(30, 2, 2, 2, 10);
            map.PrintMap();
            Console.WriteLine();
        }
          


        //List<GameObject>dae.

        //int enemyCount = 5;
        //for (int < enemyCount)
        //{
        //    new enemy Random size of karta
        // poziciqta se zadava ot kartata
        //        dae.add
        //}

    }
}