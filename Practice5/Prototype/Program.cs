﻿using Project3_Prototype;

var hero = new Character("Артур", 100, 20, 15, 10, new Weapon("Меч Пламени", 35), new Armor("Кираса Света", 25));

hero.Skills.Add(new Skill("Огненный удар", "Физическая"));
hero.Skills.Add(new Skill("Огненный шар", "Магическая"));

Console.WriteLine("Оригинал персонажа:");
Console.WriteLine(hero);

var clone = hero.Clone();
clone.Name = "Клон Артура";
clone.Weapon.Name = "Меч Тьмы";
clone.Armor.Defense = 40;
clone.Skills[0].Name = "Темный удар";

Console.WriteLine("Клон персонажа (изменён):");
Console.WriteLine(clone);

Console.WriteLine("Оригинал после изменений клона:");
Console.WriteLine(hero);