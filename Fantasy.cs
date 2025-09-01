using System;
using System.Collections.Generic;
using System.Threading;

namespace Project
{

    class FantasyGame
    {

        private static int damage = 15;
        private static int health = 100;
        private static string playerName = "None";
        private static List<string> inventory = new List<string>();
        private static int maxHealth = 100;

        public static void Main()
        {

            // Variables

            Random random = new Random();
            int playerInput;
            List<string> questions = new List<string>()
            {
                "НайтиВолшебныйЯнтарь", "УбитьМонстра", "НайтиКурицу", "ЗагадкаСтатуи"
            };
            int randIndex = random.Next(questions.Count);
            string randQuest = questions[randIndex];
            byte nameKnow = 0;
            float moneys = 0;
            float qMoneys;
            int randNum;
            int skillPoints = 10;
            int intellect = 0;
            int dexterity = 0;
            int charizma = 0;

            // Introduction

            SlowPrint("Введите свое имя: ", 0);
            playerName = Console.ReadLine() ?? "Путник";
            SlowPrint($"Здраствуй, {playerName}. Что хочешь прокачать?", 1);
            Thread.Sleep(1000);

            // Skill Points Allocation

            do
            {

                Console.Clear();
                Console.WriteLine("Очки Уменя: " + skillPoints);
                Console.WriteLine("1. Харизма: " + charizma);
                Console.WriteLine("2. Интеллект: " + intellect);
                Console.WriteLine("3. Ловкость: " + dexterity);
                Console.Write("> ");
                playerInput = Convert.ToInt32(Console.ReadLine());

                switch (playerInput)
                {
                    case 1:
                        charizma++;
                        skillPoints--;
                        break;
                    case 2:
                        intellect++;
                        skillPoints--;
                        break;
                    case 3:
                        dexterity++;
                        skillPoints--;
                        break;
                    default:
                        System.Console.WriteLine("Неизвестная характеристика!");
                        break;
                }

            }
            while (skillPoints != 0);

            // Game Start

            SlowPrint("Ты очень долго шел и наткнулся на деревню", 1);
            Thread.Sleep(1000);

            // Main Menu

            do
            {

                Console.Clear();
                Console.WriteLine("1 - Взять задание");
                Console.WriteLine("2 - Пойти на рынок");
                Console.WriteLine("3 - Посмотреть статистику");
                Console.WriteLine("4 - Выход");
                Console.Write("> ");
                playerInput = Convert.ToInt32(Console.ReadLine());

                // QuestsMenu

                if (playerInput == 1)
                {

                    // First time meeting the Quest Giver

                    if (nameKnow == 0)
                    {
                        SlowPrint("- Привет, путник! Как тебя зовут?", 1);
                        SlowPrint($"- Меня зовут {playerName}", 1);
                        SlowPrint($"- Приятно познакомится, {playerName}. Если хочешь взять задание, то приходи ко мне! ", 1);
                        nameKnow = 1;
                        continue;
                    }

                    // Subsequent meetings with the Quest Giver

                    else if (nameKnow == 1)
                    {
                        SlowPrint($"Привет, {playerName}! Хочешь взять задание?", 1);
                        Console.WriteLine("1 - Да");
                        Console.WriteLine("2 - Нет");
                        playerInput = Convert.ToInt32(Console.ReadLine());

                        if (playerInput == 1)
                        {
                            SlowPrint("- Да, конечно!", 1);
                            SlowPrint("- Отлично! Вот тебе задание: ", 1);
                            randIndex = random.Next(questions.Count);
                            randQuest = questions[randIndex];
                        }
                        else if (playerInput == 2)
                        {
                            SlowPrint("- Нет, не сегодня...", 1);
                            SlowPrint("- Ладно, пока.", 1);
                        }

                        else
                        {
                            SlowPrint("Неизвестный ответ!", 1);
                            continue;
                        }


                    }

                    // Quest №1 - Riddle of the Statue

                    Thread.Sleep(1000);
                    if (randQuest == "ЗагадкаСтатуи")
                    {

                        // Quest №1 Intro

                        SlowPrint("Живая статуя возле фонтана опять украла мое кольцо!", 1);

                        if (charizma >= 5)
                            qMoneys = 20f * 1.5f;

                        else
                            qMoneys = 20f;

                        SlowPrint($"Верни его и я дам тебе {qMoneys} золотых.", 1);
                        Console.Clear();

                        // Quest №1 Logic

                        SlowPrint("Через некоторое время ты дошел до статуи...", 1);
                        SlowPrint("- Ей, ты - сказала статуя - Ты ведь кольцо ишешь?", 1);
                        SlowPrint("- Да...", 1);
                        SlowPrint("- Если отгадаешь число, которое я загадал от 0 до 10, то отдам", 1);
                        SlowPrint("- Да легко!", 1);
                        SlowPrint("- Ну посмотрим...", 1);

                        randNum = random.Next(0, 10);
                        if (intellect >= 4)
                        {

                            SlowPrint($"- {randNum}, то число, котрое ты загадал.", 1);
                            SlowPrint("- Вот блин, а. Ладно... Забирай и проваливай!", 1);
                            inventory.Add("Кольцо");
                            Console.WriteLine();

                        }
                        else if (dexterity >= 4)
                        {

                            SlowPrint("Пока статуя была отвлечена, ты украл кольцо и убежал.", 1);
                            SlowPrint("- Эй куда!", 1);
                            inventory.Add("Кольцо");

                        }
                        else
                        {

                            playerInput = Convert.ToInt32(Console.ReadLine());

                            if (playerInput == randNum)
                            {
                                SlowPrint("- Ладно! Забирай свое кольцо и уходи прочь от сюда!", 1);
                                inventory.Add("Кольцо");
                            }
                            else
                                Console.WriteLine("- НЕ УГАДАЛ! ХА! ИДИ ОТСЮДА, ЛОХ!");

                        }

                        // Quest №1 End

                        if (inventory.Contains("Кольцо"))
                        {
                            moneys += qMoneys;
                            Console.WriteLine($"Ты получил {qMoneys} монет!");
                            inventory.Remove("Кольцо");
                        }

                        else
                            SlowPrint("Ты не смог достать кольцо и не получил денег...", 1);
                        Thread.Sleep(1000);

                    }

                    // Quest №2 - Find the Chicken

                    else if (randQuest == "НайтиКурицу")
                    {

                        // Quest №2 Intro

                        SlowPrint("Сегодня у моих соседей курица потерялась!", 1);
                        if (charizma >= 5)
                            qMoneys = 10f * 1.5f;

                        else
                            qMoneys = 10f;

                        SlowPrint($"Если найдешь ее, то заплачу {qMoneys} монет", 1);
                        Console.Clear();

                        // Quest №2 Logic

                        while (!inventory.Contains("Курица") && !inventory.Contains("Плохая весть"))
                        {

                            Console.WriteLine("1 - Проверить повозку");
                            Console.WriteLine("2 - Проверить фонтан");
                            Console.WriteLine("3 - Проверить трактир");
                            Console.Write("> ");
                            playerInput = Convert.ToInt32(Console.ReadLine());

                            if (playerInput == 1)
                                SlowPrint("За повозкой никого не было...", 1);

                            else if (playerInput == 2 && dexterity >= 3)
                            {
                                SlowPrint("Ты увидел курицу и схватил ее!", 1);
                                inventory.Add("Курица");
                            }

                            else if (playerInput == 2 && dexterity < 3)
                                SlowPrint("курицы там тоже нет!", 1);

                            else if (playerInput == 3 && dexterity > 3)
                                SlowPrint("В трактире курицы небыло", 1);

                            else if (playerInput == 3 && dexterity < 3)
                            {
                                SlowPrint("Ты спросил у трактирщика не видел ли он курицу, он ответил что сегодня курицу с улицы уже зарезали... мда уж", 1);
                                inventory.Add("Плохая Весть");
                            }

                            else
                                Console.WriteLine("Не время прохлождаться!");

                            // Quest №2 End

                            if (inventory.Contains("Курица"))
                            {
                                moneys += qMoneys;
                                SlowPrint($"Ты отдал курицу и получил {qMoneys} монет", 1);
                                inventory.Remove("Курица");
                                Thread.Sleep(1000);
                                break;
                            }

                            else if (inventory.Contains("Плохая Весть"))
                            {
                                SlowPrint("ты принес плохую весть и понятное дело не получил монет", 1);
                                inventory.Remove("Плохая Весть");
                                Thread.Sleep(1000);
                                break;
                            }

                            else
                                SlowPrint("Ты не смог найти курицу...", 1);

                        }

                    }

                    // Quest №3 - Kill the Monster

                    else if (randQuest == "УбитьМонстра")
                    {

                        // Quest №3 Intro

                        SlowPrint("Вокруг деревни бродит монстр.", 1);
                        if (charizma >= 5)
                            qMoneys = 35f * 1.5f;

                        else
                            qMoneys = 35f;

                        SlowPrint($"Убьешь его и получишь {qMoneys}", 1);
                        Console.Clear();

                        // Quest №3 Logic

                        SlowPrint("Ты вышел на поляну зв деревней и встретил болотного монстра!", 1);
                        Fight(80, 10, "Болотного Монстра", 1);
                        inventory.Add("Голова монстра");

                        // Quest №3 End

                        if (inventory.Contains("Голова Монстра"))
                        {
                            moneys += qMoneys;
                            SlowPrint($"Ты отдал голову монстра и получил {qMoneys} монет", 1);
                            inventory.Remove("Голова монстра");
                        }

                        else
                            SlowPrint("Ты не смог убить монстра и не получил денег...", 1);

                        Thread.Sleep(1000);

                    }

                    // Quest №4 - Find the Magic Amber

                    else if (randQuest == "НайтиВолшебныйЯнтарь")
                    {

                        // Quest №4 Intro

                        SlowPrint("Одному волшебнику нужен волшебный янтарь из пещеры.", 1);
                        if (charizma >= 5)
                            qMoneys = 50f * 1.5f;

                        else
                            qMoneys = 50f;

                        SlowPrint($"Принесешь его и получишь {qMoneys} монет", 1);
                        Console.Clear();

                        // Quest №4 Logic

                        SlowPrint("Ты пришел к пещере, вход в пещеру охранял Каменны Голем", 1);
                        Thread.Sleep(1000);

                        if (dexterity >= 5)
                        {
                            SlowPrint("Ты обошел голема и зашел в пещеру и нашел волшебный янтарь", 1);
                            inventory.Add("Волшебный Янтарь");
                        }

                        else if (maxHealth < 125)
                        {
                            SlowPrint("Ты попытался сразиться с големом, но у тебя не хватило сил его победить...", 1);
                            continue;
                        }

                        else
                        {
                            SlowPrint("Голем заметил тебя и напал!", 1);
                            Fight(120, 20, "Каменный Голем", 0);
                            SlowPrint("После победы ты зашел в пещеру и нашел волшебный янтарь!", 1);
                            inventory.Add("Волшебный Янтарь");
                        }

                        // Quest №4 End

                        if (inventory.Contains("Волшебный Янтарь"))
                        {
                            moneys += qMoneys;
                            SlowPrint($"Ты отдал волшебный янтарь и получил {qMoneys} монет", 1);
                            inventory.Remove("Волшебный Янтарь");
                        }

                        else
                            SlowPrint("Ты не смог найти волшебный янтарь и не получил денег...", 1);
                        Thread.Sleep(1000);

                    }

                }


                else if (playerInput == 2)
                {

                    // Market Menu

                    Console.Clear();
                    SlowPrint($"~Market~Menu~", 1);
                    Console.WriteLine("1 - Кузнца");
                    Console.WriteLine("2 - Алхимический дом");
                    Console.WriteLine("3 - Трактир");
                    Console.WriteLine("4 - Назад");
                    Console.Write("> ");
                    playerInput = Convert.ToInt32(Console.ReadLine());

                    // Blacksmith

                    if (playerInput == 1)
                    {

                        // Blacksmith Menu

                        SlowPrint("- Здравствуй! Здравствуй мѻлодец! Иль купить чего хочешь, иль посмотреть пришел?", 1);
                        Console.WriteLine("1 - Старый Меч (20 монет) +5 урон");
                        Console.WriteLine("2 - Кожанная Броня (20 монет) +15 здоровье");
                        Console.WriteLine("3 - Стальной меч (65 монет) +15 урон");
                        Console.WriteLine("4 - Стальная броня (65 монет) +35 здоровье");
                        Console.WriteLine("5 - Назад");
                        Console.Write("> ");
                        playerInput = Convert.ToInt32(Console.ReadLine());

                        // Blacksmith Logic

                        if (playerInput == 1 && moneys >= 20)
                        {
                            damage += 5;
                            moneys -= 20;
                            SlowPrint("Ты купил Старый Меч!", 1);
                            inventory.Add("Старый Меч");
                        }

                        else if (playerInput == 2 && moneys >= 20)
                        {
                            maxHealth += 20;
                            HealthCap();
                            moneys -= 20;
                            SlowPrint("Ты купил Кожанную Броню!", 1);
                            inventory.Add("Кожанная Броня");
                        }

                        else if (playerInput == 3 && moneys >= 65)
                        {
                            damage += 15;
                            moneys -= 65;
                            SlowPrint("Ты купил Стальной Меч!", 1);
                            inventory.Add("Стальной Меч");
                        }

                        else if (playerInput == 4 && moneys >= 65)
                        {
                            maxHealth += 50;
                            HealthCap();
                            moneys -= 65;
                            SlowPrint("Ты купил Стальную Броню!", 1);
                            inventory.Add("Стальная Броня");
                        }

                        else if (playerInput == 5)
                            continue;

                        else
                            SlowPrint("Недостаточно монет (или не тот выбор!)!", 1);

                    }

                    // Alchemy House

                    else if (playerInput == 2)
                    {

                        // Alchemy House Menu

                        SlowPrint($"- Приветствую тебя, {playerName}! Спросишь, откуда я знаю твое имя? Перепил отвара чистого разума! Хочешь купить?", 1);
                        Console.WriteLine("1 - Лечебная настойка (15 монет) +20 востановленного зоровья здоровье");
                        Console.WriteLine("2 - Отвар чистого разума (80 монет) +1 интеллекта");
                        Console.WriteLine("3 - Чай из ловкоцвета (80 монет) +1 ловкости");
                        Console.WriteLine("4 - Веселящий отвар (80 монет) +1 харизмы");
                        Console.WriteLine("5 - Назад");
                        Console.Write("> ");
                        playerInput = Convert.ToInt32(Console.ReadLine());

                        // Alchemy House Logic

                        if (playerInput == 1 && moneys >= 15)
                        {
                            health += 20;
                            HealthCap();
                            moneys -= 15;
                            SlowPrint("Ты выпил лечебную настойку и восстановил здоровье!", 1);
                            HealthCap();
                        }

                        else if (playerInput == 2 && moneys >= 80)
                        {
                            intellect++;
                            moneys -= 80;
                            SlowPrint("Ты выпил отвар чистого разума и повысил интеллект!", 1);
                        }

                        else if (playerInput == 3 && moneys >= 80)
                        {
                            dexterity++;
                            moneys -= 80;
                            SlowPrint("Ты выпил чай из ловкоцвета и повысил ловкость!", 1);
                        }

                        else if (playerInput == 4 && moneys >= 80)
                        {
                            charizma++;
                            moneys -= 80;
                            SlowPrint("Ты выпил веселящий отвар и повысил харизму!", 1);
                        }

                        else if (playerInput == 5)
                            continue;

                        else
                            SlowPrint("Недостаточно монет (или не тот выбор!)!", 1);

                    }

                    else if (playerInput == 3)
                    {

                        // Tavern Menu

                        SlowPrint("- Эй, путник! Хочешь отдохнуть? Всего 10 монет!", 1);
                        Console.WriteLine("1 - Да");
                        Console.WriteLine("2 - Нет");
                        Console.Write("> ");
                        playerInput = Convert.ToInt32(Console.ReadLine());

                        // Tavern Logic

                        if (playerInput == 1 && moneys >= 10)
                        {
                            health = maxHealth;
                            moneys -= 10;
                            SlowPrint("Ты отдохнул в трактире и восстановил здоровье!", 1);
                        }

                        else if (playerInput == 1 && moneys < 10)
                            SlowPrint("Недостаточно монет!", 1);

                        else if (playerInput == 2)
                            SlowPrint("- Ладно, пока.", 1);

                        else
                            SlowPrint("Неизвестный ответ!", 1);

                    }

                    else if (playerInput == 4)
                        continue;

                    else
                        SlowPrint("Неизвестный ответ!", 1);

                }

                else if (playerInput == 3)
                {

                    // Stats Menu

                    Console.Clear();
                    SlowPrint($"~{playerName}~Stats~", 1);
                    Console.WriteLine("Здоровье: " + health + "/" + maxHealth);
                    Console.WriteLine("Урон: " + damage);
                    Console.WriteLine("Интеллект: " + intellect);
                    Console.WriteLine("Ловкость: " + dexterity);
                    Console.WriteLine("Харизма: " + charizma);
                    Console.WriteLine("Монеты: " + moneys);
                    Console.WriteLine("Инвентарь: ");
                    foreach (string item in inventory)
                    {
                        Console.WriteLine("- " + item);
                    }
                    Console.WriteLine("Нажмите любую кнопку, чтобы вернуться назад...");
                    Console.ReadKey();

                }

                else if (playerInput == 4)
                    Environment.Exit(0);

                else
                    SlowPrint("Неизвестный ответ!", 1);


            }
            while (playerInput != 'e');

        }

