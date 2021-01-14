using System;
using Raylib_cs;

Raylib.InitWindow(1920, 1080, "Bil spel");
Texture2D background = Raylib.LoadTexture("highway.png");
Texture2D car = Raylib.LoadTexture("car.png");
Texture2D introbild = Raylib.LoadTexture("intro.png");
Texture2D gameover = Raylib.LoadTexture("gameover.png");
Texture2D cone = Raylib.LoadTexture("cone.png");

Rectangle enemyRect = new Rectangle(100, 100, cone.width, cone.height);
Rectangle playerRect = new Rectangle(400, 300, car.width, car.height);

Color red = new Color(255, 0, 0, 128);


string scene = "intro";
float backgroundY = 0;
float coneY = 0;







while (!Raylib.WindowShouldClose())
{




    if (scene == "intro")
    {
        playerRect.x = 400;
        playerRect.y = 300;

        enemyRect.x = 900;
        enemyRect.y = 900;



        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }
    }


    else if (scene == "game")
    {
        backgroundY += 0.1f;
        coneY += 0.2f;



        Raylib.DrawRectangleRec(enemyRect, red);

        if (backgroundY > 1080)
        {
            backgroundY = 0;

        }

        if (coneY > 4000)
        {
            coneY = 0;

        }





        if (playerRect.y > Raylib.GetScreenHeight() || playerRect.x > Raylib.GetScreenWidth() || playerRect.y < 0 || playerRect.x < 0)
        {
            scene = "gameover";
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
        {
            scene = "intro";
        }





        if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            playerRect.x += 0.8f;
        }

        else if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            playerRect.x -= 0.8f;
        }






        if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
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
        Raylib.DrawTexture(car, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        //enemy
        Raylib.DrawTexture(cone, 1000, (int)coneY, Color.WHITE);


    }
    else if (scene == "gameover")
    {
        Raylib.ClearBackground(Color.LIME);
        Raylib.DrawTexture(gameover, 0, 0, Color.WHITE);

    }



    Raylib.EndDrawing();
}