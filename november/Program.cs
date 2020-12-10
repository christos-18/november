using System;
using Raylib_cs;

Raylib.InitWindow(1920, 1080, "Bil spel");
Texture2D background = Raylib.LoadTexture("highway.png");
Texture2D car = Raylib.LoadTexture("car.png");
Texture2D introbild = Raylib.LoadTexture("intro.png");
Texture2D gameover = Raylib.LoadTexture("gameover.png");

Rectangle enemyRect = new Rectangle(50, 60, 30, 30);

Color red = new Color(255, 0, 0, 128);


string scene = "intro";
float backgroundY = 0;
float carX = 400;
float carY = 300;






while (!Raylib.WindowShouldClose())
{




    if (scene == "intro")
    {
        carX = 400;
        carY = 300;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }


    else if (scene == "game")
    {
        backgroundY += 0.1f;

        Raylib.DrawRectangleRec(enemyRect, red);

        if (backgroundY > 1080)
        {
            backgroundY = 0;

        }

        if (carY > Raylib.GetScreenHeight() || carX > Raylib.GetScreenWidth() || carY < 0 || carX < 0)
        {
            scene = "gameover";
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
        {
            scene = "intro";
        }





        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            carX += 0.8f;
        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            carX -= 0.8f;
        }



        if (Raylib.CheckCollisionRecs(car, enemyRect)) // funkar inte eftersom det är en bild (hur gör man då)
        {
            scene = "gameover";
        }



    }

    else if (scene == "gameover")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText("GAME OVER! Tryck tabb for att starta om", 100, 50, 20, Color.WHITE);


        if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
        {
            scene = "intro";
        }

    }



    // DRAWING:
    Raylib.BeginDrawing();

    if (scene == "intro")
    {
        Raylib.ClearBackground(Color.LIME);
        Raylib.DrawTexture(introbild, 0, 0, Color.WHITE);
    }
    else if (scene == "game")
    {
        Raylib.ClearBackground(Color.MAROON);
        Raylib.DrawTexture(background, 0, (int)backgroundY, Color.WHITE);
        Raylib.DrawTexture(background, 0, (int)backgroundY - 1080, Color.WHITE);
        Raylib.DrawTexture(car, (int)carX, (int)carY, Color.WHITE);


    }
    else if (scene == "gameover")
    {
        Raylib.ClearBackground(Color.LIME);
        Raylib.DrawTexture(gameover, 0, 0, Color.WHITE);

    }



    Raylib.EndDrawing();
}