        //Functions


        // Prints text slowly
        static void SlowPrint(string text, int c)
        {

            int delay = 50;

            foreach (char i in text)
            {
                Console.Write(i);
                Thread.Sleep(delay);
            }
            if (c == 1)
                Console.WriteLine();

        }


        // Fight function
        static void Fight(int enemyHealth, int enemyDamage, string enemyName, int i)
        {

            SlowPrint($"Здоровье {enemyName}: {enemyHealth}, Урон {enemyName}: {enemyDamage}.", 1);
            SlowPrint($"Здоровье {playerName}: {health}, Урон {playerName}: {damage}.", 1);

            while (health > 0 && enemyHealth > 0)
            {
                health -= enemyDamage;
                enemyHealth -= damage;
                Console.WriteLine($"Здоровье {playerName}: {health}");
                Console.WriteLine($"Здоровье {enemyName}: {enemyHealth}");
                Thread.Sleep(1000);
            }

            if (health <= 0)
            {
                SlowPrint("Ты проиграл!", 1);
                Environment.Exit(0);
            }
            else if (enemyHealth <= 0)
            {
                SlowPrint($"Ты победил {enemyName}!", 1);
            }

            if (i == 1)
            {
                inventory.Add("Голова Монстра");
            }


        }

        // Health cap
        static void HealthCap()
        {

            if (health > maxHealth)
                health = maxHealth;

        }

    }

}